using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        public float speed = 0.3
        public float turnSpeed = 0.3
        
        Rigidbody rb;
}

    // Update is called once per frame
    void Update()
    {
        ManMove();

    }    void ManMove()
    {
    float moveInput = moveInput.GetAxis("Vertical");//Variable for move input Så dude kan Går rund.
    float turnInput = moveInput.GetAxis("Horizontal");

    float moveSpeed = speed * moveInput;

    Vector3 newVelocity = transform.forward * moveSpeed;
    newVelocity.y = rb.velocity.y;


    }

