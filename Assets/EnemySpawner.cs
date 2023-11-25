using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 2f; // Time interval between enemy spawns
    public float xMin = -7f; // Minimum x position for spawning enemies
    public float xMax = 7f; // Maximum x position for spawning enemies
    public float yMin = -3f; // Minimum y position for spawning enemies
    public float yMax = 3f; // Maximum y position for spawning enemies

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
    }

    void SpawnEnemy()
    {
        float randomX = Random.Range(xMin, xMax);
        float randomY = Random.Range(yMin, yMax);

        Vector3 spawnPosition = new Vector3(randomX, randomY, 0f);
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
