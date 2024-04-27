using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCLogic : MonoBehaviour
{
    // Variables
    [SerializeField] private bool isColliding = false;
    public NPCScriptableObject npcData;

    [SerializeField] private string npcName;
    [SerializeField] private Sprite npcSprite;
    [SerializeField] private string dialogues;
    
    // Preventing re-triggering the behave
    [SerializeField] private bool isInteracted = false;
    
    // Start is called before the first frame update
    void Start()
    {
        // Pulling data from the scriptable object
        npcName = npcData.npcName;
        npcSprite = npcData.NpcSprite;
        
        // Implementing the data to the NPC
        gameObject.name = npcName;
        gameObject.GetComponent<SpriteRenderer>().sprite = npcSprite;
        
        // Setting up dialogues
        if (npcData.dialogueNode != null)
        {
            dialogues = npcData.dialogueNode;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // If the player is trying to interact, do something
        NPCBehave();
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
    
    // NPC Behave
    public virtual void NPCBehave()
    {
        if (isColliding)
        {
            if (Input.GetKey(KeyCode.E) && !isInteracted)
            {
                Debug.Log("Interacting with the player.");
                
                isInteracted = true;
            }
        }
    }
}
