using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCLogic : MonoBehaviour
{
    // Variables
    public NPCScriptableObject npcData;

    [SerializeField] private string npcName;
    [SerializeField] private Sprite npcSprite;
    [SerializeField] private string dialogues;
    
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
    
    // NPC Behave
    public virtual void NPCBehave()
    {
        // NPC behave will be further defined by the subclasses
    }
}
