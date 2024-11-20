using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncy : MonoBehaviour
{
    Rigidbody playerRb;
    string playerTag = "Player";

    private void Start()
    {
        playerRb = GameObject.FindGameObjectWithTag(playerTag).GetComponent<Rigidbody>();
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerRb.AddForce(Vector3.up * 25, ForceMode.Impulse);
        }
    }
}
