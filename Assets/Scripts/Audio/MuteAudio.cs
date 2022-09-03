using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteAudio : MonoBehaviour
{
    [SerializeField] private bool _muteAudio;

    public void Mute()
    {
        if (_muteAudio)
        {
            AudioController.Instance.MuteSound();
        }
    }
}
