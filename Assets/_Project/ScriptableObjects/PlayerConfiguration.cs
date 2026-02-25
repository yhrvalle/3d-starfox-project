using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfiguration", menuName = "Scriptable Objects/PlayerConfiguration")]
public class PlayerConfiguration : ScriptableObject
{
    [Header("Player Ship Configuration")]
    [SerializeField] private float shipSpeed;

    public float ShipSpeed => shipSpeed;
}