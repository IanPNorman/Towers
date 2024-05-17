using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public Audio[] musicAudio, sfxAudio;
    public AudioSource musicSource, sfxSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayMusic("Overworld_Music");
    }
    public void PlayMusic(string name)
    {
        Audio audio = Array.Find(musicAudio, x => x.name == name);

        if (audio == null)
        {
            Debug.Log("Audio not found!");
        }
        else
        {
            musicSource.clip = audio.clip;
            musicSource.Play();
        }
    }

    public void PlaySFX(string name)
    {
        Audio audio = Array.Find(sfxAudio, x => x.name == name);
        if (audio == null)
        {
            Debug.Log("Audio not found!");
        }
        else
        {
            sfxSource.PlayOneShot(audio.clip);
        }
    }

    public void MusicVolume(float volume)
    {
        musicSource.volume = volume;
    }    

    public void SFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }

}
