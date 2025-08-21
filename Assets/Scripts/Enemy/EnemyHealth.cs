using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    private int maxHealth;
    private int currentHealth;
    private int scoreValue; // Score to add when enemy dies
    [SerializeField] Slider healthBar;

    private void Start()
    {
        Enemy tmpEnemyConfig = GetComponent<Enemy>();
        maxHealth = tmpEnemyConfig.health;
        scoreValue = tmpEnemyConfig.scoreValue;

        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.value = currentHealth;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
    }

    private void Die()
    {
        ScoreManager.Instance.AddScore(scoreValue); // Add score on enemy death
        Destroy(gameObject);
    }
}
