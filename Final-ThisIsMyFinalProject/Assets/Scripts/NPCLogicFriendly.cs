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
            
            // Hide indicator
            GameManager.instance.interactionIndicator.text = "";
        }
    }
    
    public override void NPCBehave()
    {
        if (isColliding)
        {
            if (!isInteracted)
            {
                // Show the indicator
                GameManager.instance.interactionIndicator.text = "F: Say \"Hi\" ?";
            }
            
            if (Input.GetKey(KeyCode.F) && !isInteracted)
            {
                Debug.Log("Interacting with the player.");
                isInteracted = true;
                
                // Hide the indicator
                GameManager.instance.interactionIndicator.text = "";

                // Start running the dialogues
                if (dialogues != null && !dialogueRunner.IsDialogueRunning)
                {
                    dialogueRunner.StartDialogue(dialogues);
                }
                
                // Add the info of this NPC into the friend contact sheet
                ContactsManager.instance.contacts.Enqueue(npcData);
            }
        }
    }
}
