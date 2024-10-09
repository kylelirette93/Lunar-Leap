using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCollision : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Portal")) 
        {
            GameManager.instance.LoadNextLevel();
        }
    }
}
