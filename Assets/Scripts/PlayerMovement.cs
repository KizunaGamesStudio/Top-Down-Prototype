using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust as needed

    private Camera mainCamera;
    private float playerWidth, playerHeight;

    void Start()
    {
        mainCamera = Camera.main;

        // Assuming the player has a SpriteRenderer component
        SpriteRenderer playerSprite = GetComponent<SpriteRenderer>();
        playerWidth = playerSprite.bounds.extents.x;
        playerHeight = playerSprite.bounds.extents.y;
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f) * moveSpeed * Time.deltaTime;
        Vector3 newPosition = transform.position + movement;

        float distance = newPosition.z - mainCamera.transform.position.z;
        float leftBound = mainCamera.ScreenToWorldPoint(new Vector3(0, 0, distance)).x + playerWidth;
        float rightBound = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0, distance)).x - playerWidth;
        float bottomBound = mainCamera.ScreenToWorldPoint(new Vector3(0, 0, distance)).y + playerHeight;
        float topBound = mainCamera.ScreenToWorldPoint(new Vector3(0, Screen.height, distance)).y - playerHeight;

        newPosition.x = Mathf.Clamp(newPosition.x, leftBound, rightBound);
        newPosition.y = Mathf.Clamp(newPosition.y, bottomBound, topBound);

        transform.position = newPosition;
    }
}
