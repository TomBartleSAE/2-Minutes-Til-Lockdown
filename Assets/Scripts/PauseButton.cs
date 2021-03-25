using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        switch (GameManager.gameState)
        {
            case GameManager.GameState.Play:
                Time.timeScale = 0;
                GameManager.gameState = GameManager.GameState.Paused;
                break;
            case GameManager.GameState.Paused:
                Time.timeScale = 1;
                GameManager.gameState = GameManager.GameState.Play;
                break;
            default:
                break;
        }
    }
}
