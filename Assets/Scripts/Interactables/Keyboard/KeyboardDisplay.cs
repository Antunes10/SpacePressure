using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyboardDisplay : MonoBehaviour
{
    public string targetCode;
    public string currentString;
    
    private TextMeshProUGUI textDisplay;

    void Start() {
        textDisplay = GetComponentInChildren<TextMeshProUGUI>();
        UpdateDisplay();
    }

    public void AddCharacter(string character) {
        if(currentString.Length + character.Length <= targetCode.Length) {
            currentString += character;
            UpdateDisplay();
        }

        if(currentString.Length == targetCode.Length) {
            CheckCode();
        }
    }

    void CheckCode() {
        if(currentString == targetCode) {
            StartCoroutine(CodeCorrect());
        } else {
            StartCoroutine(CodeIncorrect());
        }
    }

    void UpdateDisplay() {
        string displayString = "";
        for(int i = 0; i < targetCode.Length; i++) {
            if(i != 0) displayString += " ";
            if(i < currentString.Length) {
                displayString += currentString[i];
            } else {
                displayString += "_";
            }
        }

        if(textDisplay != null) textDisplay.text = displayString;
    }

    IEnumerator CodeIncorrect() {
        yield return new WaitForSeconds(1f);

        currentString = "";
        UpdateDisplay();
    }

    IEnumerator CodeCorrect() {
        yield return new WaitForSeconds(1f);

        if(textDisplay != null) {
            textDisplay.text = "";
            yield return new WaitForSeconds(0.5f);
            textDisplay.text = "*OPEN*";
        }
        
        Debug.Log("CODE ACTIVATED");
        //TODO: activate machine/door
    }
}
