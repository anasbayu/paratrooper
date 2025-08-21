using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float lifetime = 5f;
    [SerializeField] private int damage = 10;
    [SerializeField] private float explosionRadius = 5f;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody component is missing on the projectile.");
            return;
        }
        rb.linearVelocity = transform.forward * speed;
        Destroy(gameObject, lifetime); // Destroy the projectile after a certain time
    }
    
    public void InitializeProjectile(int damage)
    {
        this.damage = damage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            // AoE damage
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, explosionRadius);
            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.CompareTag("Enemy"))
                {
                    hitCollider.GetComponent<EnemyHealth>()?.TakeDamage(damage);
                }
            }

            // other.GetComponent<EnemyHealth>()?.TakeDamage(damage); // Deal damage to the enemy
            Destroy(gameObject); // Destroy the projectile on hit
        }
    }
}
