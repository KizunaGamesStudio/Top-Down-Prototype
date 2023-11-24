using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBounds : MonoBehaviour
{
    public static CameraBounds instance;

    private Camera mainCamera;
    private float cameraHeight;
    private float cameraWidth;

    void Awake()
    {
        instance = this;
        mainCamera = Camera.main;

        cameraHeight = mainCamera.orthographicSize;
        cameraWidth = cameraHeight * mainCamera.aspect;
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

}
