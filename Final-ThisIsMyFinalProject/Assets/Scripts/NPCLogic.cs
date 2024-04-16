using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCLogic : MonoBehaviour
{
    // Variables
    [SerializeField] private bool isColliding = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // If the player interact, do something
        if (isColliding)
        {
            if (Input.GetKey(KeyCode.E))
            {
                Debug.Log("Interacting with the player.");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player is near by...");

            isColliding = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player is leaving.");

            isColliding = false;
        }
    }
}
