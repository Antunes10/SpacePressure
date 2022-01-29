using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyboardKey : Interactable
{
    public override void Interact() {
        KeyboardDisplay display = transform.parent.GetComponentInChildren<KeyboardDisplay>();
        string character = transform.GetComponentInChildren<TextMeshProUGUI>().text;
        display.AddCharacter(character);
    }
}
