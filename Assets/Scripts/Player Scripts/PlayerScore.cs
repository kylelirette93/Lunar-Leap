using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    // References.
    public static PlayerScore Instance;
    public GameObject panel;
    public GameObject portal;
    public TextMeshProUGUI countText;
    PlayerHealth playerHealth;

    // Variables.
    public int count;
    bool touchedPanel = false;
    Vector3 cachedPanelPosition;
    public Vector3 offset;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        cachedPanelPosition = panel.transform.position;
        // Initialize count to 0 and update text.
        count = 0;
        portal.SetActive(false);
        SetCountText();
        playerHealth = GetComponent<PlayerHealth>();    
    }

    void SetCountText()
    {
        countText.text = $"{count} / 12 gears collected.";
        Vector3 panelPosition = panel.transform.position;
        Vector3 worldPositionAbovePanel = panelPosition + offset;

        Vector3 screenPoint = Camera.main.WorldToScreenPoint(worldPositionAbovePanel);
        Vector3 localPosition = countText.transform.parent.
            GetComponent<RectTransform>().InverseTransformPoint(screenPoint);

        countText.transform.localPosition = Vector3.Lerp(countText.transform.localPosition, localPosition, Time.deltaTime * 10f);
    

        if (count >= 12 && touchedPanel)
        {
            countText.text = "Portal Activated!";
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

    private void LateUpdate()
    {
        SetCountText();
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
