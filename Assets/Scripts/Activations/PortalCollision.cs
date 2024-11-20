using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalCollision : MonoBehaviour
{
    public string scene;
    void OnTriggerEnter(Collider other)
    {
        // Detects collision between player and the portal
        // loads the next level if the player goes into the portal.
        if (other.gameObject.CompareTag("Portal")) 
        {
            SceneManager.LoadScene(scene);
        }
    }
}
