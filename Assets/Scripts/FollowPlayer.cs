using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public float movementSpeed = 2.0f;
    public float changeBehaviorCooldown = 2.0f; // Time in seconds for random movement
    private Transform player;
    private bool isCollided = false;
    private float behaviorTimer = 0.0f;
    private Vector2 randomDirection; // Store the current random direction

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        if (player == null)
        {
            Debug.LogError("Player not found. Make sure the player has the 'Player' tag.");
        }
    }

    void Update()
    {
        if (!isCollided && player != null)
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

        transform.position += direction * movementSpeed * Time.deltaTime;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
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