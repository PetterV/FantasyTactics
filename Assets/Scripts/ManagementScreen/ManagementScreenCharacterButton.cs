using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ManagementScreenCharacterButton : MonoBehaviour
{
    public Character character;

    public TextMeshProUGUI idDisplay;
    public TextMeshProUGUI nameDisplay;
    public TextMeshProUGUI levelDisplay;
    public TextMeshProUGUI maxHealthDisplay;
    public TextMeshProUGUI attackDisplay;
    public TextMeshProUGUI defenseDisplay;

    public void UpdateMgmtScreenCharButton()
    {
        idDisplay.text = "ID: " + character.ID;
        nameDisplay.GetComponent<LocalisedText>().UpdateText(character.charName);
        levelDisplay.text = "Level: " + character.level;
        maxHealthDisplay.text = "Max health: " + character.maxHealth;
        attackDisplay.text = "Atk: " + character.atk;
        defenseDisplay.text = "Def: " + character.def;
        // Example for later implementation
        //classDisplay.GetComponent<LocalisedText>().key = character.characterClass.className;
    }
}
