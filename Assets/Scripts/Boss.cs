using System.Collections;
using System.Collections.Generic;
using Assets.HeroEditor4D.Common.Scripts.CharacterScripts;
using Assets.HeroEditor4D.Common.Scripts.Enums;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public Transform player;

    public bool isFlipped = false;
    public Character4D Character;



    private void Start()
    {
        Character.AnimationManager.SetState(CharacterState.Run);


        Character.SetDirection(Vector2.down);
    }
    public void LookAtPlayer()
    {
        Vector3 direction = player.position - transform.position;
        direction.Normalize();

        //transform.position += direction * movementSpeed * Time.deltaTime;
        // Character.SetDirection(ConvertTo2D(direction)); // Pass the direction to the character script


        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(0f, 0f, angle);
        Character.transform.position += (Vector3)direction.normalized * 2 * Time.deltaTime;
        // Pass the direction to the character script
        //Character.SetDirection(direction);


        // Check movement direction
        bool isMovingRight = direction.x > 0f;
        bool isMovingLeft = direction.x < 0f;
        bool isMovingUp = direction.y > 2f;
        bool isMovingDown = direction.y < -1f;

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

        if (direction.y > 0 && (direction.x < 1) && (direction.x > -1))
        {
            // Perform actions when the character is moving up
            Character.SetDirection(Vector2.up);

            // Add your logic here
        }
        else if (direction.y < 0 && (direction.x < 1) && (direction.x > -1))
        {
            // Perform actions when the character is moving down
            Character.SetDirection(Vector2.down);

            // Add your logic here
        }
    }

}