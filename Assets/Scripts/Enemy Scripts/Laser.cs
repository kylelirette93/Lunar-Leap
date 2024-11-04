using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    // Destroy laser if it collides with a wall.
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
