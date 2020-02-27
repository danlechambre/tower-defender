using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    private SceneLoader sceneLoader;
    private GameUI ui;
    private MusicPlayer musicPlayer;
    private AttackerSpawner aSpawner;
    private DefenderSpawner dSpawner;

    [Header("Level Config")]
    [Tooltip("Level timer in seconds")]
    [SerializeField]
    private float levelTimer = 30.0f;
    [SerializeField]
    private float sceneTransitionTime = 5.0f;
    [SerializeField]
    private int lives = 5;
    private float difficultyMultiplier;

    private bool gameOver = false;
    private bool gameWin = false;
    IEnumerator timerCountDown;

    [SerializeField]
    private bool timerExpired = false;
    [SerializeField]
    private int attackersCount = 0;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        if (!sceneLoader)
        {
            Debug.LogError("Could not find SceneLoader object");
            return;
        }

        ui = FindObjectOfType<GameUI>();
        if (!ui)
        {
            Debug.LogError("No UI for LevelController");
            return;
        }
        else
        {
            ui.UpdateLivesUI(lives);
            ui.SetTimerSlider(levelTimer);
            timerCountDown = TimerCountDown();
            StartCoroutine(timerCountDown);
        }

        musicPlayer = FindObjectOfType<MusicPlayer>();
        if (!musicPlayer)
        {
            Debug.LogError($"{this.name} could not get MusicPlayer");
            return;
        }
        else
        {
            musicPlayer.PlayBackgroundMusic();
        }

        aSpawner = FindObjectOfType<AttackerSpawner>();
        if (!aSpawner)
        {
            Debug.LogError("LC could not get AttackerSpawner");
            return;
        }
        else
        {
            difficultyMultiplier = PlayerPrefsController.GetDifficultyMultiplier();
            aSpawner.SetDifficulty(difficultyMultiplier);
            aSpawner.StartSpawning();
        }
        
        dSpawner = FindObjectOfType<DefenderSpawner>();
        if (!dSpawner)
        {
            Debug.LogError("LC could not get DefenderSpawner");
            return;
        }
        else
        {
            dSpawner.StartSpawning();
        }
    }

    private IEnumerator TimerCountDown()
    {
        while (levelTimer > 0.0f)
        {
            levelTimer -= Time.deltaTime;
            ui.UpdateTimerSlider(levelTimer);
            yield return new WaitForEndOfFrame();
        }

        aSpawner.StopSpawning();
        timerExpired = true;
    }

    private void LateUpdate()
    {
        if (!gameWin && attackersCount < 1 && timerExpired)
        {
            GameWin();
        }
    
    }

    public void LoseLife()
    {
        if (!gameOver)
        {
            lives -= 1;
            ui.UpdateLivesUI(lives);

            if (lives < 1)
            {
                GameOver();
            }
        } 
    }

    private void GameOver()
    {
        aSpawner.StopSpawning();
        dSpawner.StopSpawning();
        gameOver = true;
        StopCoroutine(timerCountDown);
        ui.ShowGameOverText();
        sceneLoader.LoadStartScreen(sceneTransitionTime);
    }

    private void GameWin()
    {
        dSpawner.StopSpawning();
        gameWin = true;
        musicPlayer.PlayLevelCompleteMusic();
        ui.ShowWinText();
        sceneLoader.LoadNextScene(sceneTransitionTime);
    }

    public void AttackerSpawned()
    {
        attackersCount++;   
    }

    public void AttackerKilled()
    {
        attackersCount--;
    }
}
