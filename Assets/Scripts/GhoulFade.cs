using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhoulFade : MonoBehaviour
{
    public float distanceStart = 16;
    public float distanceEnd = 10;
    public Renderer renderer;

    private GameObject player;
    private float minDistance = 1000;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update() {
        transform.LookAt(player.transform, Vector3.up);

        float distance = Vector3.Distance(player.transform.position, transform.position);

        if(distance < distanceStart && distance > distanceEnd && distance < minDistance) {
            Color meshColor = renderer.material.color;
            meshColor.a = (distance - distanceEnd) / (distanceStart - distanceEnd);
            renderer.material.color = meshColor;

            minDistance = distance;

        } else if(distance <= distanceEnd) {
            Destroy(gameObject);
        }
    }

}
