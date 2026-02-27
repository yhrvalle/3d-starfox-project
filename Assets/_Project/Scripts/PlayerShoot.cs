using Enthalpy.Input;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private PlayerInputReader inputReader;
    [SerializeField] private ParticleSystem laser;

    private bool _fireInput;

    private void Start()
    {
        inputReader.EnablePlayerInputActions();
    }

    private void Update()
    {
        ProcessFiring();
    }

    private void OnEnable()
    {
        inputReader.Fire += OnFire;
    }

    private void OnDisable()
    {
        inputReader.Fire -= OnFire;
        inputReader.DisablePlayerInputActions();
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
}