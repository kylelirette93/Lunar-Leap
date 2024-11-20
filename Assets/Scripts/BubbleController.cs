using UnityEngine;
using UnityEngine.SceneManagement;

public class BubbleController : MonoBehaviour
{
    public static BubbleController instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log("BubbleController is marked to not destroy and is now persistent.");
        }
        else
        {
            Destroy(gameObject);
            Debug.Log("BubbleController duplicate detected and destroyed.");
        }
    }

   
}