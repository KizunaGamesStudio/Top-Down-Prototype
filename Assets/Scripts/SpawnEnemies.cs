using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{

    public GameObject[] spawnObjects;


    public int numberOfEnemiesToSpawn = 10; // Number of enemies to spawn
    public float spawnIntervalMin = 1.0f; // Minimum time between spawns
    public float spawnIntervalMax = 3.0f; // Maximum time between spawns

    private bool isSpawning = false;

    // Start is called before the first frame update
    void Start()
    {


        isSpawning = true;
        StartCoroutine(SpawnEnemiesCount());



    }

    IEnumerator SpawnEnemiesCount()
    {
        for (int i = 0; i < numberOfEnemiesToSpawn; i++)
        {
            if (isSpawning)
            {
                SpawnRandomObject();
                float spawnInterval = Random.Range(spawnIntervalMin, spawnIntervalMax);
                yield return new WaitForSeconds(spawnInterval);
            }
            else
            {
                yield break; // Exit the coroutine if spawning is stopped
            }
        }

        isSpawning = false; // Stop spawning after the specified number of enemies are spawned
    }

    // Update is called once per frame
    void Update()
    {


    }




    void SpawnRandomObject()
    {
        int randomIndex = Random.Range(0, spawnObjects.Length); // Get a random index from the array
        GameObject objectToSpawn = spawnObjects[randomIndex]; // Get the GameObject at the random index

        float randomX, randomY;

        // Randomize the spawning position outside the camera's bounds
        int randomSide = Random.Range(0, 3); // 0: left, 1: up, 2: right

        switch (randomSide)
        {
            case 0: // Left side
                randomX = CameraBounds.instance.GetMinBounds().x - 1.0f; // Spawn slightly to the left of the camera
                randomY = Random.Range(CameraBounds.instance.GetMinBounds().y, CameraBounds.instance.GetMaxBounds().y);
                break;
            case 1: // Up (top) side
                randomX = Random.Range(CameraBounds.instance.GetMinBounds().x, CameraBounds.instance.GetMaxBounds().x);
                randomY = CameraBounds.instance.GetMaxBounds().y + 1.0f; // Spawn slightly above the camera's top boundary
                break;
            case 2: // Right side
                randomX = CameraBounds.instance.GetMaxBounds().x + 1.0f; // Spawn slightly to the right of the camera
                randomY = Random.Range(CameraBounds.instance.GetMinBounds().y, CameraBounds.instance.GetMaxBounds().y);
                break;
            default:
                randomX = 0f;
                randomY = 0f;
                break;
        }

        Vector2 randomPosition = new Vector2(randomX, randomY);
        Instantiate(objectToSpawn, randomPosition, Quaternion.identity);
    }

    // Optionally, you can add a method to stop spawning prematurely
    public void StopSpawning()
    {
        isSpawning = false;
    }
}



