using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfiguration", menuName = "Scriptable Objects/PlayerConfiguration")]
public class PlayerConfiguration : ScriptableObject
{
    [Header("Rotation Configuration")]
    [SerializeField] private float shipRoll;
    [SerializeField] private float shipPitch;
    [SerializeField] private float shipRotationSpeed;

    [Header("Movement Configuration")]
    [SerializeField] private float shipSpeed;

    [Header("Clamp Configuration")]
    [SerializeField] private float xClampRange;
    [SerializeField] private float yClampRange;

    public float ShipSpeed => shipSpeed;
    public float XClampRange => xClampRange;
    public float YClampRange => yClampRange;

    public float ShipRoll => shipRoll;
    public float ShipPitch => shipPitch;
    public float ShipRotationSpeed => shipRotationSpeed;
}