using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private Scene currentScene;

    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        
        if (currentScene.buildIndex == 0)
        {
            float splashTransitionTime = FindObjectOfType<AudioSource>().clip.length + 0.25f;
            StartCoroutine(SceneTransition(splashTransitionTime));
        }
    }

    IEnumerator SceneTransition(float timeToWait)
    {
        yield return new WaitForSeconds(timeToWait);
        SceneManager.LoadScene(1);
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentScene.buildIndex + 1);
    }

    public void LoadNextScene(float timeToWait)
    {
        StartCoroutine(SceneTransition(timeToWait));
    }
}
