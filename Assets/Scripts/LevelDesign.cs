using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDesign : MonoBehaviour
{
    SpawnEnemies SpawnEnemiesScript;
    private float delayTimer = 5f; // 5-second delay
    private float elapsedTime = 0f;
    private bool hasFunctionExecuted = false;
    public bool isEnemiesinTheScene = false;
    public int amountOfEnemies = 2;
    public float checkInterval = 5f; // Check interval in seconds
    bool nextLevel = false;


    private CameraBounds cameraBoundsScript;
    // Start is called before the first frame update
    void Start()
    {

        cameraBoundsScript = GetComponent<CameraBounds>();

        GameObject spawnEnemiesObject = GameObject.FindGameObjectWithTag("SpawnEnemies");
        if (spawnEnemiesObject != null)
        {
            Debug.Log("SpawnEnemies object found!");
            SpawnEnemiesScript = spawnEnemiesObject.GetComponent<SpawnEnemies>();
            // Spawn Enemies
            StartCoroutine(SpawnEnemiesScript.SpawnEnemiesCount(amountOfEnemies));
        }
        else
        {
            Debug.LogError("SpawnEnemies object not found!");
        }

        StartCoroutine(CheckForNextLevel());
        StartCoroutine(CheckForEnemiesRoutine());

    }




    IEnumerator CheckForNextLevel()
    {
        while (true)
        {
            yield return new WaitUntil(() => nextLevel); // Wait until nextLevel becomes true

            // Reset nextLevel to false for the next iteration
            nextLevel = false;

            if (SpawnEnemiesScript != null)
            {
                // Start spawning enemies when nextLevel is true
                StartCoroutine(SpawnEnemiesScript.SpawnEnemiesCount(amountOfEnemies));
            }
            else
            {
                Debug.LogError("SpawnEnemiesScript is null!");
            }

            yield return null; // Wait for the next frame before checking again
        }
    }

 
    // Update is called once per frame
    void Update()
    {

    }



  




    IEnumerator CheckForEnemiesRoutine()
    {
        while (true) // Infinite loop to continuously check
        {
            yield return new WaitForSeconds(checkInterval); // Wait for the specified interval

            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

            if (enemies.Length == 0 && isEnemiesinTheScene)
            {
                isEnemiesinTheScene = false;
                Debug.Log("No enemies found in the scene.");
                cameraBoundsScript.nextLevel();
                 nextLevel = true;


                // Perform actions when no enemies are found
            }
            else if (enemies.Length > 0 && !isEnemiesinTheScene)
            {
                isEnemiesinTheScene = true;
                Debug.Log("Enemies found in the scene.");
                nextLevel = false;
                // Perform actions when enemies are found
            }
        }
    }
}

