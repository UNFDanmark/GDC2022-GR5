using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManMove : MonoBehaviour
{
    public float speed = 0.4F;
    public float turnSpeed = 1;

    public bool Issprinting = false;
    public float sprintingMultiplier;

    Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        MoveHandler();
    }
    void MoveHandler()
    {
        float moveInput = Input.GetAxis("Vertical");//Variable for move input
        float turnInput = Input.GetAxis("Horizontal");

        float moveSpeed = speed * moveInput;

        Vector3 newVelocity = transform.forward * moveSpeed;
        newVelocity.y = rb.velocity.y;

        gameObject.GetComponent<Transform>().Rotate(Vector3.up * turnInput * turnSpeed); // Rotates the tank around Y-axis

        rb.velocity = newVelocity; //Sets velocity of the tank to movespeed in the forward direction
        
        if (Input.GetKey(KeyCode.LeftShift))//sprint button
        {
            Issprinting = true;

        }
        else
        {
            Issprinting = false;
        }

        if (Issprinting == true)
        {
            moveInput *= sprintingMultiplier;
        }
    }

}

