using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    // Cached Components
    private MeshRenderer myMeshRenderer;

    // Variables
    private Color baseColor;
    [SerializeField] private Color paintedColor = Color.red;
    private bool isPainted = false;

    private void Awake() {
        myMeshRenderer = GetComponentInParent<MeshRenderer>();
        baseColor = myMeshRenderer.material.color;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player"))
        {
            if (!isPainted) myMeshRenderer.material.color = paintedColor;
            else myMeshRenderer.material.color = baseColor;
            isPainted = !isPainted;
            other.BroadcastMessage("SetNormalSpeed");
        }
    }

    public bool Painted() {
        return isPainted;
    }
}
