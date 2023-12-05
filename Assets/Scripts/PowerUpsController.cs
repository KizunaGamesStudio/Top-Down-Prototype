using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsController : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PowerUpSlowDown"))
        {
            FollowPlayer FollowPlayerScript = collision.gameObject.GetComponent<FollowPlayer>();

            if (FollowPlayerScript != null)
            {
                FollowPlayerScript.movementSpeed = 0.3f; // Set the movement speed directly
                StartCoroutine(RestoreMovementSpeed(FollowPlayerScript)); // Start coroutine to restore movement speed
            }

            Destroy(collision.gameObject); // Destroy the power-up object
        }
    }

    private IEnumerator RestoreMovementSpeed(FollowPlayer followPlayerScript)
    {
        yield return new WaitForSeconds(10.0f); // Wait for 5 seconds

        if (followPlayerScript != null)
        {
            followPlayerScript.movementSpeed = 2.0f; // Restore the original movement speed
        }
    }

}
