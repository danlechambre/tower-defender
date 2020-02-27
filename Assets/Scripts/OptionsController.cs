using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    private MusicPlayer musicPlayer;
    private Slider volumeSlider;
    private Slider difficultySlider;

    private void Start()
    {
        volumeSlider = GameObject.Find("Volume slider").GetComponent<Slider>();
        difficultySlider = GameObject.Find("Difficulty slider").GetComponent<Slider>();

        musicPlayer = FindObjectOfType<MusicPlayer>();
        if (!musicPlayer)
        {
            Debug.LogError($"{this.name} could not get Music Player reference");
            return;
        }
        else
        {
            volumeSlider.value = musicPlayer.GetVolume();
        }

        difficultySlider.value = PlayerPrefsController.GetDifficultyMultiplier();
    }

    public void ChangeVolume(float volume)
    {
        musicPlayer.SetVolume(volume);
    }

    public void ChangeDifficulty(float difficulty)
    {
        PlayerPrefsController.SetDifficultyMultiplier(difficulty);
    }

    public void SetDefaults()
    {
        PlayerPrefsController.ResetMasterVolume();
        volumeSlider.value = musicPlayer.GetVolume();

        PlayerPrefsController.ResetDifficultyMultiplier();
        difficultySlider.value = PlayerPrefsController.GetDifficultyMultiplier();
    }
}
