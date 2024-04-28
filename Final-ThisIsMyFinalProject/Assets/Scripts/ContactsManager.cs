using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ContactsManager : MonoBehaviour
{
    // Creating a queue to hold contacts info
    public Queue<NPCScriptableObject> contacts = new Queue<NPCScriptableObject>();
    
    // Display
    [SerializeField] private Canvas displayContacts;
    [SerializeField] private TextMeshProUGUI friendName;

    [SerializeField] private bool contactIsOpened = false;
        
    // Singleton
    public static ContactsManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Set up display
        displayContacts = GameObject.Find("DisplayContacts").GetComponent<Canvas>();
        friendName = GameObject.Find("NPCName").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        // ON/OFF switch
        if (GameManager.instance.isGameBegined)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                if (contactIsOpened)
                {
                    contactIsOpened = false;
                }
                else
                {
                    contactIsOpened = true;
                }
            }
        }

        displayContacts.enabled = contactIsOpened;

        // Pulling content from the queue and put them into the display
        if (contacts != null && contacts.Count > 0)
        {
            string content = "";
            
            foreach (NPCScriptableObject npc in contacts)
            {
                content += npc.npcName + ": " + npc.contactCode + "\n";
            }
            
            friendName.text = content;
            friendName.color = Color.black;
        }
        else
        {
            friendName.text = "This contact is empty...";
            friendName.color = Color.gray;
        }
    }
}
