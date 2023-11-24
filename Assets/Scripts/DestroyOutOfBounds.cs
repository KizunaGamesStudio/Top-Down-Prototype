using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{

    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

        // If an object goes past the camera's view, remove that object
        Vector3 viewportPos = mainCamera.WorldToViewportPoint(transform.position);

        if (IsOutsideViewport(viewportPos))
        {
            HandleOutOfBounds();
        }
    }

    bool IsOutsideViewport(Vector3 viewportPos)
    {
        return viewportPos.x < 0 || viewportPos.x > 1 || viewportPos.y < 0 || viewportPos.y > 1;
    }

    void HandleOutOfBounds()
    {
        // Add specific handling for objects moving outside the camera view
        // For example, destroy the object if it's outside the screen
        Destroy(gameObject);
    }

}
    

