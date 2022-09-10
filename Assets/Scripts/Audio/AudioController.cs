using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController Instance;
    
    [SerializeField] private AudioSource _effectsSource, _buttonsSource;
    public static void MuteSound()
    {
        bool mute = false;
        if (Saver.GetStringPrefs("MuteSound") == "True") mute = false;
        else if (Saver.GetStringPrefs("MuteSound") == "False") mute = true;
        Saver.SaveStringPrefs("MuteSound", mute.ToString());
    }
    public void Pause()
    {
        _effectsSource.Pause();
    }
    public void Play()
    {
        _effectsSource.UnPause();
    }
    public void PlaySound(AudioClip clip)
    {
        if (Saver.GetStringPrefs("MuteSound") == "True") return;
        _effectsSource.PlayOneShot(clip);
    }

    public void PlayButtons()
    {
        if (Saver.GetStringPrefs("MuteSound") == "True") return;
        _buttonsSource.Play();
    }
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
}
