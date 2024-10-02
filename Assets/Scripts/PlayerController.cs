using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    
    private Rigidbody rb;

    private int count;

    private float movementX;
    private float movementY;

    public float speed = 0;

    public float jumpForce;
    bool isGrounded = true;

    public TextMeshProUGUI countText;

    public GameObject winTextObject;


    void Start()
    {      
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        
        isGrounded = GroundCheck();
    }

    bool GroundCheck()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1f))
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }

    void OnMove(InputValue movementValue)
    {       
        Vector2 movementVector = movementValue.Get<Vector2>();
      
        movementX = movementVector.x;
        movementY = movementVector.y;

        
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();

        if (count >= 12)
        {
            winTextObject.SetActive(true);
        }
    }


    private void FixedUpdate()
    {     
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
     
        rb.AddForce(movement * speed);
    }

    void Jump()
    {
        if (isGrounded)
        {
            rb.AddForce(0, jumpForce, 0);
        }
        else
        {
            rb.AddForce(0, 0, 0);
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
}