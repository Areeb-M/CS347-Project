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
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Ground")
        {
            print("not grounded");
            pc.isGrounded = false;
            pc.animator.SetFloat("Speed", 0f);
        }
    }
}
