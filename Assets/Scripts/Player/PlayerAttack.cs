using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    public static PlayerAttack Instance { get; private set; }
    public GameObject projectilePrefab;
    public Transform spawnPoint;
    [SerializeField] private float attackDelay = 0.5f; // Delay between attacks

    public Slider reloadBar;

    private float lastAttackTime = -Mathf.Infinity;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (reloadBar != null)
        {
            float timeSinceLastAttack = Time.time - lastAttackTime;
            float progress = Mathf.Clamp01(timeSinceLastAttack / attackDelay);
            reloadBar.value = progress;
        }
    }

    public void Attack()
    {
        if (Time.time >= lastAttackTime + attackDelay)
        {
            FireProjectile();
            lastAttackTime = Time.time;
        }
    }

    // StopAttack is no longer needed with cooldown approach, but kept for compatibility
    public void StopAttack() { }

    private void FireProjectile()
    {
        // Play SFX.
        AudioManager.Instance.PlayOneShoot(FMODEvents.Instance.FireSFX, spawnPoint.position);

        GameObject projectile = Instantiate(projectilePrefab, spawnPoint.position, spawnPoint.rotation);
        projectile.GetComponent<Projectile>().InitializeProjectile(10); // Initialize projectile with damage
    }
}
