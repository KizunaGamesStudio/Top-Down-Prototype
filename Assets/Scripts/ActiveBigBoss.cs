using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveBigBoss : MonoBehaviour
{

    public GameObject Boss;
    DetectCollisions detectCollisionsScripts;
    public FollowPlayer FollowPlayerScript;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        detectCollisionsScripts = player.GetComponent<DetectCollisions>();
    }

    // Update is called once per frame
    void Update()
    {

        if (detectCollisionsScripts.isFollowing)
        {
            Boss.SetActive(true);
         
        }

    }
}
