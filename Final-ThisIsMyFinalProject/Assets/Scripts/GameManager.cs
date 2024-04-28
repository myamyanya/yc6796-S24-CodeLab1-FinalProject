using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Windows;
using Yarn.Unity;
using Input = UnityEngine.Input;

public class GameManager : MonoBehaviour
{
    // Variables 
    public static GameManager instance;
    
    // Game status
    public bool isGameBegined = false;
    public bool isGameEnded = false;
    
    // Variables of canvas
    public Canvas displayTutorial;
    public TextMeshProUGUI textTutorial;

    public Canvas displayInGame;
    public TextMeshProUGUI textInGame;
    
    public Canvas displayEnd;
    public TextMeshProUGUI textEnd;
    
    // Indicator of interaction
    public TextMeshProUGUI interactionIndicator;
    
    // DialogueRunner
    public DialogueRunner dialogueRunner;
    
    // Making the GameManager into a singleton
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            
            // Don't destroy the GameManagerHolder
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Reset game status
        isGameBegined = false;
        isGameEnded = false;
        
        // Set-up canvas
        displayTutorial = GameObject.Find("DisplayTutorial").GetComponent<Canvas>();
        textTutorial = GameObject.Find("TextBegin").GetComponent<TextMeshProUGUI>();

        // Set-up InGame displaying
        displayInGame = GameObject.Find("DisplayGame").GetComponent<Canvas>();
        textInGame = GameObject.Find("TextInGame").GetComponent<TextMeshProUGUI>();

        interactionIndicator = GameObject.Find("TextInGame_Indicator").GetComponent<TextMeshProUGUI>();

        textInGame.text = "";
        interactionIndicator.text = "";
        
        // Set-up EndGame displaying
        displayEnd = GameObject.Find("DisplayEnd").GetComponent<Canvas>();
        textEnd = GameObject.Find("TextEnd").GetComponent<TextMeshProUGUI>();

        textEnd.text = "";
        
        // Set-up dialogue runner
        dialogueRunner = GameObject.Find("Dialogue System").GetComponent<DialogueRunner>();
    }

    // Update is called once per frame
    void Update()
    {
        // Tutorial at the beginning of the game
        if (!isGameBegined)
        {
            // Show the tutorial at the beginning
            displayTutorial.enabled = true;
            
            // If the player press F, start the game 
            if (Input.GetKeyDown(KeyCode.F))
            {
                isGameBegined = true;
                LevelLoader.instanse.CurrentLevel = 0;
            }
        }
        else
        {
            // ... and hide the tutorial UI
            displayTutorial.enabled = false;
            
            // Display the In-game canvas and text
            textInGame.text = "WASD: MOVE" + "  |  " +
                              "F: INTERACT" + "  |  " +
                              "C: Open Contact";
        }
        
        // If the player reached the Raccoon,
        // end the game and show the end stage
        if (isGameEnded)
        {
            Destroy(LevelLoader.instanse.level);
            
            // Show the end UI
            displayEnd.enabled = true;
            textEnd.text = "Thank you for playing!" + "\n" +
                           "Hope you like this game!!" + "\n" +
                           "... and enjoy your apple pie <3";

            textInGame.text = "Q: Quit The Game";

            // Q to quit the game
            if (Input.GetKey(KeyCode.Q))
            {
                Application.Quit();
                Debug.Log("Game Quited");
            }
        }
        else
        {
            displayEnd.enabled = false;
        }
    }
}
