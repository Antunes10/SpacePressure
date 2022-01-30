using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PickupPlacementPoint : Interactable
{
    public event Action Complete;
    public string targetObjectTag;
    public bool completed;

    public override void Interact() {
        if(!completed && PlayerPickup.Instance.currentObject != null) {
            if(PlayerPickup.Instance.currentObject.tag == targetObjectTag) {

                GameObject obj = PlayerPickup.Instance.currentObject;

                PlayerPickup.Instance.Drop();

                obj.GetComponent<Rigidbody>().isKinematic = true;
                obj.GetComponent<Collider>().enabled = false;
                obj.transform.parent = transform;
                obj.transform.localPosition = Vector3.zero;
                obj.transform.localEulerAngles = Vector3.zero;

                completed = true;
                Complete?.Invoke();

                GetComponent<Collider>().enabled = false;
                GetComponent<MeshRenderer>().enabled = false;
            } else {
                //TODO: wrong object animation
            }
        }
    }

}
