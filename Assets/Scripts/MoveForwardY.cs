using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForwardY : MonoBehaviour
{

    public float speed;
    public bool moveFoward = true;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveFoward ? Vector2.up : Vector2.down * speed * Time.deltaTime);
    }
}
