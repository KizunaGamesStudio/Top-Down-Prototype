using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{

    public GameObject[] spawnObjects;

    private float xBound = 8f;
    private float startDelay = 1.0f;

    // Start is called before the first frame update
    void Start()
    {

        float spawnInterval = Random.Range(1, 3);
        InvokeRepeating("SpawnRandomObject", startDelay, spawnInterval);
        

    }

    // Update is called once per frame
    void Update()
    {
      
    }




    void SpawnRandomObject()
    {
        int randomIndex = Random.Range(0, spawnObjects.Length); // Get a random index from the array
        GameObject objectToSpawn = spawnObjects[randomIndex]; // Get the GameObject at the random index

        float randomX = Random.Range(-xBound, xBound); // Random X within camera width (both positive and negative)
        float randomY = CameraBounds.instance.GetMaxBounds().y + CameraBounds.instance.GetMaxBounds().x * 0.5f; // Spawn slightly above the camera's top boundary

        Vector2 randomPosition = new Vector2(randomX, randomY);
        Instantiate(objectToSpawn, randomPosition, Quaternion.identity);
    }


}



