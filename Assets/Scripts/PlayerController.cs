using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //[Header("Set in Inspector")]
    public int moveSpeed;
    public float thrust = 1.0f;
    public Rigidbody rb;
    public Animator animator;
    public AudioSource[] sounds;
    //public int oxygenLevel = 100;

    //[Header("Set Dynamically")]
    public int jumpCount = 0;
    public bool isGrounded = false;
    public bool isDead = false;
    private bool walking = false;
    private bool walkingSound = false;


    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("ReduceOxygen", 1f, 10f);  //1s delay, repeat every 10s
        //footSteps = GetComponent<AudioSource>();
        //jump = GetComponent<AudioSource1>();
        //death = GetComponent<AudioSource>();
        sounds = GetComponents<AudioSource>();
    }

    //void ReduceOxygen()
    //{
    //    oxygenLevel--;
    //    Debug.Log(oxygenLevel);
    //}

    // Update is called once per frame
    void Update()
    {
        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && !isDead)
        {
            //Checks if max jump count was reached
            if (jumpCount < 2)
            {
                jumpCount++;
                animator.SetFloat("JumpCount", jumpCount);
                rb.AddForce(0, thrust, 0, ForceMode.Impulse);
                sounds[1].Play();
            }    
        }

        //Move Left
        if (Input.GetKey(KeyCode.A) && !isDead)
        {
            transform.position = transform.position += transform.right * -moveSpeed * Time.deltaTime;
            Vector3 theScale = transform.localScale;
            theScale.x = -.2f;
            transform.localScale = theScale;
            if (isGrounded)
            {
                animator.SetFloat("Speed", 1);
                walking = true;
                Walking();
            }
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            animator.SetFloat("Speed", 0);
            walking = false;
            Walking();
        }

        //Move Right
        if (Input.GetKey(KeyCode.D) && !isDead)
        {
            transform.position = transform.position += transform.right * moveSpeed * Time.deltaTime;
            Vector3 theScale = transform.localScale;
            theScale.x = .2f;
            transform.localScale = theScale;
            if(isGrounded)
            {
                animator.SetFloat("Speed", 1);
                walking = true;
                Walking();
            }
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            animator.SetFloat("Speed", 0);
            walking = false;
            Walking();
        }
    }

    public void Death()
    {
        animator.SetBool("Dead", true);
        isDead = true;
        rb.isKinematic = true;
        sounds[2].Play();
    }

    public void PlayerReset()
    {
        animator.SetBool("Dead", false);
        isDead = false;
        rb.isKinematic = false;
    }

    public void Walking()
    {
        if(walking && jumpCount == 0)
        {
            if (!walkingSound)
            {
                sounds[0].Play();
                walkingSound = true;
            }
        }
        else if(!walking || jumpCount > 0)
        {
            sounds[0].Stop();
            walkingSound = false;
        }
    }
}
