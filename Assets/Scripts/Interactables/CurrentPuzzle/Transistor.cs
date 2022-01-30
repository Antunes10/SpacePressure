using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Transistor : Interactable
{
    public static Transistor MainInstance;
    public event Action Reset;
    public bool isSource;
    public bool canRotate;
    public int[] connections;
    public Transistor[] neighbours;
    public bool hasCurrent;

    public Material connectedMaterial;
    public Material disconnectedMaterial;

    private Image image;
    private RectTransform rectTransform;

    new void Start() {
        if(MainInstance == null) MainInstance = this;

        MainInstance.Reset += ResetState;

        base.Start();
        if(neighbours.Length > 4) {
            Debug.LogError("Invalid number of neighbours");
        }

        image = GetComponentInChildren<Image>();
        rectTransform = GetComponent<RectTransform>();

        if(isSource) {
            hasCurrent = true;
            UpdateCurrent();
        }
    }

    public override void Interact(){
        if(canRotate) {
            rectTransform.eulerAngles = rectTransform.eulerAngles - new Vector3(0, 0, 90);
            for(int i = 0; i < connections.Length; i++) {
                connections[i] = (connections[i]+1)%neighbours.Length;
            }

            MainInstance.Reset?.Invoke();
            //UpdateCurrent();
        }
    }

    void ResetState() {
        hasCurrent = false;
        image.material = disconnectedMaterial;
        if(isSource) UpdateCurrent();
    }

    protected void UpdateCurrent() {
        //if asked to update means its connected
        hasCurrent = true;
        image.material = connectedMaterial;

        for(int i = 0; i < connections.Length; i++) {
            Debug.Log(":" + connections[i] + " " + (connections[i] + neighbours.Length/2)%neighbours.Length);
            if(neighbours[connections[i]] != null && neighbours[connections[i]].neighbours[(connections[i] + neighbours.Length/2)%neighbours.Length] != null) {
                neighbours[connections[i]].UpdateCurrent();
            }
        }
    }

    protected void UpdateCurrent_old() {
        if(isSource){
            hasCurrent = true;
            image.material = connectedMaterial;
            return;
        }

        for(int i = 0; i < connections.Length; i++) {
            Debug.Log(neighbours[connections[i]] != null);
            if(neighbours[connections[i]] != null && neighbours[connections[i]].hasCurrent) {
                if(!hasCurrent) {
                    hasCurrent = true;
                    image.material = connectedMaterial;

                    for(int j = 0; j < connections.Length; j++) {
                        if(neighbours[connections[j]] != null && !neighbours[connections[j]].hasCurrent) neighbours[connections[j]].UpdateCurrent();
                    }
                }
                return;
            }
        }

        //else no current
        hasCurrent = false;
        image.material = disconnectedMaterial;
        for(int j = 0; j < connections.Length; j++) {
            if(neighbours[connections[j]] != null && !neighbours[connections[j]].hasCurrent) neighbours[connections[j]].UpdateCurrent();
        }
    }


}
