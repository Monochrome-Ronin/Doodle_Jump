using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController Instance;
    
    [SerializeField] private AudioSource _effectsSource, _buttonsSource;
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

    public void PlaySound(AudioClip clip)
    {
        _effectsSource.PlayOneShot(clip);
    }

    public void PlayButtons()
    {
        _buttonsSource.Play();
    }

    public void MuteSound()
    {
        _effectsSource.mute = !_effectsSource.mute;
        _buttonsSource.mute = !_buttonsSource.mute;
    }
}
