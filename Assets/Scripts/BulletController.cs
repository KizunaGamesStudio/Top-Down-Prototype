using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
   
    //EnemyController enemyControllerScript;

    void Start()
    {
       // GameObject EnemyControllerObject = GameObject.FindWithTag("Enemy");
       // enemyControllerScript = EnemyControllerObject.GetComponent<EnemyController>();


      


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {

            EnemyController enemyControllerScript = collision.gameObject.GetComponent<EnemyController>();

            if (enemyControllerScript != null)
            {
                enemyControllerScript.TakeDamage(1);
                Destroy(gameObject); // Destroy the bullet after hitting the enemy
            }
        }

        if (collision.gameObject.CompareTag("ObjectsColliders"))
        {
            Destroy(gameObject);
        }

        
    }
}
