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
    
    // For loading next level
    [SerializeField] private bool isReadyForNextLevel = false;
    
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

        // Press F to load next level
        if (isReadyForNextLevel)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("Next-level Loaded");

                LevelLoader.instanse.CurrentLevel++;
            }
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
        rb.velocity = movement;
        
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

    // For checking if the player is colliding with the NEXT LEVEL Trigger
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "NextLevel")
        {
            //Debug.Log("Hit NextLevel");
            isReadyForNextLevel = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "NextLevel")
        {
            isReadyForNextLevel = false;
        }
    }
}
