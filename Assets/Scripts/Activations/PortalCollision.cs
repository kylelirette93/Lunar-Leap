using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCollision : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // Detects collision between player and the portal
        // loads the next level if the player goes into the portal.
        if (other.gameObject.CompareTag("Portal")) 
        {
            GameManager.instance.LoadNextLevel();
        }
    }
}
