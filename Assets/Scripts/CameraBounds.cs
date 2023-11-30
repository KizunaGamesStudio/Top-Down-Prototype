using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CameraBounds : MonoBehaviour
{
    public static CameraBounds instance;

    private Camera mainCamera;
    private float cameraHeight;
    private float cameraWidth;


    private bool isMoving = false;
    private Vector3 targetPosition;
    private float moveSpeed = 2.0f; // Adjust the speed as needed


    void Awake()
    {
        instance = this;
        mainCamera = Camera.main;

        cameraHeight = mainCamera.orthographicSize;
        cameraWidth = cameraHeight * mainCamera.aspect;

        

}


private void Update()
    {
        //nextLevel();
      
        if (isMoving)
        {
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, targetPosition, Time.deltaTime * moveSpeed);

            // Check if the camera has reached the target position with a small threshold
            if (Vector3.Distance(mainCamera.transform.position, targetPosition) < 0.01f)
            {
                // Set the camera's position to the exact target position
                mainCamera.transform.position = targetPosition;
                isMoving = false;
            }
        }
    }
    public Vector2 GetMinBounds()
    {
        return new Vector2(transform.position.x - cameraWidth, transform.position.y - cameraHeight);
    }

    public Vector2 GetMaxBounds()
    {
        return new Vector2(transform.position.x + cameraWidth, transform.position.y + cameraHeight);
    }

    public Vector2 GetRandomPositionAboveCamera()
    {
        Vector2 maxBounds = GetMaxBounds();
        float randomX = Random.Range(maxBounds.x, maxBounds.y);
        float randomY = maxBounds.y + cameraHeight * 0.5f; // Spawn slightly above the camera's top boundary

        // Generate position above the camera view
        Vector2 randomPosition = new Vector2(randomX, randomY);
        return randomPosition;
    }


  
    private void nextLevel()
    {
        if (!isMoving)
        {
            targetPosition = mainCamera.transform.position + Vector3.up * 4.0f;
            isMoving = true;
        }
    }

}
