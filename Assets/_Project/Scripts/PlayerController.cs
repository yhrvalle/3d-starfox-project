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

    private void OnEnable()
    {
        playerInputReader.Move += OnMove;
    }

    private void OnDisable()
    {
        playerInputReader.Move -= OnMove;
    }

    private void OnMove(Vector2 move)
    {
        _direction = move;
        Debug.Log(_direction * playerConfig.ShipSpeed);
    }
}