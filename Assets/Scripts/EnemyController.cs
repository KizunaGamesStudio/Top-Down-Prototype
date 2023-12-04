using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [SerializeField] float healt, maxHealth = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        healt = maxHealth;
    }



    public void TakeDamage(float damageAmount)
    {
        healt -= damageAmount;

        if (healt <= 0)
        {
            Destroy(gameObject);
        }
    }
  
}
