using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    // References.
    public static PlayerScore Instance;
    public GameObject portal;
    public TextMeshProUGUI countText;
    PlayerHealth playerHealth;

    // Variables.
    public int count;
    bool touchedPanel = false;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        // Initialize count to 0 and update text.
        count = 0;
        portal.SetActive(false);
        SetCountText();
        playerHealth = GetComponent<PlayerHealth>();    
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();

        if (count >= 12 && touchedPanel)
        { 
            portal.SetActive(true);
            GameObject door = GameObject.Find("Door");
            if (door != null)
            {
                Destroy(door.gameObject);
            }
            else
            {
                Debug.Log("There's no door, game should continue.");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
        else if (other.gameObject.CompareTag("Bubble"))
        {
            other.gameObject.transform.localScale *= 2;
            Vector3 bubbleCenter = other.gameObject.transform.position;
            transform.position = bubbleCenter;

            Debug.Log("Setting player as parent of bubble.");
            other.gameObject.transform.SetParent(transform);
            playerHealth.canDie = false;

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Panel"))
        {
            touchedPanel = true;
            SetCountText();
        }
    }
}
