using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private ParticleSystem m_deathEffect;
    [SerializeField] private EnemyConfiguration m_enemyConfiguration;

    private ScoreManager m_scoreManager;
    private float m_currentHealth;
    private void Start()
    {
        m_currentHealth = m_enemyConfiguration.Health;
        m_scoreManager = FindFirstObjectByType<ScoreManager>();
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        m_currentHealth--;
        if (m_currentHealth <= 0)
        {
            m_scoreManager.AddScore(m_enemyConfiguration.Points);
            Instantiate(m_deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
