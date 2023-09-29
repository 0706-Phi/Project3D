using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject Over;
    public AudioSource AudioSource;
    public void OverGame()
    {
        Over.SetActive(true);
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene("MainMenu");
        AudioSource.Play();

    }
    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
        AudioSource.Play();
    }
}
