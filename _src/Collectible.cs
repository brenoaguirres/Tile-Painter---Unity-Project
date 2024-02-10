using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] private int scoreValue = 100;
    [SerializeField] private float rotationMoveSpeed = 1;

    private void Update() {
        RotatingMovement();
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Player")) {
            other.gameObject.GetComponent<Score>().AddScore(scoreValue);
            gameObject.SetActive(false);
        }
    }

    private void RotatingMovement() {
        transform.Rotate(0, rotationMoveSpeed ,0);
    }
}
