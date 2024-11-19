using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovingPlatform : MonoBehaviour
{
    // References
    private Vector3 initialPosition;
    private Vector3 lastPosition;

    // Variables
    public float travelDistance = 5f;
    public float movementSpeed = 20f;
    public bool movingLeft = true;

    private Rigidbody rb;

    void Start()
    {
        // Initialize variables
        initialPosition = transform.position;
        lastPosition = initialPosition;
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

        lastPosition = transform.position;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody playerRb = collision.gameObject.GetComponent<Rigidbody>();
            if (playerRb != null)
            {
                // Calculate the platform's movement vector
                Vector3 platformMovement = transform.position - lastPosition;

                // Apply the platform's movement only to the player's position
                playerRb.MovePosition(playerRb.position + platformMovement);

                // Prevent rolling by resetting angular velocity
                playerRb.angularVelocity = Vector3.zero;

                float horizontalInput = Input.GetAxis("Horizontal");

                if (Mathf.Abs(horizontalInput) > 0.1f)
                {
                    playerRb.velocity = new Vector3(horizontalInput * movementSpeed, playerRb.velocity.y, playerRb.velocity.z);
                }
                else
                {
                    // Damp the horizontal velocity slightly to avoid drifting
                    playerRb.velocity = new Vector3(0, playerRb.velocity.y, playerRb.velocity.z);
                }
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody playerRb = collision.gameObject.GetComponent<Rigidbody>();
            if (playerRb != null)
            {
                // Ensure smooth detachment without excess momentum
                playerRb.velocity = new Vector3(playerRb.velocity.x, playerRb.velocity.y, 0);
            }
        }
    }
}