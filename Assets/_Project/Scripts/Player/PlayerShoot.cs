using Enthalpy.Input;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private PlayerInputReader m_inputReader;
    [SerializeField] private ParticleSystem m_laser;
    [SerializeField] private Transform m_targetPoint;
    [SerializeField] private float m_targetPointDistance;

    private Camera m_mainCamera;
    private bool m_fireInput;
    private Vector2 m_cursorPosition;


    private void Start()
    {
        m_mainCamera = Camera.main;
        m_inputReader.EnablePlayerInputActions();
    }

    private void Update()
    {
        ProcessFiring();
        ProcessTargetPointMovement();
        ProcessLaserRotation();
    }

    private void OnEnable()
    {
        m_inputReader.Fire += OnFire;
        m_inputReader.MPos += OnCursorPositionChanged;
    }

    private void OnDisable()
    {
        m_inputReader.Fire -= OnFire;
        m_inputReader.MPos -= OnCursorPositionChanged;
        m_inputReader.DisablePlayerInputActions();
    }

    private void OnCursorPositionChanged(Vector2 position)
    {
        m_cursorPosition = position;
    }

    private void OnFire(bool input)
    {
        m_fireInput = input;
    }

    private void ProcessFiring()
    {
        ParticleSystem.EmissionModule emission = m_laser.emission;
        emission.enabled = m_fireInput;
    }

    private void ProcessTargetPointMovement()
    {
        Vector3 targetPointPosition = new(m_cursorPosition.x, m_cursorPosition.y, m_targetPointDistance);
        m_targetPoint.position = m_mainCamera.ScreenToWorldPoint(targetPointPosition);
    }

    private void ProcessLaserRotation()
    {
        Vector3 targetVector = m_targetPoint.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(targetVector);
        m_laser.transform.rotation = targetRotation;
    }
}
