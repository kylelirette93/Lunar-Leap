using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayer : MonoBehaviour
{
    // References
    public Transform playerTransform;

    // Variables
    [SerializeField] private float activationDistance = 10f;
    [SerializeField] private float chaseSpeed = 5f;
    [SerializeField] private float fixedY = 6.8f;
    [SerializeField] private float minimumDistance = 0.5f;
    [SerializeField] private float repellingForce = 4f;

    private Animator animator;
    Rigidbody playerRb;

    private void Start()
    {
        animator = GetComponent<Animator>();
        playerRb = playerTransform.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Calculate distance to the player
        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

        if (distanceToPlayer <= activationDistance && distanceToPlayer > minimumDistance)
        {
            // Chase the player
            animator.SetBool("isRunning", true);
            ChasePlayerAndMaintainDistance();
        }
        else if (distanceToPlayer <= minimumDistance)
        {
            // Repel from the player to avoid getting stuck
            RepelPlayer();
        }
        else
        {
            // Stop chasing when out of range
            animator.SetBool("isRunning", false);
        }
    }

    private void ChasePlayerAndMaintainDistance()
    {
        // Adjust target position to maintain fixed Y coordinate
        Vector3 targetPosition = new Vector3(playerTransform.position.x, fixedY, playerTransform.position.z);

        // Move towards the player
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, chaseSpeed * Time.deltaTime);

        // Rotate to face the player
        Vector3 directionToPlayer = (targetPosition - transform.position).normalized;
        Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);
        Quaternion rotationOffset = Quaternion.Euler(0, 90, 0);
        transform.rotation = targetRotation * rotationOffset;
    }

    private void RepelPlayer()
    {
        // Calculate the direction from the robot to the player
        Vector3 repelDirection = playerTransform.position - transform.position;

        // Apply force to the player to push them away
        playerRb.AddForce(repelDirection.normalized * repellingForce, ForceMode.Impulse);

        // Perform raycast to check for walls or obstacles.
        RaycastHit hit;
        Vector3 right = transform.position + transform.right * 0.5f;
        Vector3 left = transform.position - transform.right * 0.5f;

        // Add adjustment to force to avoid getting stuck.
        if (Physics.Raycast(right, transform.forward, out hit, 1f))
        {
            playerRb.AddForce(-transform.right * repellingForce / 2, ForceMode.Impulse);
        }
        if (Physics.Raycast(left, transform.forward, out hit, 1f))
        {
            playerRb.AddForce(transform.right * repellingForce / 2, ForceMode.Impulse);
        }
    }
}