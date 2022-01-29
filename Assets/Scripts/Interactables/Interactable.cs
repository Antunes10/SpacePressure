using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Outline))]
public abstract class Interactable : MonoBehaviour
{
    private Outline outline;
    public abstract void Interact();

    public void Highlight() {
        SetOutlineAlpha(1);
    }

    public void EndHighlight() {
        SetOutlineAlpha(0);
    }

    void Start() {
        outline = GetComponent<Outline>();
        SetOutlineAlpha(0);
    }

    void SetOutlineAlpha(float val) {
        Color outlineColor = outline.OutlineColor;
        outlineColor.a = val;
        outline.OutlineColor = outlineColor;
    }
}
