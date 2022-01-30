using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CablesDamage : MonoBehaviour
{
    public float force;
    void OnCollisionEnter(Collision collision) {
        Debug.Log("Collided with cables");
        collision.gameObject.GetComponent<Rigidbody>()?.AddForce((collision.transform.position - transform.position) * force);
    }
}
