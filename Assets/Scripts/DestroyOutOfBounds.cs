using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{

    private float limitBound = 6;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // If an object goes past the players view in the game, remove that object
        if (transform.position.y > limitBound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.y < -limitBound)
        {
            Debug.Log("Game Over!");

            Destroy(gameObject);

        }
    }
}
