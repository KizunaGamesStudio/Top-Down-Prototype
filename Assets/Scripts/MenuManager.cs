using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RestarGame()
    {

        Debug.Log("Game over");

        // Get the current scene's name
        string currentSceneName = SceneManager.GetActiveScene().name;

        // Reload the current scene
        SceneManager.LoadScene("MainScene");
    }

    public void StartGame(){
        SceneManager.LoadScene("MainScene");
        // InvokeRepeating("LoadGame", 1.5f, 2);
    }


    public void ExitGame(){
        Application.Quit();
    }

}
