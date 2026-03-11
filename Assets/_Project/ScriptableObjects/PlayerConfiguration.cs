using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfiguration", menuName = "Scriptable Objects/PlayerConfiguration")]
public class PlayerConfiguration : ScriptableObject
{
    [Header("Rotation Configuration")]
    [SerializeField] private float m_shipRoll;

    [SerializeField] private float m_shipPitch;
    [SerializeField] private float m_shipRotationSpeed;

    [Header("Movement Configuration")]
    [SerializeField] private float m_shipSpeed;

    [Header("Clamp Configuration")]
    [SerializeField] private float m_xClampRange;

    [SerializeField] private float m_yClampRange;

    public float ShipSpeed => m_shipSpeed;
    public float XClampRange => m_xClampRange;
    public float YClampRange => m_yClampRange;

    public float ShipRoll => m_shipRoll;
    public float ShipPitch => m_shipPitch;
    public float ShipRotationSpeed => m_shipRotationSpeed;
}
