using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    
    // Variables.
    public int fireDelay;
    public float fireForce;

    // References.
    public GameObject laserPrefab;
    void Start()
    {
        StartCoroutine(FireLaser(fireDelay));
    }

    IEnumerator FireLaser(float delay)
    {
        while (true)
        {
            // Create an offset from the turret.
            Vector3 offsetPosition = new Vector3(0, 1.2f, 0);

            // Create a vector with a 90 degree rotation on the Z.
            Vector3 laserRotation = new Vector3(0, 0, 90);
            // Convert euler vector to quaternion.
            Quaternion convertedRotation = Quaternion.Euler(laserRotation);

            // Instantiate laser with offset and rotation.
            GameObject laserInstance = Instantiate(laserPrefab, transform.position + offsetPosition, convertedRotation);   
            
            // Add force to the laser.
            laserInstance.GetComponent<Rigidbody>().AddForce(new Vector3(fireForce, 0, 0), ForceMode.Impulse);

            // Shoot laser once for every delay.
            yield return new WaitForSeconds(delay);
        }
    }
}