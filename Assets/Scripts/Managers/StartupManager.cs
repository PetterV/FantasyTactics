using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartupManager : MonoBehaviour
{
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("StartupManager");
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void StartNewGame()
    {
        SceneManager.LoadScene("ManagementScene");
        Debug.Log("Loading new scene");
        CharacterManager charMgr = Commands.GetCharMgr();
        charMgr.CreateAllCharacters();

        // Once all setup is done, destroy this object
        Destroy(gameObject);
    }
    public void StartLoadedGame()
    {
        SceneManager.LoadScene("ManagementScene");
        // Once all setup is done, destroy this object
        Destroy(gameObject);
    }
}
