using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    float worldSizeHeight, worldSizeWidth;
    [SerializeField] float objectScaleUnit;
    void Start()
    {
        worldSizeHeight = Camera.main.orthographicSize;
        worldSizeWidth = Camera.main.orthographicSize * Camera.main.aspect;
        objectScaleUnit = transform.localScale.x /2;
    }

    void Update()
    {
        Movement();
    }

    void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
        direction.Normalize();
        transform.Translate(direction * Time.deltaTime * speed);

        //Looping around map
        if (transform.position.x >= worldSizeWidth + objectScaleUnit)
        {
            transform.position = new Vector3(-worldSizeWidth - objectScaleUnit, transform.position.y, 0);

        }
        else if (transform.position.x <= -worldSizeWidth - objectScaleUnit)
        {
            transform.position = new Vector3(worldSizeWidth + objectScaleUnit, transform.position.y, 0);
        }

        //Clamp movement to the bottom half of screen
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -worldSizeHeight + objectScaleUnit, 0), 0);
    }
}

