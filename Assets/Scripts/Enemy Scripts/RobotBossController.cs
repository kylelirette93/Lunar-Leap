using System.Collections;
using UnityEngine;

public class RobotBossController : MonoBehaviour
{
    Animator animator;
    public GameObject laserPrefab;
    float fireDelay = 0.2f;
    Vector3 gun1Position;
    Vector3 gun1Rotation;
    Vector3 gun2Position;
    Vector3 gun2Rotation;
    public GameObject leftThruster;
    public GameObject rightThruster;
    int fireCount = 0;
    private Transform player;
    float lookSpeed = 2f;
    bool isShooting = false;
    string playerTag = "Player";
    Quaternion targetRotation;
    public Vector3 gun1Offset = new Vector3(0, 0, 0);
    public Vector3 gun2Offset = new Vector3(0, 0, 0);

    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag(playerTag).transform;
        gun1Position = new Vector3(-8.5f, -0.75f, 7.25f);
        gun1Rotation = new Vector3(90, 0, 0);
        gun2Position = new Vector3(-2f, -0.75f, 7.25f);
        gun2Rotation = new Vector3(90, 0, 0);
        StartCoroutine(FireLasers(fireDelay));
    }

    void Update()
    {      
            if (isShooting && player != null)
            {
                // Calculate the direction to the player
                Vector3 directionToPlayer = player.position - transform.position;
                // Keep only the horizontal direction for look rotation
                directionToPlayer.y = 0; 

                // Calculate the new rotation
                targetRotation = Quaternion.LookRotation(directionToPlayer);

                // Applying an offset to the rotation because model is not facing the same direction as
                // the forward vector of the object
                Quaternion rotationOffset = Quaternion.Euler(0, 90, 0);
                targetRotation *= rotationOffset;
                // Smoothly rotate to look at the player
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * lookSpeed);
            }     
    }
    IEnumerator FireLasers(float delay)
    {
        while (true)
        {
            Debug.Log("Shooting laser");
            yield return new WaitForSeconds(delay);
            animator.SetBool("isShooting", true);
            isShooting = true;
            leftThruster.SetActive(true);
            rightThruster.SetActive(true);

            Quaternion currentRotation = transform.rotation;

            // Calculate the world position of the guns.
            // This correctly calculates based on the rotation of the object.
            Vector3 gun1WorldPosition = transform.TransformPoint(gun1Position);
            Vector3 gun2WorldPosition = transform.TransformPoint(gun2Position);

            // Apply an offset to the world position.
            gun1WorldPosition += currentRotation * gun1Offset;
            gun2WorldPosition += currentRotation * gun2Offset;

            // Alternate between the two guns.
            if (fireCount % 2 == 0)
            {
                Instantiate(laserPrefab, gun1WorldPosition, currentRotation);
            }
            else
            {
                Instantiate(laserPrefab, gun2WorldPosition, currentRotation);
            }
            fireCount++;
        }
    }
}