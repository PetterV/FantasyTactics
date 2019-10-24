using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public System.Random gameRandom;
    public GameControllerValues savedValues;
    
    public bool pausedByPlayer = false;
    public bool pausedByEvent = false;
    public bool paused = true;

    // Check whether to load old info or generate new
    public bool newGame = true;
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("GameController");
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        savedValues = new GameControllerValues();

        DontDestroyOnLoad(this.gameObject);

        gameRandom = new System.Random();
    }

    public void LoadGameControllerData(GameControllerValues loadedController)
    {
        savedValues.currentMode = loadedController.currentMode;
        newGame = false;
    }
}

// Serialization Value holder
[System.Serializable]
public class GameControllerValues
{
    // String tracking the game mode the game was saved in
    public string currentMode;
}