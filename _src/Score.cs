using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    private int score = 0;
    [SerializeField] private DynamicText scoreText;

    public void AddScore(int value) {
        score += value;
        scoreText.UpdateText(score.ToString());
    }

    public int GetScore() {
        return score;
    }
}
