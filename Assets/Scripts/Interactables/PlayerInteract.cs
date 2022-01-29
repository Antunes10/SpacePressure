using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public float interactDistance;
    public LayerMask layerMask;
    void Update() {
        if(Input.GetKeyDown(KeyCode.Mouse0)) {
            Transform camera = Camera.main.transform;
            RaycastHit hit;
            // Does the ray intersect any objects excluding the player layer
            Debug.DrawRay(camera.position, camera.TransformDirection(Vector3.forward) * interactDistance, Color.yellow);
            if (Physics.Raycast(camera.position, camera.TransformDirection(Vector3.forward), out hit, interactDistance, layerMask))
            {
                hit.collider.gameObject.GetComponent<Interactable>()?.Interact();
            }
        }
    }
}
