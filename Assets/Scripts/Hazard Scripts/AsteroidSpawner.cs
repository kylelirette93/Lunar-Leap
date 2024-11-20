using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public int asteroidsToSpawn = 30;
    public float spawnRangeX = 20f;
    public float spawnRangeZ = 20f;

    void Start()
    {
        for (int i = 0; i < asteroidsToSpawn; i++)
        {
            SpawnNewAsteroid();
        }
    }

    public void SpawnNewAsteroid()
    {
        Vector3 randomPosition = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 5, Random.Range(-spawnRangeZ, spawnRangeZ));
        Instantiate(asteroidPrefab, randomPosition, Quaternion.identity);
    }
}