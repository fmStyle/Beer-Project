using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D playerRigidbody;
    public float acceleration;
    public float maxVelocity;
    public float drag;
    public float friction;
    private Vector2 newVelocity;
    void Start()
    {
        playerRigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A)){
            newVelocity.x -= acceleration;
        }
        if (Input.GetKey(KeyCode.D)){
            newVelocity.x += acceleration;
        }
        if (Input.GetKey(KeyCode.W)){
            newVelocity.y +=acceleration;
        }
        if (Input.GetKey(KeyCode.S)){
            newVelocity.y -=acceleration;
        }
        newVelocity = Vector2.ClampMagnitude(newVelocity, maxVelocity);
        if (Mathf.Abs(newVelocity.x) + Mathf.Abs(newVelocity.y) <= friction){
            newVelocity.x = 0;
            newVelocity.y = 0;
        }
        //newVelocity = newVelocity.normalized;

        newVelocity *= drag;

        playerRigidbody.velocity = newVelocity;


    }
}
