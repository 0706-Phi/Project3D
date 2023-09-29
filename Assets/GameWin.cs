using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWin : MonoBehaviour
{
    public GameObject gameWin;
    public AudioSource AudioSource;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            gameWin.SetActive(true);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
        AudioSource.Play();
        SceneManager.LoadScene(0);
    }
}
