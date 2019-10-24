using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagementScreenManager : MonoBehaviour
{
    public GameObject characterList;
    // Start is called before the first frame update
    void Start()
    {
        List<Character> charList = GameObject.FindGameObjectWithTag("CharacterManager").GetComponent<CharacterManager>().playerCharacters;
        characterList.GetComponent<ManagementScreenCharacterList>().CharListSetUp(charList);
    }
}
