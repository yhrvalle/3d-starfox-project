using PersonalPackage.Input;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerInputReader playerInputReader;
    [SerializeField] private PlayerConfiguration playerConfig;

    private Vector2 _direction;

    private void Start()
    {
        playerInputReader.EnablePlayerInputActions();
    }

    private void Update()
    {
        TranslateBehaviour();
        RotationBehaviour();
    }

    private void OnEnable()
    {
        playerInputReader.Move += OnMove;
    }

    private void OnDisable()
    {
        playerInputReader.Move -= OnMove;
    }

    private void RotationBehaviour() // Ship rotation: (pitch, yaw, roll) x, y, z considering local rotation
    {
        float controlRoll = -playerConfig.ShipRoll * _direction.x;
        float controlPitch = -playerConfig.ShipPitch * _direction.y;
        Quaternion targetRotation = Quaternion.Euler(controlPitch, 0f, controlRoll);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, Time.deltaTime * playerConfig.ShipRotationSpeed);
    }


    private void OnMove(Vector2 move)
    {
        _direction = move;
    }

    private void TranslateBehaviour()
    {
        Vector3 rateChange = _direction * (playerConfig.ShipSpeed * Time.deltaTime);
        transform.localPosition = new Vector3(transform.localPosition.x + rateChange.x, transform.localPosition.y + rateChange.y, 0f);
        ClampPlayerPosition(rateChange);
    }

    private void ClampPlayerPosition(Vector3 rateChange) // using the camera probably is a more elegant way to do this.
    {
        Vector3 clampedPosition = transform.localPosition + rateChange;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -playerConfig.XClampRange, playerConfig.XClampRange);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, -playerConfig.YClampRange, playerConfig.YClampRange);
        transform.localPosition = new Vector3(clampedPosition.x, clampedPosition.y, transform.localPosition.z);
    }
}