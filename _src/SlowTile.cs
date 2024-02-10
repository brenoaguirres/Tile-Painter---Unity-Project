using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTile : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            other.BroadcastMessage("SetSlow");
        }
    }
}
