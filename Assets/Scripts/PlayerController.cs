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

    //[Header("Set Dynamically")]
    public int jumpCount = 0;
    public bool isGrounded = false;
    public bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Checks if max jump count was reached
            if (jumpCount < 2)
            {
                jumpCount++;
                animator.SetFloat("JumpCount", jumpCount);
                rb.AddForce(0, thrust, 0, ForceMode.Impulse);
            }    
        }

        //Move Left
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = transform.position += transform.right * -moveSpeed * Time.deltaTime;
            Vector3 theScale = transform.localScale;
            theScale.x = -.2f;
            transform.localScale = theScale;
            animator.SetFloat("Speed", 1);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            animator.SetFloat("Speed", 0);
        }

        //Move Right
        if (Input.GetKey(KeyCode.D))
        {
            transform.position = transform.position += transform.right * moveSpeed * Time.deltaTime;
            Vector3 theScale = transform.localScale;
            theScale.x = .2f;
            transform.localScale = theScale;
            animator.SetFloat("Speed", 1);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            animator.SetFloat("Speed", 0);
        }
    }
}
