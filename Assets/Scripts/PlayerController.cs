using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //[Header("Set in Inspector")]
    public int moveSpeed;
    public float thrust = 1.0f;
    public Rigidbody rb;

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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Checks if max jump count was reached
            if (jumpCount < 2)
            {
                jumpCount++;
                rb.AddForce(0, thrust, 0, ForceMode.Impulse);
            }    
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = transform.position += transform.right * -moveSpeed * Time.deltaTime;
            Vector3 theScale = transform.localScale;
            theScale.x = -.2f;
            transform.localScale = theScale;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position = transform.position += transform.right * moveSpeed * Time.deltaTime;
            Vector3 theScale = transform.localScale;
            theScale.x = .2f;
            transform.localScale = theScale;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        print(other.tag);
        if (other.tag == "Ground")
        {
            isGrounded = true;
            jumpCount = 0;
        }

    }

}
