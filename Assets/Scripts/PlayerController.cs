using System.Collections;
using System.Collections.Generic;
using Assets.HeroEditor4D.Common.Scripts.CharacterScripts;
using Assets.HeroEditor4D.Common.Scripts.Enums;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    private float bulletSpeed = 15f;
    public GameObject bulletPrefab;

    // Update is called once per frame
    void Update()
    {
        //Shoot on mouse click and on space key down
        if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Shoot();
            //RotatePlayer();
        }
    }


    

    void Shoot(){
        
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		Vector2 direction = (Vector2)((mousePosition - transform.position));
		direction.Normalize ();

		// Creates the bullet locally
		GameObject bullet = (GameObject)Instantiate (
			                    bulletPrefab,
								transform.position + (Vector3)( direction * 0.5f),
			                    Quaternion.identity);

		// Adds velocity to the bullet
		bullet.GetComponent<Rigidbody2D> ().velocity = direction * bulletSpeed;
    }

    
}
