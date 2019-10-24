using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameButtonInterface : MonoBehaviour
{
    public void StartGame()
    {
        if (!Commands.GetGameCont().newGame)
        {
            GameObject.FindGameObjectWithTag("StartupManager").GetComponent<StartupManager>().StartLoadedGame();
        }
        else
        {
            GameObject.FindGameObjectWithTag("StartupManager").GetComponent<StartupManager>().StartNewGame();
        }
    }
}
