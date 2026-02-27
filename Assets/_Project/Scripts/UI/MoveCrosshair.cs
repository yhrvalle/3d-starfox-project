using Enthalpy.Input;
using UnityEngine;

public class MoveCrosshair : MonoBehaviour
{
    [SerializeField] private PlayerInputReader inputReader;
    private RectTransform _transform;


    private void Awake()
    {
        _transform = GetComponent<RectTransform>();
    }

    private void Start()
    {
        Cursor.visible = false;
    }

    private void OnEnable()
    {
        inputReader.MPos += OnMousePositionChanged;
    }

    private void OnDisable()
    {
        inputReader.MPos -= OnMousePositionChanged;
    }

    private void OnMousePositionChanged(Vector2 position)
    {
        _transform.position = position;
    }
}