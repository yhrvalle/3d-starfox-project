using Enthalpy.Input;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private PlayerInputReader inputReader;

    private bool _fireInput;

    private void Start()
    {
        inputReader.EnablePlayerInputActions();
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
        Debug.Log("Fire Input: " + _fireInput);
    }
}