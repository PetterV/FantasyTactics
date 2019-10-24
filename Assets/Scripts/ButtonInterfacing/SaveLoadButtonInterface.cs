using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadButtonInterface : MonoBehaviour
{
    public void SaveGame()
    {
        SavegameManager.SaveAll();
    }

    public void LoadGame()
    {
        SavegameManager.LoadAll();
    }

    public void ChangeSaveSlot(int slot)
    {
        SavegameManager.SetFileSlot(slot);
    }
}
