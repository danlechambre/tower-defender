using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private Scene currentScene;
    private MusicPlayer musicPlayer;

    void Start()
    {
        currentScene = SceneManager.GetActiveScene();

        musicPlayer = FindObjectOfType<MusicPlayer>();
        if (!musicPlayer)
        {
            Debug.LogError($"{this.name} could not get reference to MusicPlayer");
            return;
        }
        

        if (currentScene.buildIndex == 0)
        {
            DontDestroyOnLoad(FindObjectOfType<MusicPlayer>());
            musicPlayer.PlayLoadingMusic();
            float splashTransitionTime = FindObjectOfType<AudioSource>().clip.length + 0.25f;
            LoadStartScreen(splashTransitionTime);
        }
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentScene.buildIndex + 1);
    }

    public void LoadNextScene(float timeToWait)
    {
        int sceneToLoad = currentScene.buildIndex + 1;
        if (sceneToLoad >= SceneManager.sceneCountInBuildSettings)
        {
            LoadStartScreen(timeToWait);
        }
        else
        {
            StartCoroutine(SceneTransition(sceneToLoad, timeToWait));
        }
        
    }

    public void LoadFirstLevel()
    {
        musicPlayer.MusicFadeOut(1.0f);
        StartCoroutine(SceneTransition(3, 1.0f));
    }

    public void LoadStartScreen()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadStartScreen(float timeToWait)
    {
        StartCoroutine(SceneTransition(1, timeToWait));
    }

    public void LoadOptionsScreen()
    {
        SceneManager.LoadScene(2);
    }

    IEnumerator SceneTransition(int sceneBuildIndex, float timeToWait)
    {
        yield return new WaitForSeconds(timeToWait);
        if (sceneBuildIndex == 1)
        {
            musicPlayer.PlayMainMenuMusic();
        }
        SceneManager.LoadScene(sceneBuildIndex);
    }
}
