using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    
    // Variables.
    public float fireDelay;
    public float fireForce;
    float destroyDelay = 4f;

    // References.
    public GameObject laserPrefab;
    GameObject laserInstance;
    void Start()
    {
        StartCoroutine(FireLaser(fireDelay));
        StartCoroutine(DestroyLaser(destroyDelay));
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
            laserInstance = Instantiate(laserPrefab, transform.position + offsetPosition, convertedRotation);   
            
            // Add force to the laser.
            laserInstance.GetComponent<Rigidbody>().AddForce(new Vector3(fireForce, 0, 0), ForceMode.Impulse);

            // Shoot laser once for every delay.
            yield return new WaitForSeconds(delay);
        }
    }

    IEnumerator DestroyLaser(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(laserInstance);
    }
}
