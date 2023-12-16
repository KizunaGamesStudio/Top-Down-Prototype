using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DetectCollisions : MonoBehaviour
{

    [SerializeField] public bool isFollowing = false;
    private Camera mainCamera;


    [SerializeField] FloatingHealthBar healthBar;
    [SerializeField] float health, maxHealth;


    // Start is called before the first frame update
    void Start()
    {

        health = maxHealth;
        healthBar = mainCamera.GetComponentInChildren<FloatingHealthBar>();
        healthBar.UpdateHealthBar(health, maxHealth);

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        healthBar.UpdateHealthBar(health, maxHealth);
  

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }



    void reStartGame()
    {

        Debug.Log("Game over");

        // Get the current scene's name
        string currentSceneName = SceneManager.GetActiveScene().name;

        // Reload the current scene
        SceneManager.LoadScene("MainScene");



    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(1);


            Debug.Log("chocaste un enemigo!");
            //reStartGame();
        }
    }




    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("FinalLevel"))
        {
            isFollowing = true; // Start following the player upon collision with the empty object
        }
    }

}
