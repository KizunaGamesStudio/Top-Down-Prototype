using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAimWeapon : MonoBehaviour
{

    public GameObject bulletPrefab; // Assign your bullet prefab in the Inspector
    public Transform bulletSpawnPoint; // Assign the spawn point for bullets

    private Camera mainCamera;
    private Transform aimTransform;
    private float speed = 25f;

    private void Awake()
    {
        mainCamera = Camera.main;
        aimTransform = transform.Find("Aim");
    }

    void Update()
    {
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 aimDirection = (mousePosition - transform.position).normalized;

        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, angle);

        if (Input.GetMouseButtonDown(0)) // Change the number for a different mouse button
        {
            Shoot(aimDirection);
        }
    }

    void Shoot(Vector3 direction)
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        // Set the velocity based on the aim direction and desired bullet speed
        rb.velocity = direction * speed; // Modify speed as needed
    }



}


