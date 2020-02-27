using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [Header("Music Playlist")]
    [SerializeField]
    private AudioClip[] playlist;

    private AudioSource audioSource;

    private void Awake()
    {
        if (FindObjectsOfType<MusicPlayer>().Length > 1)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefsController.GetMasterVolume();
    }

    public void PlayLoadingMusic()
    {
        audioSource.Stop();
        audioSource.clip = playlist[0];
        audioSource.loop = false;
        audioSource.Play();
    }

    public void PlayMainMenuMusic()
    {
        if (audioSource.clip != playlist[1])
        {
            audioSource.Stop();
            audioSource.clip = playlist[1];
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    public void PlayBackgroundMusic()
    {
        audioSource.Stop();
        audioSource.clip = playlist[2];
        audioSource.loop = true;
        audioSource.Play();
    }

    public void PlayLevelCompleteMusic()
    {
        audioSource.Stop();
        audioSource.clip = playlist[3];
        audioSource.loop = false;
        audioSource.Play();
    }

    public void MusicFadeOut(float fadeTimer)
    { 
        StartCoroutine(FadeOut(fadeTimer));
    }

    public void SetVolume(float volume)
    {
        PlayerPrefsController.SetMasterVolume(volume);
        audioSource.volume = volume;
    }

    public float GetVolume()
    {
        return PlayerPrefsController.GetMasterVolume();
    }

    IEnumerator FadeOut(float fadeTimer)
    {
        while (audioSource.volume > 0)
        {
            audioSource.volume -= fadeTimer * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        audioSource.Stop();
        audioSource.volume = PlayerPrefsController.GetMasterVolume();
    }
}
