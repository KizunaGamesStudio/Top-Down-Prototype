using System.Collections;
using System.Collections.Generic;
using Assets.HeroEditor4D.Common.Scripts.CharacterScripts;
using Assets.HeroEditor4D.Common.Scripts.Enums;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public Character4D Character;


    [SerializeField] private float health, maxHealth;
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
        StartCoroutine(ChangeColor());

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }


    IEnumerator ChangeColor()
    {
        SpriteRenderer enemySpriteRenderer = GetComponent<SpriteRenderer>();

        // Convert hexadecimal color value to Color object
        Color hexColor = HexToColor("#F89090"); // Replace "#FF0000" with your hexadecimal color value
        
        //Get Original color
        Color originalColor = enemySpriteRenderer.color;

        // Set the enemy's color to the hexadecimal value
        enemySpriteRenderer.color = hexColor;

        yield return new WaitForSeconds(0.1f);
        enemySpriteRenderer.color = originalColor; // Return to original color
    }

    Color HexToColor(string hex)
    {
        Color color = new Color();
        ColorUtility.TryParseHtmlString(hex, out color);
        return color;
    }



  
}
