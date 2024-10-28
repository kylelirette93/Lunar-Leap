using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    
    private Rigidbody rb;

    private float movementX;
    private float movementY;

    public float speed = 0;

    public float jumpForce;
    bool isGrounded = true;

    public TextMeshProUGUI countText;

    


    void Start()
    {      
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (transform.position.y <= -20f)
        {
            GameManager.deathCount++;
            ReloadScene();
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

    


    private void FixedUpdate()
    {     
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
     
        rb.AddForce(movement * speed);
    }

    void Jump()
    {
        if (isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }
        else
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, rb.velocity.z);
        }
    }


    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}