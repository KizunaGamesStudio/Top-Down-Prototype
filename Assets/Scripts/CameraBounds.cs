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
}
