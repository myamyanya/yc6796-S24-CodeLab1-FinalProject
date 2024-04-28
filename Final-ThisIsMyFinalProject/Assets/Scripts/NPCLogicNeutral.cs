using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCLogicNeutral : NPCLogic
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
            if (!isInteracted && 
                !dialogueRunner.IsDialogueRunning &&
                dialogues != null)
            {
                dialogueRunner.StartDialogue(dialogues);
            }
            isInteracted = true;
        }
        else
        {
            dialogueRunner.Stop();
        }
    }
}
