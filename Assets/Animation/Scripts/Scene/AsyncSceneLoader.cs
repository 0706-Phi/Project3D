using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class AsyncSceneLoader : MonoBehaviour
{
    public ProgressBar progressBar;
    public string sceneName;
    public float fakeDuretion;

    private AsyncOperation loadingOperation;
    private float startTime;

    public AudioSource audioSource;

    public void StartLoadScene()
    {
        gameObject.SetActive(true);
        DontDestroyOnLoad(this);
        startTime = Time.unscaledTime;
        loadingOperation = SceneManager.LoadSceneAsync(sceneName);
        Time.timeScale = 0;
        audioSource.Play();

    }


    void Update()
    {
        if (loadingOperation == null) return;
        float fakeProgress = (Time.unscaledTime - startTime) / fakeDuretion;

        float finalProgress = Mathf.Min(fakeProgress, loadingOperation.progress);
        progressBar.SetProgressValue(finalProgress);

        if(loadingOperation.isDone && finalProgress >= 1)
        {
            FinishLoading();
        }
    }

    private void FinishLoading()
    {
        Time.timeScale = 1;
        Destroy(gameObject);
    }
}
