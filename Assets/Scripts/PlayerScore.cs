using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public static PlayerScore Instance;
    public GameObject portal;
    public TextMeshProUGUI countText;
    public int count;
    bool touchedPanel = false;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        count = 0;
        portal.SetActive(false);
        SetCountText();
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();

        if (count >= 12)
        {
            if (touchedPanel)
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
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
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
