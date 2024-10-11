using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DoorController : MonoBehaviour
{
    void Update()
    {
        if (PlayerScore.Instance.count >= 12)
        {
            Destroy(gameObject);
        }
    }
}
