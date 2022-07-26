using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManMove : MonoBehaviour
{
    //moving system
    public float speed = 0.4F;
    public float turnSpeed = 1;

    //sprint system
    public bool Issprinting = false;
    public float sprintingMultiplier;

    //crouching system
    public bool isCrouching = false;
    public float crouchingMultiplier;
    public Collider StandingCollider;
    public float Crouchtimer = 0.3F;
    float CrouchTimeNow = 0f;

    public Transform NormalV;
    public Transform CrouchV;

    //life system
    public int maxHealth = 3;
    int currentHealth;

    //win system
    bool Key = false;
    public GameObject WinCanvas;

    //lose system
    public GameObject LoseCanvas;

    //Sound walkin system
    public AudioClip walking_sound_one;
    public AudioClip walking_sound_two;
    public AudioClip walking_sound_three;
    public AudioSource Sound;
    int current_walking_sound;
    List<AudioClip> walking_sounds;

    Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Sound.clip = walking_sound_one;
        current_walking_sound = 1;
        walking_sounds = new List<AudioClip>();
        walking_sounds.Add(walking_sound_one);
        walking_sounds.Add(walking_sound_two);
        walking_sounds.Add(walking_sound_three);
    }

    // Update is called once per frame
    void Update()
    {
        MoveHandler();
    }
    void MoveHandler() //moving system TOY
    {
        float moveInput = Input.GetAxis("Vertical");//Variable for move input
        float turnInput = Input.GetAxis("Horizontal");

        float moveSpeed = speed * moveInput;

        Vector3 newVelocity = transform.forward * moveSpeed;
        newVelocity.y = rb.velocity.y;

        gameObject.GetComponent<Transform>().Rotate(Vector3.up * turnInput * turnSpeed); // Rotates the Man around Y-axis

        if (moveSpeed != 0)
        {
            if (Sound.isPlaying == false)
            {
                current_walking_sound = (current_walking_sound + 1) % 2;
                Sound.clip = walking_sounds[current_walking_sound];
                Sound.Play();
            }
        }



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
    public void Attack(int damage)
    {
        currentHealth -= currentHealth - damage;

        if (currentHealth == 0)
        {
            SceneManager.LoadScene("LoseScene");

        }
    }

    
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == ("Key"))
        {
            print("hit key");
            AudioSource audioKey= collision.gameObject.GetComponent<AudioSource>();
            //audioKey.PlayOneShot(audioKey.clip);
            print(audioKey.clip);
            AudioSource.PlayClipAtPoint(audioKey.clip, collision.transform.position, 1);


            Destroy(collision.gameObject);
            Key = true;

            



        }    

        if (collision.gameObject.tag == ("Door") && Key == true) 
        {
            WinCanvas.SetActive(true);

            
        }
    }
   
}




