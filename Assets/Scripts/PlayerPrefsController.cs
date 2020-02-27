using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    const string MASTER_VOLUME_KEY = "master volume";
    const string DIFFICULTY_KEY = "difficulty";

    const float MIN_VOLUME = 0.0f;
    const float MAX_VOLUME = 1.0f;
    const float DEFAULT_VOLUME = 0.85f;

    const float MIN_DIFFICULTY = 0.5f;
    const float MAX_DIFFICULTY = 1.5f;
    const float DEFAULT_DIFFICULTY_MULTIPLIER = 1.0f;

    public static void SetMasterVolume(float volume)
    {
        if (volume >= MIN_VOLUME && volume <= MAX_VOLUME)
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        }
        else
        {
            Debug.LogError($"{volume} is out of range. Value should be {MIN_VOLUME} to {MAX_VOLUME}");
        }
    }

    public static float GetMasterVolume()
    {
        float masterVolume = PlayerPrefs.GetFloat(MASTER_VOLUME_KEY, DEFAULT_VOLUME);
        return masterVolume;
    }

    public static void ResetMasterVolume()
    {
        PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, DEFAULT_VOLUME);
    }

    public static void SetDifficultyMultiplier(float difficultyMultiplier)
    {
        if (difficultyMultiplier >= MIN_DIFFICULTY && difficultyMultiplier <= MAX_DIFFICULTY)
        {
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficultyMultiplier);
        }
        else
        {
            Debug.LogError($"{difficultyMultiplier} is out of range. Value should be {MIN_DIFFICULTY} to {MAX_DIFFICULTY}");
        }
    }

    public static float GetDifficultyMultiplier()
    {
        float difficultyMultiplier = PlayerPrefs.GetFloat(DIFFICULTY_KEY, DEFAULT_DIFFICULTY_MULTIPLIER);
        return difficultyMultiplier;
    }

    public static void ResetDifficultyMultiplier()
    {
        PlayerPrefs.SetFloat(DIFFICULTY_KEY, DEFAULT_DIFFICULTY_MULTIPLIER);
    }
}
