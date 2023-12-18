using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{

    public GameObject[] spawnObjects;
    public GameObject[] spawnObjectsSecond;


    LevelDesign LevelDesignScript;


    //public int numberOfEnemiesToSpawn = 10; // Number of enemies to spawn
    public float spawnIntervalMin = 5.0f; // Minimum time between spawns
    public float spawnIntervalMax = 8.0f; // Maximum time between spawns

    public bool isSpawning = false;
    public int amountOfRoundOfEnemies = 1;
    public int numberEnemiesToSpawn = 2;

    // Start is called before the first frame update
    void Start()
    {
        GameObject levelDesingObject = GameObject.Find("GameManager");
        LevelDesignScript = levelDesingObject.GetComponent<LevelDesign>();

        isSpawning = true;
        InvokeRepeating("SpawnEnemiesCount", 0.2f, 05.0f);

    }

    public void SpawnEnemiesCount()
    {

        if (isSpawning)

        {
            for (int i = 0; i < numberEnemiesToSpawn; i++) 
            {
                if (LevelDesignScript.numberOfLevels <= 2) {
                    SpawnRandomObjectfirstLevel();
                    float spawnInterval = Random.Range(spawnIntervalMin, spawnIntervalMax);
                } else if (LevelDesignScript.numberOfLevels >= 2 )
                {
                    SpawnRandomObjectSecondLevel();
                    float spawnInterval = Random.Range(spawnIntervalMin, spawnIntervalMax);

                } else if (LevelDesignScript.numberOfLevels == 40)
                {
                    isSpawning = false;
                }

            }
           
            amountOfRoundOfEnemies++;

        }


    }

    // Update is called once per frame
    void Update()
    {

    
    }





    void SpawnRandomObjectfirstLevel()
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

    void SpawnRandomObjectSecondLevel()
    {
        int randomIndex = Random.Range(0, spawnObjectsSecond.Length); // Get a random index from the array
        GameObject objectToSpawn = spawnObjectsSecond[randomIndex]; // Get the GameObject at the random index

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



