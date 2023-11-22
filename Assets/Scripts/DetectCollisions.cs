using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DetectCollisions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void reStartGame()
    {
      
            Debug.Log("Game over");

            // Get the current scene's name
            string currentSceneName = SceneManager.GetActiveScene().name;

            // Reload the current scene
            SceneManager.LoadScene("SampleScene");


        
    }



    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("chocaste un enemigo!");
            reStartGame();

        }
    }
}