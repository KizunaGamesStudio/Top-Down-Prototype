using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDesign : MonoBehaviour
{
    SpawnEnemies SpawnEnemiesScript;
    private float delayTimer = 1f; // 5-second delay
    private float elapsedTime = 0f;
    private bool hasFunctionExecuted = false;
    public bool isEnemiesinTheScene = false;
    public int amountOfEnemies = 2;
    public float checkInterval = 20f; // Check interval in seconds
    public bool nextLevel = false;
    public int amountOfRoundOfEnemies = 0;



    CameraBounds cameraBoundsScript;

    // Start is called before the first frame update
    void Start()
    {
     



        GameObject spawnEnemiesObject = GameObject.FindGameObjectWithTag("SpawnEnemies");
       
       SpawnEnemiesScript = spawnEnemiesObject.GetComponent<SpawnEnemies>();



        StartCoroutine(SpawnEnemiesScript.SpawnEnemiesCount(amountOfEnemies));
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
                // StartCoroutine(SpawnEnemiesScript.SpawnEnemiesCount(amountOfEnemies));
                cameraBoundsScript.nextLevel();
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
        GameObject cameraBoundsObject = GameObject.FindGameObjectWithTag("MainCamera");
        cameraBoundsScript = cameraBoundsObject.GetComponent<CameraBounds>();
    }



    IEnumerator CheckForEnemiesRoutine()
    {
        while (true) // Infinite loop to continuously check
        {
            yield return new WaitForSeconds(checkInterval); // Wait for the specified interval

            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

            if (enemies.Length == 0 && isEnemiesinTheScene && amountOfRoundOfEnemies > 2)
            {
                isEnemiesinTheScene = false;
                Debug.Log("No enemies found in the scene.");

                cameraBoundsScript.nextLevel();
                nextLevel = true;
                amountOfRoundOfEnemies = 0;

            } 

            else if (enemies.Length > 0 && !isEnemiesinTheScene)
            {
                isEnemiesinTheScene = true;
                Debug.Log("Enemies found in the scene.");
                nextLevel = false;
                // Perform actions when enemies are found
           
            
            }
            StartCoroutine(SpawnEnemiesScript.SpawnEnemiesCount(amountOfEnemies));
            amountOfRoundOfEnemies++;
        }
    }



 
}

