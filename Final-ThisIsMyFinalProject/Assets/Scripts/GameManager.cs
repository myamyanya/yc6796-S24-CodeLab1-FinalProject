using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Variables 
    public static GameManager instance;
    
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
