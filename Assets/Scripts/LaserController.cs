using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    public int fireDelay;
    public GameObject laserPrefab;
    public float fireForce;
    void Start()
    {
        StartCoroutine(FireLaser(fireDelay));
    }

    IEnumerator FireLaser(float delay)
    {
        while (true)
        {
            Vector3 offsetPosition = new Vector3(0, 1.2f, 0);
            Vector3 laserRotation = new Vector3(0, 0, 90);
            Quaternion convertedRotation = Quaternion.Euler(laserRotation);
            GameObject laserInstance = Instantiate(laserPrefab, transform.position + offsetPosition, convertedRotation);         
            laserInstance.GetComponent<Rigidbody>().AddForce(new Vector3(fireForce, 0, 0), ForceMode.Impulse);
            yield return new WaitForSeconds(delay);
        }
    }
}
