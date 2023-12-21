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
    private int amountOfEnemies = 10;
    public float checkInterval = 01f; // Check interval in seconds
    public bool nextLevel = false;
    public int numberOfRoundsPerLevel = 3;
    public int numberOfLevels = 0;




    CameraBounds cameraBoundsScript;

    // Start is called before the first frame update
    void Start()
    {
     



        GameObject spawnEnemiesObject = GameObject.FindGameObjectWithTag("SpawnEnemies");
       
       SpawnEnemiesScript = spawnEnemiesObject.GetComponent<SpawnEnemies>();



        //StartCoroutine(SpawnEnemiesScript.SpawnEnemiesCount(amountOfEnemies));
        StartCoroutine(CheckForNextLevel());
      


        //nvokeRepeating("SpawnEnemiesScript.SpawnEnemiesCount", 0.2f, 05.0f);

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
                 //StartCoroutine(SpawnEnemiesScript.SpawnEnemiesCount(amountOfEnemies));
                cameraBoundsScript.nextLevel();
                numberOfLevels++;
                amountOfEnemies = amountOfEnemies + 5;
                //numberOfRoundsPerLevel = numberOfRoundsPerLevel + 1;

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

        CheckForEnemiesRoutine();
        GameObject cameraBoundsObject = GameObject.FindGameObjectWithTag("MainCamera");
        cameraBoundsScript = cameraBoundsObject.GetComponent<CameraBounds>();
        //Debug.Log(isEnemiesinTheScene);
    }



    void  CheckForEnemiesRoutine()
    {
        Debug.Log("entra a la func");
     
      
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            Debug.Log(enemies);
            Debug.Log(isEnemiesinTheScene);

        if (enemies.Length == 0 && isEnemiesinTheScene && SpawnEnemiesScript.amountOfRoundOfEnemies > numberOfRoundsPerLevel)
            {
                isEnemiesinTheScene = false;
                Debug.Log("No enemies found in the scene.");
            Debug.Log("entra a la func parte 2");
            cameraBoundsScript.nextLevel();
                nextLevel = true;
               SpawnEnemiesScript.amountOfRoundOfEnemies = 0;
            SpawnEnemiesScript.isSpawning = true;

            } else if( SpawnEnemiesScript.amountOfRoundOfEnemies > numberOfRoundsPerLevel)
                     {
                         SpawnEnemiesScript.isSpawning = false;
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

