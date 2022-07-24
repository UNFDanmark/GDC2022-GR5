using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManMove : MonoBehaviour
{
    public float speed = 0.4F;
    public float turnSpeed = 1;

    bool isGrounded;

    public bool Issprinting = false;
    public float sprintingMultiplier;

    public bool isCrouching = false;
    public float crouchingMultiplier;

    public Collider StandingCollider;
    public float Crouchtimer = 0.3F;
    float CrouchTimeNow = 0f;

    public Transform NormalV;
    public Transform CrouchV;

    
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

        gameObject.GetComponent<Transform>().Rotate(Vector3.up * turnInput * turnSpeed); // Rotates the Man around Y-axis


        isCrouching = (Input.GetKey(KeyCode.RightShift));//CrouchSystem and Sprint

        Issprinting = (Input.GetKey(KeyCode.LeftShift)); //sprint button
        
        
        if (isCrouching) //Crouch butto
        {
            StandingCollider.enabled = false;
            rb.velocity = newVelocity * crouchingMultiplier;

            CrouchTimeNow = CrouchTimeNow + Time.deltaTime;

            if (CrouchTimeNow < Crouchtimer)
            {
                Camera.main.transform.position = Vector3.MoveTowards(NormalV.position, CrouchV.position, CrouchTimeNow / Crouchtimer);
            }
            else
            {
                Camera.main.transform.position = Vector3.MoveTowards(NormalV.position, CrouchV.position, 1f);
            }
        }
        else if (Issprinting)
            {
                StandingCollider.enabled = true;
                rb.velocity = newVelocity * sprintingMultiplier;
            }
        else
        {
            rb.velocity = newVelocity; //Sets velocity of the Man to movespeed in the forward direction
             
        }
      
        if (!isCrouching)
        {
            StandingCollider.enabled = true;
            CrouchTimeNow = 0f;
            Camera.main.transform.position = NormalV.position;
            // lAV NOGET code til at smooth move kamera op igen????
        }
    }
} 



