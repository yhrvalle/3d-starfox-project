using Enthalpy.Input;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private PlayerInputReader inputReader;
    [SerializeField] private ParticleSystem laser;
    [SerializeField] private Transform targetPoint;
    [SerializeField] private float targetPointDistance;

    private Camera _mainCamera;
    private bool _fireInput;
    private Vector2 _cursorPosition;


    private void Start()
    {
        _mainCamera = Camera.main;
        inputReader.EnablePlayerInputActions();
    }

    private void Update()
    {
        ProcessFiring();
        ProcessTargetPointMovement();
        ProcessLaserRotation();
    }

    private void OnEnable()
    {
        inputReader.Fire += OnFire;
        inputReader.MPos += OnCursorPositionChanged;
    }

    private void OnDisable()
    {
        inputReader.Fire -= OnFire;
        inputReader.MPos -= OnCursorPositionChanged;
        inputReader.DisablePlayerInputActions();
    }

    private void OnCursorPositionChanged(Vector2 position)
    {
        _cursorPosition = position;
    }

    private void OnFire(bool input)
    {
        _fireInput = input;
    }

    private void ProcessFiring()
    {
        ParticleSystem.EmissionModule emission = laser.emission;
        emission.enabled = _fireInput;
    }

    private void ProcessTargetPointMovement()
    {
        Vector3 targetPointPosition = new Vector3(_cursorPosition.x, _cursorPosition.y, targetPointDistance);
        targetPoint.position = _mainCamera.ScreenToWorldPoint(targetPointPosition);
    }

    private void ProcessLaserRotation()
    {
        Vector3 targetVector = targetPoint.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(targetVector);
        laser.transform.rotation = targetRotation;
    }
}