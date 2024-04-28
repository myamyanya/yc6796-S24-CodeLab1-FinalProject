using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NPCType
{
    Neutral, 
    Friendly
}

[CreateAssetMenu
    (
        fileName = "New NPC",
        menuName = "An NPC",
        order = 0)
]

public class NPCScriptableObject : ScriptableObject
{
    // Defining the NPC
    public string npcName;
    public Sprite NpcSprite;
    public NPCType npcType;
    public string dialogueNode;
    public string contactCode;
}
