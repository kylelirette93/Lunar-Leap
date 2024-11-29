using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncy : MonoBehaviour
{
    Rigidbody playerRb;
    string playerTag = "Player";
    public float bounceForce;

    private void Start()
    {
        playerRb = GameObject.FindGameObjectWithTag(playerTag).GetComponent<Rigidbody>();
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Reset player's y velocity before applying force.
            // This makes for consistant bounce.
            playerRb.velocity = Vector3.zero;
            playerRb.AddForce(Vector3.up * bounceForce, ForceMode.Impulse);
        }
    }
}
