using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Commands
{
    public static GameController GetGameCont()
    {
        GameController gameCont = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        return gameCont;
    }
    public static CharacterManager GetCharMgr()
    {
        CharacterManager charMgr = GameObject.FindGameObjectWithTag("CharacterManager").GetComponent<CharacterManager>();
        return charMgr;
    }
}
