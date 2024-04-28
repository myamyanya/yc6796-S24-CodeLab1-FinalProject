using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Windows;
using Input = UnityEngine.Input;

public class GameManager : MonoBehaviour
{
    // Variables 
    public static GameManager instance;
    
    public bool isGameBegined = false;
    
    // Variables of canvas
    public Canvas displayTutorial;
    public TextMeshProUGUI textTutorial;

    public Canvas displayInGame;
    public TextMeshProUGUI textInGame;
    
    // Indicator of interaction
    public TextMeshProUGUI interactionIndicator;
    
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
        
        // Set-up canvas
        displayTutorial = GameObject.Find("DisplayTutorial").GetComponent<Canvas>();
        textTutorial = GameObject.Find("TextBegin").GetComponent<TextMeshProUGUI>();

        // Set-up InGame displaying
        displayInGame = GameObject.Find("DisplayGame").GetComponent<Canvas>();
        textInGame = GameObject.Find("TextInGame").GetComponent<TextMeshProUGUI>();

        interactionIndicator = GameObject.Find("TextInGame_Indicator").GetComponent<TextMeshProUGUI>();

        textInGame.text = "";
        interactionIndicator.text = "";
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
    }
}
