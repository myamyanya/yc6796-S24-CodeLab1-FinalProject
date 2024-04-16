using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    // Variables
    [SerializeField] private Rigidbody rb;
    
    // For moving
    private Vector3 mouseInput;
    private Vector3 movement;
    public float forceAmt = 0.0f;
    
    // For changing sprite
    [SerializeField] private SpriteRenderer spriteRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        // WASD controller to move
        Moving();
        
        // When changing the direction, flip the sprite
        if (Input.GetKey(KeyCode.A))
        {
            spriteRenderer.flipX = true;
        }

        if (Input.GetKey(KeyCode.D))
        {
            spriteRenderer.flipX = false;
        }
    }

    private void Moving()
    {
        // Getting the mouse input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        mouseInput = new Vector3(horizontalInput, 0f, verticalInput);
        
        // Fixing the rotation of the controller
        Quaternion rot = Quaternion.FromToRotation(Vector3.forward, Vector3.forward + Vector3.right);
        mouseInput = rot * mouseInput;
        
        movement = mouseInput * forceAmt * Time.deltaTime;
        
        // Moving the player's agency
        rb.MovePosition(transform.position + movement);
    }
}
