using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEnemyController : MonoBehaviour
{
    [SerializeField] AudioSource _audioSource;
    private void Update()
    {
        if (Saver.GetStringPrefs("MuteSound") == "False")
        {
            _audioSource.mute = false;
        }
        else if (Saver.GetStringPrefs("MuteSound") == "True")
        {
            _audioSource.mute = true;
        }
        if (Time.timeScale == 0) _audioSource.mute = true;
        else if (Time.time == 1) _audioSource.mute = false;
    }
}
