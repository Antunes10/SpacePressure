using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public float interactDistance;
    public LayerMask layerMask;

    private Interactable highlightedObject;
    void Update() {
        Transform camera = Camera.main.transform;
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        Debug.DrawRay(camera.position, camera.TransformDirection(Vector3.forward) * interactDistance, Color.yellow);
        if (Physics.Raycast(camera.position, camera.TransformDirection(Vector3.forward), out hit, interactDistance, layerMask))
        {
            Interactable interactable = hit.collider.gameObject.GetComponent<Interactable>();
            if(interactable != null) {
                if(highlightedObject != null && interactable != highlightedObject) {
                    highlightedObject.EndHighlight();
                }

                interactable.Highlight();
                highlightedObject = interactable;

                if(Input.GetKeyDown(KeyCode.Mouse0)) {
                    highlightedObject.Interact();
                }
            }

            
        } else if (highlightedObject != null) {
            highlightedObject.EndHighlight();
            highlightedObject = null;
        }
        
    }
}
