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
    /*[SerializeField] private Image friendImage;
    [SerializeField] private TextMeshProUGUI friendDescription;*/

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
        /*friendImage = GameObject.Find("NPCImage").GetComponent<Image>();
        friendDescription = GameObject.Find("NPCDescription").GetComponent<TextMeshProUGUI>();*/
    }

    // Update is called once per frame
    void Update()
    {
        // ON/OFF
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

        // Content
        if (contacts.Count > 0)
        {
            friendName.text += contacts.Dequeue() + "\n";
        }
        else
        {
            friendName.text = "This contact is empty...";
            friendName.color = Color.gray;
        }
    }
}
