using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameflow : MonoBehaviour
{
    public GameObject gameOver;
    public GameObject gameWin;

    public void OnPlayerDied()
    {
        StopGame();
        gameOver.SetActive(true);
    }
    public void OnMissionCompleted()
    {
        StopGame();
        gameWin.SetActive(true);
    }

    public void StopGame()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = false;
    }
}
