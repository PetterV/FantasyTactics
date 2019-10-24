using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public CharacterValues saveValues = new CharacterValues();
    public string ID;
    public bool isPlayerOwned;
    public string charName;
    public int level;
    public int maxHealth;
    public int atk;
    public int def;
    public int exp;

    // Battle values
    public int currentHealth;

    public void UpdateSaveValues()
    {
        saveValues.id = ID;
        saveValues.charName = charName;
        saveValues.health = maxHealth;
        saveValues.level = level;
        saveValues.atk = atk;
        saveValues.def = def;
    }

    public void LoadSaveValues()
    {
        ID = saveValues.id;
        charName = saveValues.charName;
        maxHealth = saveValues.health;
        level = saveValues.level;
        atk = saveValues.atk;
        def = saveValues.def;
    }

    // Game Objects are only used to make it easier to browse in the editor
    // TODO: Replace with a dedicated game object script class to handle these things?
    public void UpdateGameObjectInfo(CharacterValues c)
    {
        ID = c.id;
        charName = c.charName;
        maxHealth = c.health;
        level = c.level;
        atk = c.atk;
        def = c.def;
    }
}

[System.Serializable]
public class CharacterValues
{
    public string id;
    public bool isPlayerOwned;
    public string charName;
    public int level;
    public int health;
    public int atk;
    public int def;
    public int exp;
}
