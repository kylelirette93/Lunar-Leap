using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    bool isOnPlatform = false;
    Vector3 originalScale;
    void Start()
    {
        originalScale = transform.localScale;    
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            isOnPlatform = true;
            Vector3 worldPosition = transform.position;
            transform.SetParent(collision.transform);
            transform.localScale = originalScale;
            transform.position = worldPosition;
            
                  
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            isOnPlatform = false;
            transform.SetParent(null);
        }
    }

    private void Update()
    {
        if (isOnPlatform)
        {
            ResetScale();
        }
    }

    void ResetScale()
    {
        transform.localScale = originalScale;
    }
}
