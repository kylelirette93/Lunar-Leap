using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float rotationSpeed = 200f;
    private Camera mainCamera;
    private AsteroidSpawner spawner;
    Vector3 rotationAxis;
    Vector3 movementDirection;
    void Start()
    {
        mainCamera = Camera.main;
        spawner = FindObjectOfType<AsteroidSpawner>();

        rotationAxis = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        movementDirection = new Vector3(Random.Range(-1, 1f), 0, Random.Range(-1f, 1f)).normalized;
    }

    void Update()
    {
        // Move the asteroid forward
        transform.Translate(movementDirection * movementSpeed * Time.deltaTime);

        // Rotate the asteroid
        transform.Rotate(rotationAxis, rotationSpeed * Time.deltaTime);


    }

    
}