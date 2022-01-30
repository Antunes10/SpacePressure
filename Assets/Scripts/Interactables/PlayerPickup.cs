using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    public static PlayerPickup Instance;
    public GameObject currentObject;

    void Start() {
        if(Instance == null) Instance = this;
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.X)) {
            Drop();
        }
    }

    public void Pickup(GameObject obj) {
        if(currentObject == null) {
            currentObject = obj;
            currentObject.GetComponent<Rigidbody>().isKinematic = true;
            currentObject.GetComponent<Collider>().enabled = false;

            currentObject.layer = LayerMask.NameToLayer("HeldObject");

            currentObject.transform.parent = transform;
            currentObject.transform.localPosition = Vector3.zero;
            //currentObject.transform.localEulerAngles = Vector3.zero;
        }
    }

    public void Drop() {
        if(currentObject != null) {
            currentObject.layer = LayerMask.NameToLayer("Interactable");
            currentObject.GetComponent<Rigidbody>().isKinematic = false;
            currentObject.GetComponent<Collider>().enabled = true;

            currentObject.transform.parent = null;

            currentObject = null;
        }
    }

}
