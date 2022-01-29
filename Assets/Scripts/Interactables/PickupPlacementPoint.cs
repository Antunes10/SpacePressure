using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PickupPlacementPoint : Interactable
{
    public event Action Complete;
    public GameObject targetObject;
    public bool completed;

    public override void Interact() {
        if(!completed && PlayerPickup.Instance.currentObject != null) {
            if(PlayerPickup.Instance.currentObject == targetObject) {
                //FIXME: talvez passar verificação para nome do objeto para poder
                //          aceitar qualquer objeto que tenha aquela forma (eg: pipe). Requer
                //          é consistência nos nomes dos clones
                GameObject obj = PlayerPickup.Instance.currentObject;

                PlayerPickup.Instance.Drop();

                obj.GetComponent<Rigidbody>().isKinematic = true;
                obj.GetComponent<Collider>().enabled = false;
                obj.transform.parent = transform;
                obj.transform.localPosition = Vector3.zero;
                obj.transform.localEulerAngles = Vector3.zero;

                completed = true;
                Complete?.Invoke();

                GetComponent<MirageObject>().DisableInteraction();
                GetComponent<Collider>().enabled = false;
                GetComponent<MeshRenderer>().enabled = false;
            } else {
                //TODO: wrong object animation
            }
        }
    }

}
