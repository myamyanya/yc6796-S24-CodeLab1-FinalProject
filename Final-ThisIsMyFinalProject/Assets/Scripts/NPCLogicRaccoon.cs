using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class NPCLogicRaccoon : NPCLogic
{
    // Variables
    // Checking if the player is colliding with the NPC
    [SerializeField] private bool isColliding = false;
    
    // Preventing re-triggering the behave
    [SerializeField] private bool isInteracted = false;
    
    // Pulling data from Yarn
    private InMemoryVariableStorage yarnVarialbes;
    private bool isConversationFinished = false;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("Player is near by...");

            yarnVarialbes = GameObject.FindObjectOfType<InMemoryVariableStorage>();

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
            if (!isInteracted)
            {
                // Show the indicator
                GameManager.instance.interactionIndicator.text = "F: Arrived!!";
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

            // Checking is the dialogue finished from Yarn
            yarnVarialbes.TryGetValue("$isGameEnd", out isConversationFinished);

            if (isConversationFinished)
            {
                GameManager.instance.isGameEnded = true;
            }
        }
        else
        {
            GameManager.instance.interactionIndicator.text = "";
        }
    }
}
