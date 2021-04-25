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
    private int jumpCount = 0;
    private bool isGrounded = false;
    private bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpCount++;
            print(jumpCount);
            rb.AddForce(0, thrust, 0, ForceMode.Impulse);
            //transform.Translate(0, jumpForce * Input.GetAxis("Jump") * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = transform.position += transform.right * -moveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position = transform.position += transform.right * moveSpeed * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.contacts[0].normal.y > 0.7f)
        {
            isGrounded = true;
            jumpCount = 0;
        }

    }

}
