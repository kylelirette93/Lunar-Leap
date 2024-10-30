using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayer : MonoBehaviour
{
    // References.
    public Transform playerTransform;

    // Variables.
    float activationDistance = 10f;
    public float chaseSpeed = 5f;
    public float fixedY = 6.8f;
    float distanceToPlayer;
   
    void Update()
    {
        // Calculate distance from player to enemy.
        distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

        // If player is within the range of activation distance, the enemy chases the player.
        if (distanceToPlayer <= activationDistance)
        {
            Chase();
        }
    }

    void Chase()
    {
        // Update y position constantly with fixed value, this prevents the enemy from jumping with the player.
        Vector3 newPosition = new Vector3(transform.position.x, fixedY, transform.position.z);
        transform.position = newPosition;

        // Calculate direction and distance to player.
        Vector3 directionToPlayer = (playerTransform.position - transform.position).normalized;
        Quaternion rotation = Quaternion.LookRotation(directionToPlayer);
        transform.rotation = rotation;

        // Chase the player.
        transform.position += directionToPlayer * chaseSpeed * Time.smoothDeltaTime;
    }

    
}
