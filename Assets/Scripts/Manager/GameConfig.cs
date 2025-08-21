using UnityEngine;
using System.Collections;

public class GameConfig : MonoBehaviour
{
    public static GameConfig Instance { get; private set; }

    [Header("Game Settings")]
    [SerializeField] private float spawnInterval = 1f;

    [Header("Player Settings")]
    [SerializeField] private int playerLives = 3;



    public float SpawnInterval => spawnInterval;
    public int PlayerLives => playerLives;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // Ensure only one instance exists
        }
    }

}
