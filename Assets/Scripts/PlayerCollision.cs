using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    bool isOnPlatform = false;
    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            isOnPlatform = true;

            // Stick the player to the platform.
            FreezeRigidbody();

            // Set the velocity of the player to the rigidbody of the moving platform.
            rb.velocity = collision.gameObject.GetComponent<Rigidbody>().velocity;

            // Make the player a child of the platform.
            transform.SetParent(collision.transform);

            
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            isOnPlatform = false;

            // Reset velocity to original velocity if the player jumps off the platform.
            rb.velocity = rb.velocity;

            // If the player is not on the platform, remove constraints.
            rb.constraints = RigidbodyConstraints.None;
            transform.SetParent(null);
        }
    }

    private void Update()
    {
        if (isOnPlatform && Input.GetKey(KeyCode.Space))
        {
            // Check if the player jumps, if so remove constraints.
            UnfreezeRigidbody();
        }
    }
    void FreezeRigidbody()
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }

    void UnfreezeRigidbody()
    {
        rb.constraints = RigidbodyConstraints.None;
    }

   

    
}
