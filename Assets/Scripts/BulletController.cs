using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            // Deal damage to the enemy or destroy it
            Destroy(other.gameObject); // For example, destroy the enemy
            Destroy(gameObject); // Destroy the bullet


          
        }
        Debug.Log("le dispare al enemigo");
    }
}
