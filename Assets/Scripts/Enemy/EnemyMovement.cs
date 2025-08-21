using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Transform player;
    Rigidbody rb;

    private float speed;

    void Start()
    {
        Enemy tmpEnemyConfig = GetComponent<Enemy>();
        speed = tmpEnemyConfig.speed;

        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (player == null)
        {
            Debug.LogError("Player not found. Make sure the player has the 'Player' tag.");
        }
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody component is missing on the enemy.");
        }
    }


    void FixedUpdate()
    {
        if (player != null && rb != null)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            rb.MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);
        }
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Player"))
        {
            LiveManager.Instance.ReduceLives();
            Destroy(gameObject);
        }
    }
}
