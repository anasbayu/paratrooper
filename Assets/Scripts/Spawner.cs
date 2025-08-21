using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Spawner : MonoBehaviour
{
    public static Spawner Instance;
    public List<GameObject> prefabToSpawn;
    public Transform spawnPointA, spawnPointB;
    public float spawnInterval = 2f;

    private Coroutine spawnCoroutine;

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

    private void Start()
    {
        StartSpawning();
    }

    private IEnumerator SpawnObjectsCo()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnObject();
        }
    }

    private void SpawnObject()
    {
        if (prefabToSpawn.Count == 0) return;
        int randomIndex = Random.Range(0, prefabToSpawn.Count);
        GameObject prefab = prefabToSpawn[randomIndex];
        Transform spawnPoint = Random.Range(0, 2) == 0 ? spawnPointA : spawnPointB;
        Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
    }

    public void StopSpawning()
    {
        if (spawnCoroutine != null)
        {
            StopCoroutine(spawnCoroutine);
            spawnCoroutine = null;
        }
    }

    public void StartSpawning()
    {
        if (spawnCoroutine == null)
        {
            spawnCoroutine = StartCoroutine(SpawnObjectsCo());
        }
    }
}
