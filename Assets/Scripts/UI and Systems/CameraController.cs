using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{    
    public GameObject player;
    private Vector3 offset;
    

   
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Backwall"))
        {
            Debug.Log("Triggering camera culling.");
            // Exclude the Backwall layer from the camera's culling mask
            int backwallLayer = LayerMask.NameToLayer("Backwall");
            if (backwallLayer != -1) // Check if the layer exists
            {
                Camera.main.cullingMask &= ~(1 << backwallLayer);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Backwall"))
        {
            // Include the Backwall layer back into the camera's culling mask
            int backwallLayer = LayerMask.NameToLayer("Backwall");
            if (backwallLayer != -1)
            {
                Camera.main.cullingMask |= (1 << backwallLayer);
            }
        }
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}