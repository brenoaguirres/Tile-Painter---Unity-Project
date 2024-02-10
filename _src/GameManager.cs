using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private Timer timer;

    private void Start() {
        //  Subscribe to ResetGame from PlayerHealth
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null) {
            playerHealth = player.GetComponent<PlayerHealth>();
            playerHealth.ResetGame += ResetGame;
        }

        timer = GameObject.FindWithTag("Timer").GetComponent<Timer>();
        if (timer != null) timer.ResetGame += ResetGame;
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
