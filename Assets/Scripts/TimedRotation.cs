using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedRotation : MonoBehaviour
{
    // References.
    Animator anim;
    Material material;

    // Variables.
    public int rotationInterval = 3;
    float warningDelay = 0.5f;
    

    void Start()
    {
        anim = GetComponent<Animator>();
        material = GetComponent<Renderer>().material;
        StartCoroutine(RotatePlatform(rotationInterval));      
    }
    
    IEnumerator RotatePlatform(float delay)
    {
        while (true)
        {
            if (anim != null)
            {
                material.color = Color.red;

                yield return new WaitForSeconds(warningDelay);

                anim.enabled = true;
                
                float animationLength = anim.GetCurrentAnimatorStateInfo(0).length;
                yield return new WaitForSeconds(animationLength);

                anim.enabled = false;
                material.color = Color.green;
            }

            else
            {
                Debug.Log("This component is null!");
                yield break;
            }
            yield return new WaitForSeconds(rotationInterval);
        }
    }  
}
