using Enthalpy.Input;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerConfiguration m_config;
    [SerializeField] private PlayerInputReader m_inputReader;

    private Vector2 m_direction;

    private void Start()
    {
        m_inputReader.EnablePlayerInputActions();
    }

    private void Update()
    {
        TranslateBehaviour();
        RotationBehaviour();
    }

    private void OnEnable()
    {
        m_inputReader.Move += OnMove;
    }

    private void OnDisable()
    {
        m_inputReader.Move -= OnMove;
        m_inputReader.DisablePlayerInputActions();
    }

    private void RotationBehaviour() // Ship rotation: (pitch, yaw, roll) x, y, z considering local rotation
    {
        float controlRoll = -m_config.ShipRoll * m_direction.x;
        float controlPitch = -m_config.ShipPitch * m_direction.y;
        Quaternion targetRotation = Quaternion.Euler(controlPitch, 0f, controlRoll);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, Time.deltaTime * m_config.ShipRotationSpeed);
    }


    private void OnMove(Vector2 move)
    {
        m_direction = move;
    }

    private void TranslateBehaviour()
    {
        Vector3 rateChange = m_direction * (m_config.ShipSpeed * Time.deltaTime);
        transform.localPosition = new Vector3(transform.localPosition.x + rateChange.x, transform.localPosition.y + rateChange.y, 0f);
        ClampPlayerPosition(rateChange);
    }

    private void ClampPlayerPosition(Vector3 rateChange) // using the camera probably is a more elegant way to do this.
    {
        Vector3 clampedPosition = transform.localPosition + rateChange;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -m_config.XClampRange, m_config.XClampRange);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, -m_config.YClampRange, m_config.YClampRange);
        transform.localPosition = new Vector3(clampedPosition.x, clampedPosition.y, transform.localPosition.z);
    }
}
