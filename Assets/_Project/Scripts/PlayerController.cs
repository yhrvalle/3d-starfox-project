using Enthalpy.Input;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerConfiguration config;
    [SerializeField] private PlayerInputReader inputReader;

    private Vector2 _direction;

    private void Start()
    {
        inputReader.EnablePlayerInputActions();
    }

    private void Update()
    {
        TranslateBehaviour();
        RotationBehaviour();
    }

    private void OnEnable()
    {
        inputReader.Move += OnMove;
    }

    private void OnDisable()
    {
        inputReader.Move -= OnMove;
        inputReader.DisablePlayerInputActions();
    }

    private void RotationBehaviour() // Ship rotation: (pitch, yaw, roll) x, y, z considering local rotation
    {
        float controlRoll = -config.ShipRoll * _direction.x;
        float controlPitch = -config.ShipPitch * _direction.y;
        Quaternion targetRotation = Quaternion.Euler(controlPitch, 0f, controlRoll);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, Time.deltaTime * config.ShipRotationSpeed);
    }


    private void OnMove(Vector2 move)
    {
        _direction = move;
    }

    private void TranslateBehaviour()
    {
        Vector3 rateChange = _direction * (config.ShipSpeed * Time.deltaTime);
        transform.localPosition = new Vector3(transform.localPosition.x + rateChange.x, transform.localPosition.y + rateChange.y, 0f);
        ClampPlayerPosition(rateChange);
    }

    private void ClampPlayerPosition(Vector3 rateChange) // using the camera probably is a more elegant way to do this.
    {
        Vector3 clampedPosition = transform.localPosition + rateChange;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -config.XClampRange, config.XClampRange);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, -config.YClampRange, config.YClampRange);
        transform.localPosition = new Vector3(clampedPosition.x, clampedPosition.y, transform.localPosition.z);
    }
}