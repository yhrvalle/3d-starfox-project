using UnityEngine;

[CreateAssetMenu(fileName = "EnemyConfiguration", menuName = "Scriptable Objects/EnemyConfiguration")]
public class EnemyConfiguration : ScriptableObject
{
    [SerializeField] private float m_health;
    [SerializeField] private int m_points;

    public float Health => m_health;
    public int Points => m_points;
}
