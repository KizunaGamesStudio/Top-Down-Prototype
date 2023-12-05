using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [SerializeField] private float health, maxHealth = 3.0f;
    Rigidbody2D rb;
    [SerializeField] FloatingHealthBar HealthBarScript;

    // Start is called before the first frame update
    void Start()
    {
 


        health = maxHealth;
       HealthBarScript.UpdateHealthBar(health, maxHealth);



    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        HealthBarScript = GetComponentInChildren<FloatingHealthBar>();
    }





    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        HealthBarScript.UpdateHealthBar(health, maxHealth);

        if (health <= 0)
        {
            Destroy(gameObject);
           

        }
    }



  
}
