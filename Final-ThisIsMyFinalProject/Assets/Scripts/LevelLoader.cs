using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using SimpleJSON;
using UnityEngine;
using File = System.IO.File;

public class LevelLoader : MonoBehaviour
{
    // For LevelLoader
    private const string FILE_DIR = "/Resources/Levels/";
    private const string FILE = "Levels.txt";
    private string FILE_PATH;
    
    // For reading all text from the .txt file
    private string fileContent;
    
    // For parenting and organizing all Instantiated objects
    public GameObject level;
    
    // Offsetting 
    public float offsetX;
    public float offsetZ;
    
    // Index of the currently loaded level
    [SerializeField] private int currentLevel = -1;

    public int CurrentLevel
    {
        get
        {
            return currentLevel;
        }
        set
        {
            currentLevel++;
            
            LoadLevel(currentLevel);
            Debug.Log("CurrentLevel: " + currentLevel);
        }
    }

    // Singleton
    public static LevelLoader instanse;

    private void Awake()
    {
        if (instanse == null)
        {
            instanse = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Check the directory
        if (!Directory.Exists(Application.dataPath + FILE_DIR))
        {
            Directory.CreateDirectory(Application.dataPath + FILE_DIR);
        }
        
        // Set-up the file path
        FILE_PATH = Application.dataPath + FILE_DIR + FILE;
        
        // Check the data file,
        // If file exists, load the content; If not, report error
        if (File.Exists(FILE_PATH))
        {
            fileContent = File.ReadAllText(FILE_PATH);
        }
        else
        {
            Debug.LogError("NO LEVEL DATA FILE EXIST.");
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    // Call this function to load levels
    private void LoadLevel(int levelIndex)
    {
        // Reset the level
        Destroy(level);
        level = new GameObject("Level Objects");

        // Reading the file content
        JSONNode allLevelNode = JSONNode.Parse(fileContent);
        JSONNode levelNode = allLevelNode["lv" + levelIndex + ""];

        JSONArray levelArray = levelNode["ascii"].AsArray;
        
        // Read through each slot of the array
        for (int z = 0; z < levelArray.Count; z++)
        {
            // Put the content in each slot into a string
            string line = levelArray[z].ToString().ToUpper();
            
            // Parse each character in the string into a char array
            char[] characters = line.ToCharArray();
            
            // Read through each char in the array
            for (int x = 0; x < characters.Length; x++)
            {
                char chara = characters[x];

                // Creat game objects
                GameObject newObject = null;
                
                // For different characters in the array, generate different blocks
                switch (chara)
                {
                    case '-': // Empty space
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/Tile"));
                        break;
                    case 'A': // Apple Pie
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/ApplePie"));
                        break;
                    case 'B': // Basket Flower
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/Basket-flower"));
                        break;
                    case 'C': // Cheetah
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/cheetah"));
                        break;
                    case 'E': // Elephant
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/elephant"));
                        break;
                    case 'F': // Flowers
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/Flowers"));
                        break;
                    case 'G': // Grass
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/Grass"));
                        break;
                    case 'H': // Hedgehog
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/hedgehog"));
                        break;
                    case 'I': // Giraffe
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/giraffe"));
                        break;
                    case 'M': // Flamingo
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/flamingo"));
                        break;
                    case 'N': // Next Level trigger
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/NextLevel"));
                        break;
                    case 'O': // Plant-pot
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/Plant-pot"));
                        break;
                    case 'P': // Player
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/Player"));
                        break;
                    case 'R': // End: Raccoon
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/raccoon"));
                        break;
                    case 'U': // Water-can Flower
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/WaterCan-flower"));
                        break;
                    case 'W': // Cow
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/cow"));
                        break;
                    case 'Y': // Yellow Flowers
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/YellowFlowers"));
                        break;
                    case 'Z': // Zebra
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/zebra"));
                        break;
                    default:
                        // newObject = Instantiate(Resources.Load<GameObject>(""));
                        break;
                }
                
                // Put the newObject into the scene
                if (newObject != null)
                {
                    // Parenting the object
                    newObject.transform.parent = level.transform;
                    
                    // Assign the position
                    newObject.transform.position = new Vector3(x + offsetX, 0, -z + offsetZ);
                }
            }
        }
        
    }
}
