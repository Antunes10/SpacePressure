using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupPuzzle : MonoBehaviour
{
    public PickupPlacementPoint[] placementPoints;
    public int completedCount;

    void Start() {
        completedCount = 0;

        foreach(PickupPlacementPoint point in placementPoints) {
            point.Complete += PlacementPointCompleted;
        }
    }

    void PlacementPointCompleted() {
        if(++completedCount == placementPoints.Length) {
            Debug.Log("PUZZLE COMPLETED");
            //TODO: activate mechanism
        }
    }
}
