using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayer : MonoBehaviour
{
    public Transform playerTransform;
    float chaseDistance = 10f;
    float chaseSpeed = 5f;
    float distanceToPlayer;
   


    void Update()
    {
        distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);
        if (distanceToPlayer <= chaseDistance)
        {
            Chase();
        }
    }

    void Chase()
    {
        Vector3 directionToPlayer = (playerTransform.position - transform.position).normalized;

        transform.position += directionToPlayer * chaseSpeed * Time.smoothDeltaTime;
    }

    
}
