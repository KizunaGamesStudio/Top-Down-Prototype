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
    Rigidbody2D rb;
    public float pushForce = 5f;





    // setState activa la animacion
    // setDirection activa hacia donde ve el personaje

    void Start()        

    {

    
        Character.AnimationManager.SetState(CharacterState.Run);

      
        Character.SetDirection(Vector2.down);
       
        player = GameObject.FindWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("AttackPlayer", 1, 1);

        if (player == null)
        {
            Debug.LogError("Player not found. Make sure the player has the 'Player' tag.");
        }


    }

    void Update()
    {

        if (player != null)
        {
            Vector3 direction = player.position - transform.position;
            direction.Normalize();
            transform.Translate(direction * movementSpeed * Time.deltaTime);
        }
    

        if (!isCollided && player != null )
        {
            FollowPlayerMovement();
         
        } else{
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

    public void FollowPlayerMovement(){
        
        if (player != null)
        {
            Vector3 direction = player.position - transform.position;
            direction.Normalize();
            Character.transform.position += (Vector3)direction.normalized * movementSpeed * Time.deltaTime;


            Vector3 playerPosition = player.position;
            Vector3 enemyPosition = transform.position;

            Vector3 directionToPlayer = player.position - transform.position;

            // Check the relative position
            float dotProduct = Vector3.Dot(directionToPlayer.normalized, transform.up);

            if (Mathf.Abs(directionToPlayer.x) > Mathf.Abs(directionToPlayer.y))
            {
                // Player is more to the left or right
                if (directionToPlayer.x > 0)
                {
                    // Perform actions for the player being on the right
                    Character.SetDirection(Vector2.right);
                }
                else
                {
                    // Perform actions for the player being on the left
                    Character.SetDirection(Vector2.left);
                }
            }
            else
            {
                // Player is more above or below
                if (dotProduct > 0)
                {
                    // Perform actions for the player being above
                    Character.SetDirection(Vector2.up);
                }
                else
                {
                    // Perform actions for the player being below
                    Character.SetDirection(Vector2.down);
                }
            }
        }
    }

    private void AttackPlayer()
    {
        if  (Vector3.Distance(player.position, Character.transform.position) <= 2.0f)
        {
            Character.AnimationManager.Attack();
            PushPlayer();
        

        }
    }


    private void PushPlayer()
    {
        Rigidbody2D playerRigidbody = player.GetComponent<Rigidbody2D>();

        if (playerRigidbody != null)
        {
            // Obtener la dirección desde el enemigo hacia el jugador
            Vector2 pushDirection = (player.position - Character.transform.position).normalized;

            // Aplicar fuerza al jugador en la dirección del empuje
            playerRigidbody.AddForce(pushDirection * pushForce, ForceMode2D.Impulse);
        }
    }
    public void MoveRandomly()
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