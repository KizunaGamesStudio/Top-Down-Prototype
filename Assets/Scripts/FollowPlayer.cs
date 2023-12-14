using System.Collections;
using System.Collections.Generic;
using Assets.HeroEditor4D.Common.Scripts.CharacterScripts;
using Assets.HeroEditor4D.Common.Scripts.Enums;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

   public float movementSpeed = 2.0f;
    public float changeBehaviorCooldown = 2.0f; // Time in seconds for random movement
    private Transform player;
    private bool isCollided = false;
    private float behaviorTimer = 0.0f;
    private Vector2 randomDirection; // Store the current random direction
    public Character4D Character;
 
  

    // setState activa la animacion
    // setDirection activa hacia donde ve el personaje

    void Start()        

    {

    
        Character.AnimationManager.SetState(CharacterState.Run);

      
         Character.SetDirection(Vector2.down);
       
        player = GameObject.FindWithTag("Player").transform;




        if (player == null)
        {
            Debug.LogError("Player not found. Make sure the player has the 'Player' tag.");
        }
    }

    void Update()
    {


        if (!isCollided && player != null )
        {
            FollowPlayerMovement();
         
        }
        else
        {
            // If collided, change behavior for a certain cooldown period
            behaviorTimer += Time.deltaTime;

            if (behaviorTimer < changeBehaviorCooldown)
            {
                MoveRandomly();
            }
            else
            {
                isCollided = false;
                behaviorTimer = 0.0f;
            }
        }
    }

    void FollowPlayerMovement()
    {
    
        Vector3 direction = player.position - transform.position;
        direction.Normalize();

        //transform.position += direction * movementSpeed * Time.deltaTime;
       // Character.SetDirection(ConvertTo2D(direction)); // Pass the direction to the character script


        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(0f, 0f, angle);
        Character.transform.position += (Vector3)direction.normalized * movementSpeed * Time.deltaTime;
        // Pass the direction to the character script
        //Character.SetDirection(direction);


        // Check movement direction
        bool isMovingRight = direction.x > 0f;
        bool isMovingLeft = direction.x < 0f;
        bool isMovingUp = direction.y > 0f;
        bool isMovingDown = direction.y < 0f;

        if (isMovingRight)
        {
            // Perform actions when the character is moving right
            Character.SetDirection(Vector2.right);
            // Add your logic here
        }
        else if (isMovingLeft)
        {
            // Perform actions when the character is moving left
          Character.SetDirection(Vector2.left);

            // Add your logic here
        }

        if (isMovingUp)
        {
            // Perform actions when the character is moving up
            Character.SetDirection(Vector2.up);

            // Add your logic here
        }
        else if (isMovingDown)
        {
            // Perform actions when the character is moving down
            Character.SetDirection(Vector2.down);

            // Add your logic here
        }
    }



 
    void MoveRandomly()
    {
        // Move in the current random direction
        transform.position += (Vector3)randomDirection * movementSpeed * Time.deltaTime;

        // Calculate angle for rotation (optional)
        float angle = Mathf.Atan2(randomDirection.y, randomDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ObjectsColliders"))
        {
            isCollided = true;
            // Set a new random direction upon collision
            randomDirection = Random.insideUnitCircle.normalized;


        }
    }
}