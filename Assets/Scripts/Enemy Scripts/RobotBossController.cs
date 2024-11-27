using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotBossController : MonoBehaviour
{
    Animator animator;
    public GameObject laserPrefab;
    float fireDelay = 5f;
    GameObject laser1Instance;
    GameObject laser2Instance;
    Vector3 gun1Position;
    Vector3 gun1Rotation;
    Vector3 gun2Position;
    Vector3 gun2Rotation;
    bool isShooting = false;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        gun1Position = new Vector3(-8.5f,
            -0.75f, 9.25f);
        gun1Rotation = new Vector3(90, 0, 0);
        gun2Position = new Vector3(transform.position.x,
            transform.position.y, transform.position.z);
        gun2Rotation = new Vector3(90, 0, 0);
        StartCoroutine(FireLasers(fireDelay));     
    }

    





    IEnumerator FireLasers(float delay)
    {
        
        while (true)
        {
            Debug.Log("Shooting laser");
            yield return new WaitForSeconds(delay);
            animator.SetBool("isShooting", true);
            laser1Instance = Instantiate(laserPrefab, gun1Position, Quaternion.Euler(gun1Rotation));
            laser2Instance = Instantiate(laserPrefab, gun2Position, Quaternion.Euler(0, 0, 0));
        }

    }

    

}
