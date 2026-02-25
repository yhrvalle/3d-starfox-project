using PersonalPackage.Input;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerInputReader playerInputReader;
    [SerializeField] private PlayerConfiguration playerConfig;
    [SerializeField] private float xClampRange = 5f;
    [SerializeField] private float yClampRange = 5f;

    private Vector2 _direction;

    private void Start()
    {
        playerInputReader.EnablePlayerInputActions();
    }

    private void Update()
    {
        TranslateBehaviour();
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
    }

    private void TranslateBehaviour()
    {
        Vector3 rateChange = _direction * (playerConfig.ShipSpeed * Time.deltaTime);
        transform.Translate(rateChange, Space.Self);
        ClampPlayerPosition(rateChange);
    }

    private void ClampPlayerPosition(Vector3 rateChange) // using the camera probably is a more elegant way to do this.
    {
        Vector3 clampedPosition = transform.localPosition + rateChange;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -xClampRange, xClampRange);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, -yClampRange, yClampRange);
        transform.localPosition = new Vector3(clampedPosition.x, clampedPosition.y, transform.localPosition.z);
    }
}