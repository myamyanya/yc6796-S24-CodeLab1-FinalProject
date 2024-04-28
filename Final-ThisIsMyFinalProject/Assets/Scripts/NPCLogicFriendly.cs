using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCLogicFriendly : NPCLogic
{
    // Variables
    // Checking if the player is colliding with the NPC
    [SerializeField] private bool isColliding = false;
    
    // Preventing re-triggering the behave
    [SerializeField] private bool isInteracted = false;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("Player is near by...");

            isColliding = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("Player is leaving.");

            isColliding = false;
        }
    }
    
    public override void NPCBehave()
    {
        if (isColliding)
        {
            if (Input.GetKey(KeyCode.E) && !isInteracted)
            {
                Debug.Log("Interacting with the player.");
                isInteracted = true;
                
                // Add the info of this NPC into the contacts
                ContactsManager.instance.contacts.Enqueue(npcData);
                
            }
        }
    }
}
