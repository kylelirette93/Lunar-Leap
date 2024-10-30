using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            Rigidbody collisionRB = collision.gameObject.GetComponent<Rigidbody>();
            // Set the velocity of the player to the rigidbody of the moving platform.
            rb.velocity = collisionRB.velocity;

            // Make the player a child of the platform.
            transform.SetParent(collision.transform);           
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            transform.SetParent(null);
        }
    } 
}
