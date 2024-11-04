using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DoorController : MonoBehaviour
{
    void Update()
    {
        // Removes a door in the second level.
        if (PlayerScore.Instance.count >= 12)
        {
            Destroy(gameObject);
        }
    }
}
