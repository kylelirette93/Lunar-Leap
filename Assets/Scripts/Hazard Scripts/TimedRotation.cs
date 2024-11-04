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
                // Set the platform material to red to warn that it's going to rotate.
                material.color = Color.red;

                // Pause and then enable the animation to rotate platform.
                yield return new WaitForSeconds(warningDelay);
                anim.enabled = true;
                
                // Store length of animation.
                float animationLength = anim.GetCurrentAnimatorStateInfo(0).length;
                yield return new WaitForSeconds(animationLength);

                // If animation has finished, change the material back to green.
                anim.enabled = false;
                material.color = Color.green;
            }

            else
            {
                Debug.Log("This component is null!");
                yield break;
            }
            // Start the rotation every 3 seconds.
            yield return new WaitForSeconds(rotationInterval);
        }
    }  
}
