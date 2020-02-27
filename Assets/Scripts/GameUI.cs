using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    private Text livesText;
    private Text starsText;
    private GameObject gameOverText;
    private GameObject winText;
    private Slider timerSlider;

    void Start()
    {
        livesText = GameObject.Find("Lives txt").GetComponent<Text>();
        if (!livesText)
        {
            Debug.LogError("Could not find Lives txt GameObject");
        }

        starsText = GameObject.Find("Stars txt").GetComponent<Text>();
        if (!starsText)
        {
            Debug.LogError("Could not find Stars txt GameObject");
        }

        gameOverText = GameObject.Find("Game Over txt");
        if (!gameOverText)
        {
            Debug.LogError("Could not find GameOverTxt object");
        }
        else
        {
            gameOverText.SetActive(false);
        }

        winText = GameObject.Find("Win txt");
        if (!winText)
        {
            Debug.LogError("Could not find WinText object");
        }
        else
        {
            winText.SetActive(false);
        }

        timerSlider = GameObject.Find("Timer").GetComponent<Slider>();
        if (!timerSlider)
        {
            Debug.LogError("Could not find Selectable object");
        }
    }

    public void UpdateLivesUI(int lives)
    {
        livesText.text = lives.ToString();
    }

    public void UpdateStarsUI(int stars)
    {
        starsText.text = stars.ToString();
    }

    public void ShowGameOverText()
    {
        gameOverText.SetActive(true);
    }

    public void ShowWinText()
    {
        winText.SetActive(true);
    }

    public void SetTimerSlider(float timerLength)
    {
        timerSlider.maxValue = timerLength;
        timerSlider.value = timerSlider.maxValue;
    }

    public void UpdateTimerSlider(float timerValue)
    {
        timerSlider.value = timerValue;
    }
}
