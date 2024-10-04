using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float travelDistance;
    Vector2 movementVector;
    Vector2 initialPosition;
    public float movementSpeed = 1f;
    public bool movingLeft = true;
   
    
    void Start()
    {
        initialPosition = transform.position;
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

        if (Mathf.Abs(transform.position.x - initialPosition.x) >= travelDistance)
        {
            movingLeft = !movingLeft;
        }
    }
}
