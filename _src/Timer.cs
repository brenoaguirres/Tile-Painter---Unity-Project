using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Animations;

public class Timer : MonoBehaviour
{
    [SerializeField] private int startTime = 120;
    private float currentTime;
    [SerializeField] private DynamicText dynamicText;

    // Subscriptions
    public event Action ResetGame;

    private void Start() {
        currentTime = startTime;
    }

    void Update()
    {
        currentTime -= Time.deltaTime;
        dynamicText.UpdateText(((int)currentTime).ToString());
        CheckForTimeUp();
    }

    private void CheckForTimeUp() {
        if(currentTime <= 0)
            ResetGame?.Invoke();
    }
}
