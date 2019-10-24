using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ManagementScreenCharacterList : MonoBehaviour
{

    public GameObject characterButton;
    public bool ListPopulated = false;
    public TextMeshProUGUI header;
    public int currentlyDisplayedLeague;

    public void CharListSetUp(List<Character> characterList)
    {
        if (!ListPopulated)
        {
            PopulateList(characterList);
        }
    }

    public void EmptyCharList()
    {
        GameObject[] objectsToDestroy = GameObject.FindGameObjectsWithTag("CharacterListButton");
        foreach (GameObject button in objectsToDestroy)
        {
            if (button.activeSelf)
            {
                Destroy(button);
            }
        }
    }

    void PopulateList(List<Character> characterList)
    {
        foreach (Character c in characterList)
        {
            GameObject newButton = Instantiate(characterButton) as GameObject;
            newButton.transform.SetParent(characterButton.transform.parent);
            newButton.transform.localScale = characterButton.transform.localScale;
            ManagementScreenCharacterButton newButtonInfo = newButton.GetComponent<ManagementScreenCharacterButton>();
            newButtonInfo.character = c;
            newButtonInfo.nameDisplay.text = c.charName;
            newButtonInfo.idDisplay.text = c.ID;
            newButton.SetActive(true);
            newButtonInfo.UpdateMgmtScreenCharButton();
        }
        ListPopulated = true;
    }

    public void ClearList()
    {
        //TODO: Add functions here to destroy all relevant buttons
        ListPopulated = false;
    }
}
