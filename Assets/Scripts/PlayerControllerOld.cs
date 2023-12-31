using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerControllerOld : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust as needed

    private Camera mainCamera;
    private float playerWidth, playerHeight;
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpedd = 10;
    private Transform aimTransform;
    public float bulletSpeed = 30f;



    // Start is called before the first frame update
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        mainCamera = Camera.main;
        aimTransform = transform.Find("BulletSpawnPoint");


        // Assuming the player has a SpriteRenderer component
        SpriteRenderer playerSprite = GetComponent<SpriteRenderer>();
        playerWidth = playerSprite.bounds.extents.x;
        playerHeight = playerSprite.bounds.extents.y;
    }
    // Update is called once per frame
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



        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 aimDirection = (mousePosition - transform.position).normalized;

        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.rotation = Quaternion.Euler(0f, 0f, angle);

        if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            ShootBullet();
        }


  


    }

    void ShootBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        // Set the velocity based on the direction the bullet should travel
        rb.velocity = bulletSpawnPoint.up * bulletSpeed;
    }

}
