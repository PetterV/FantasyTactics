using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public static class SavegameManager
{
    public static string fileSlot = "SaveSlot1";
    public static void SetFileSlot(int slot)
    {
        fileSlot = "SaveSlot" + slot.ToString();
        Debug.Log("Save slot set to slot " + slot.ToString());
    }

    static void SaveGameController()
    {
        string directoryPath = Application.persistentDataPath + "/" + fileSlot;
        Debug.Log("Saving Game Controller to directory " + directoryPath);
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(directoryPath + "/GameController.save");
        bf.Serialize(file, Commands.GetGameCont().savedValues);
        file.Close();
    }
    static void LoadGameController()
    {
        string directoryPath = Application.persistentDataPath + "/" + fileSlot;
        if (File.Exists(directoryPath + "/GameController.save"))
        {
            GameControllerValues loadedController = new GameControllerValues();
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(directoryPath + "/GameController.save", FileMode.Open);
            loadedController = (GameControllerValues)bf.Deserialize(file);
            file.Close();
            Commands.GetGameCont().LoadGameControllerData(loadedController);
        }
        else
        {
            Debug.Log("No save file found for slot!");
        }
    }

    public static void SaveAll()
    {
        SaveGameController();
    }

    public static void LoadAll()
    {
        LoadGameController();
    }

    public static void DeleteSaveInSlot(string fileSlot)
    {
        DirectoryInfo di = new DirectoryInfo(Application.persistentDataPath + "/" + fileSlot);
        foreach (FileInfo f in di.GetFiles())
        {
            f.Delete();
        }
    }
}
