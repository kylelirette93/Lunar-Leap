using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovingPlatform : MonoBehaviour
{
    // References
    private Vector3 initialPosition;

    // Variables
    public float travelDistance = 5f; 
    public float movementSpeed = 20f; 
    public bool movingLeft = true; 

    private Rigidbody rb;

    void Start()
    {
        // Initialize variables
        initialPosition = transform.position;
        rb = GetComponent<Rigidbody>();

        // Make sure Rigidbody is kinematic
        rb.isKinematic = true;
    }

    void FixedUpdate()
    {
        // Calculate movement direction
        Vector3 movementVector = movingLeft ? Vector3.left : Vector3.right;

        // Move the platform
        rb.MovePosition(rb.position + movementVector * movementSpeed * Time.fixedDeltaTime);

        if ((movingLeft && transform.position.x <= initialPosition.x - travelDistance) ||
            (!movingLeft && transform.position.x >= initialPosition.x + travelDistance))
        {
            movingLeft = !movingLeft; // Reverse direction
        }
    }

    // Attach player to the platform when standing on it
    private void OnCollisionStay(Collision collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody playerRb = collision.gameObject.GetComponent<Rigidbody>();
            if (playerRb != null)
            {
                Vector3 platformVelocity = rb.velocity;
                playerRb.velocity = new Vector3(platformVelocity.x, platformVelocity.y, platformVelocity.z);
            }
            collision.transform.SetParent(transform);
        }
    }

    // Detach player from the platform when leaving
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody playerRb = collision.gameObject.GetComponent<Rigidbody>();
            if (playerRb != null)
            {
                playerRb.velocity = new Vector3(0, playerRb.velocity.y, playerRb.velocity.z);
            }
            
        }
    }
}