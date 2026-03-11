using Enthalpy.Input;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class MoveCrosshair : MonoBehaviour
{
    [SerializeField] private PlayerInputReader m_inputReader;
    private RectTransform m_transform;


    private void Awake()
    {
        m_transform = GetComponent<RectTransform>();
    }

    private void Start()
    {
        Cursor.visible = false;
    }

    private void OnEnable()
    {
        m_inputReader.MPos += OnMousePositionChanged;
    }

    private void OnDisable()
    {
        m_inputReader.MPos -= OnMousePositionChanged;
    }

    private void OnMousePositionChanged(Vector2 position)
    {
        m_transform.position = position;
    }
}
