using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManMove : MonoBehaviour
{
    public float speed = 0.4F;
    public float turnSpeed = 1;

    public bool Issprinting = false;
    public float sprintingMultiplier;


    public bool isCrouching = false;
    public float crouchingMultiplier;

    public CharacterController controller;
    public float standigHeight = 1.8f;
    public float crouchingHeight = 1.25f;

    Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        controller = gameObject.GetComponent<CharacterController>();
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

        gameObject.GetComponent<Transform>().Rotate(Vector3.up * turnInput * turnSpeed); // Rotates the Man around Y-axis

        

        Issprinting = (Input.GetKey(KeyCode.LeftShift)); //sprint button
        if (Issprinting)
        {
            rb.velocity = newVelocity * sprintingMultiplier;
        }
        else
        {
            rb.velocity = newVelocity; //Sets velocity of the Man to movespeed in the forward direction
        }
        isCrouching = (Input.GetKey(KeyCode.RightShift));
        if (isCrouching == true)
        {
            controller.height = crouchingHeight;
            newVelocity *= crouchingMultiplier;
        }
        else
        {
            controller.height = standigHeight;
        }
        
}
} 



