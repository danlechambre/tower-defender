using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private AudioSource music;
    private Scene currentScene;

    void Start()
    {
        music = FindObjectOfType<AudioSource>();
        currentScene = SceneManager.GetActiveScene();
        
        if (currentScene.buildIndex == 0)
        {
            StartCoroutine(SplashToStartTransition());
        }
    }

    IEnumerator SplashToStartTransition()
    {
        yield return new WaitForSeconds(music.clip.length + 0.5f);
        SceneManager.LoadScene(1);
    }
}
