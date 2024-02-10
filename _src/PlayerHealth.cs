using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private bool isAlive = true;
    public event Action ResetGame;

    private void Update() {
        if(!isAlive)
            ResetGame?.Invoke();
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Danger"))
            isAlive = false;
    }

    public bool GetPlayerAliveState() {
        return isAlive;
    }
}
