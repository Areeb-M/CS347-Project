using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharGrounded : MonoBehaviour
{

    public PlayerController pc;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ground")
        {
            pc.isGrounded = true;
            pc.jumpCount = 0;
            pc.animator.SetFloat("JumpCount", 0f);
            //pc.rb.velocity = Vector3.zero;
            //pc.rb.angularVelocity = Vector3.zero;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Ground")
        {
            pc.isGrounded = false;
            pc.animator.SetFloat("Speed", 0f);
        }
    }
}
