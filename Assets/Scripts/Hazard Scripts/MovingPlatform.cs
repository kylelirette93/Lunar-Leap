using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    // References.
    Vector2 movementVector;
    Vector2 initialPosition;

    // Variables.
    public float travelDistance;
    public float movementSpeed = 1f;
    public bool movingLeft = true;
   
    
    void Start()
    {
        // Store the initial position of the platform.
        initialPosition = transform.position;
    }

    
    void Update()
    {
        // Boolean to control movement direction.
        if (movingLeft)
        {
            // Create a direction vector to left on the x axis.
            movementVector = new Vector3(-1, 0);
        }
        else if (!movingLeft)
        {
            // Create a direction vector to right on the x axis.
            movementVector = new Vector3(1, 0);
        }

        // Move the player based on direction and travel distance, scale by speed and dependent on frame rate.
        transform.Translate(movementVector * travelDistance * movementSpeed * Time.deltaTime);

        // Determine the absolute different of position between the platform and it's initial position.
        // If the difference in position is greater than the travel distance, switch direction.
        if (Mathf.Abs(transform.position.x - initialPosition.x) >= travelDistance)
        {
            movingLeft = !movingLeft;
        }
    }
}
