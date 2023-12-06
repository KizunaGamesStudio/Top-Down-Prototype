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
            SpriteRenderer enemySpriteRenderer = collision.gameObject.GetComponent<SpriteRenderer>();

            if (enemyControllerScript != null)
            {

                // Convert hexadecimal color value to Color object
                Color hexColor = HexToColor("#F89090"); // Replace "#FF0000" with your hexadecimal color value

                // Set the enemy's color to the hexadecimal value
                enemySpriteRenderer.color = hexColor;
            

                enemyControllerScript.TakeDamage(1);
                Destroy(gameObject); // Destroy the bullet after hitting the enemy
            }
        }

        if (collision.gameObject.CompareTag("ObjectsColliders"))
        {
            Destroy(gameObject);
          


        }



        Color HexToColor(string hex)
        {
            Color color = new Color();
            ColorUtility.TryParseHtmlString(hex, out color);
            return color;
        }
    }
}
