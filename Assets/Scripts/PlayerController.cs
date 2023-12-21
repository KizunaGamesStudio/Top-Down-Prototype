using System.Collections;
using System.Collections.Generic;
using Assets.HeroEditor4D.Common.Scripts.CharacterScripts;
using Assets.HeroEditor4D.Common.Scripts.Enums;
using UnityEngine;
using Assets.HeroEditor4D.Common.Scripts.ExampleScripts;

public class PlayerController : MonoBehaviour
{


   

    Shoot shootScript;


    // Update is called once per frame
    void Update()
    {
        //Shoot on mouse click and on space key down
        if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            shootScript.ShootProjectile();
            //RotatePlayer();
        }
    }


    

    void Shoot(){
    }

  
}
