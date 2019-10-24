using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LocalisedText : MonoBehaviour {

	public string key;

	void Start (){
		TextMeshProUGUI text = GetComponent<TextMeshProUGUI> ();
		text.text = LocalisationController.instance.GetLocalisedValue (key);
	}

    public void UpdateText(string newKey)
    {
        key = newKey;
        TextMeshProUGUI text = GetComponent<TextMeshProUGUI>();
        text.text = LocalisationController.instance.GetLocalisedValue(key);
    }
}
