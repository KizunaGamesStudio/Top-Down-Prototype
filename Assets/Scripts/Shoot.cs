using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Shoot : MonoBehaviour
{
    private Camera _mainCamera;
    public GameObject bulletPrefab;
    private float speed = 1.0f;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }


    private void Update()
    {
     
        // Player can shoot with space key or clik
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            shootBall();
        }


    }
    private void shootBall()
    {
        //float horizontalInput = Input.GetAxis("Horizontal");
       // transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);

        Instantiate(bulletPrefab, transform.position, bulletPrefab.transform.rotation);
        
    }




}
