using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAimWeapon : MonoBehaviour
{

    public GameObject bulletPrefab; // Assign your bullet prefab in the Inspector
    public Transform bulletSpawnPoint; // Assign the spawn point for bullets

    private Camera mainCamera;
    private Transform aimTransform;
    private float speed = 30f;

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

        // Calculate the direction from the player towards the mouse position
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 shootDirection = (mousePosition - bulletSpawnPoint.position).normalized;

        // Incrementa la magnitud del vector de dirección para aumentar la velocidad
        shootDirection *= speed; // Multiplica por un factor mayor para aumentar la velocidad

        // Set the velocity based on the direction and desired bullet speed
        rb.velocity = shootDirection; // Asigna el vector de dirección modificado como velocidad

        rb.AddForce(shootDirection, ForceMode2D.Impulse); // Add force to the bullet

    }





}


