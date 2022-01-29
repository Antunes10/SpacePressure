using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : Interactable
{
    public override void Interact() {
        PlayerPickup.Instance.Pickup(gameObject);
    }
}
