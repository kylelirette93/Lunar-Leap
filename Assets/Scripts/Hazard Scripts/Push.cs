using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : MonoBehaviour
{
    float bounceForce = 10f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Store difference between collision object and position of the rotating rectangle.
            // Normalize the vector.
            Vector3 bounceDirection = (collision.transform.position - transform.position).normalized;

            // Add continuous bounce force based on direction for an extra push.
            collision.gameObject.GetComponent<Rigidbody>().AddForce(bounceDirection * bounceForce, ForceMode.Force);
        }
    }
}
