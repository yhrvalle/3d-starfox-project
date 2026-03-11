using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private ParticleSystem m_explosionEffect;
    private void OnTriggerEnter(Collider other)
    {
        Instantiate(m_explosionEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }



}
