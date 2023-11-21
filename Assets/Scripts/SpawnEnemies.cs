using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{

    public GameObject[] spawnObject;

    private float xBound = 8f;
    private float startDelay = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        float spawnInterval = Random.Range(3, 5);
        InvokeRepeating("Spawn", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
      
    }




    void Spawn()
    {

        float spawnPosYInterval = Random.Range(1, 7);
        Vector2 spawnPos = new Vector2(Random.Range(-xBound, xBound), spawnPosYInterval);

        int enemiesIndex = Random.Range(0, spawnObject.Length);
        // instantiate ball at random spawn location
        Instantiate(spawnObject[enemiesIndex], spawnPos, spawnObject[enemiesIndex].transform.rotation);
    }

}
