using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    float travelDistance;
    Vector2 movementVector;
    float movementSpeed = 1f;
    bool movingLeft = true;
   
    
    void Start()
    {
        travelDistance = 12f;
    }

    
    void Update()
    {
        
        if (movingLeft)
        {
            movementVector = new Vector3(-1, 0);
        }
        else if (!movingLeft)
        {
            movementVector = new Vector3(1, 0);
        }
        transform.Translate(movementVector * travelDistance * movementSpeed * Time.deltaTime);

        if (Mathf.Abs(transform.position.x) >= travelDistance)
        {
            movingLeft = !movingLeft;
        }
    }
}
