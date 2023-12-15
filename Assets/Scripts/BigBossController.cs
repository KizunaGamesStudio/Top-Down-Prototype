using System.Collections;
using System.Collections.Generic;
using Assets.HeroEditor4D.Common.Scripts.CharacterScripts;
using Assets.HeroEditor4D.Common.Scripts.Enums;
using UnityEngine;

public class BigBossController : MonoBehaviour
{

    DetectCollisions detectCollisionsScripts;
    public FollowPlayer FollowPlayerScript;
    public Character4D Character;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        detectCollisionsScripts = player.GetComponent<DetectCollisions>();

        Character.AnimationManager.SetState(CharacterState.Run);


        Character.SetDirection(Vector2.down);

    }

    // Update is called once per frame
    void Update()
    {
        if (detectCollisionsScripts.isFollowing) 
        {
            FollowPlayerScript.gameObject.SetActive(true);
            FollowPlayerScript.enabled = true;
        }
    }
}
