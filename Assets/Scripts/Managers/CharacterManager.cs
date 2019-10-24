using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;
using System.Xml.Linq;

public class CharacterManager : MonoBehaviour
{
    public bool loadCharactersOnLoad = false;
    public bool charactersExist = false;
    public Sprite fallbackBattleSprite;
    public Sprite fallbackDialogueSprite;
    public GameObject characterPrefab;
    public List<CharacterValues> loadedCharacterValues = new List<CharacterValues>();
    public List<Character> allCharacters = new List<Character>();
    public List<Character> playerCharacters = new List<Character>();
    public List<Character> battleCharacters = new List<Character>();

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("CharacterManager");
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    void LoadCharactersFromFile(string filePath)
    {
        Debug.Log("Trying to load characters from file: " + filePath);
        // Load characters from script files
        List<CharacterValues> charactersInFile = new List<CharacterValues>();
        charactersInFile =
            (
                from c in XDocument.Load(filePath).Root.Elements("character")
                select new CharacterValues
                {
                    id = (string)c.Element("id"),
                    charName = (string)c.Element("name"),
                    level = (int)c.Element("level"),
                    health = (int)c.Element("health"),
                    atk = (int)c.Element("atk"),
                    def = (int)c.Element("def"),
                }
            ).ToList();

        if (charactersInFile.Count == 0)
        {
            Debug.LogError("Loading characters failed, somehow!");
        }

        // Add the list to the full character list
        loadedCharacterValues.AddRange(charactersInFile);
    }
    public void CreateAllCharacters()
    {
        // Find the file path to the character profiles
        string filePath = Path.Combine(Application.streamingAssetsPath, "Characters\\CharacterProfiles");
        
        // Load each json file found there
        foreach (string file in Directory.EnumerateFiles(filePath, "*.xml"))
        {
            LoadCharactersFromFile(file);
        }

        // Load the definition of which characters should be player owned
        List<string> startCharacters = File.ReadAllLines(filePath + "\\StartingCharacterIDs.txt").ToList();

        // Create character game objects and organise them
        foreach (CharacterValues c in loadedCharacterValues){
            GameObject newCharacter = Instantiate(characterPrefab);
            Character charScript = newCharacter.GetComponent<Character>();
            charScript.UpdateGameObjectInfo(c);
            charScript.UpdateSaveValues();
            allCharacters.Add(charScript);
            // Assign relevant characters as player characters
            if (startCharacters.Contains(charScript.ID))
            {
                c.isPlayerOwned = true;
                playerCharacters.Add(charScript);
            }
            newCharacter.name = charScript.ID;
            newCharacter.transform.SetParent(GameObject.FindGameObjectWithTag("CharacterContainer").transform);
        }
        
        if (allCharacters.Count == 0)
        {
            Debug.LogError("Failed to create any characters!");
        }

        if (playerCharacters.Count == 0)
        {
            Debug.LogError("No player characters found!");
        }
    }
}
