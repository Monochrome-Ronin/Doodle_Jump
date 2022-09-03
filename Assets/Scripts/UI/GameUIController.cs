using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameUIController : MonoBehaviour
{
    [SerializeField] private Button _pause;
    [SerializeField] private Button _resume;
    [SerializeField] private Button _menu;
    [SerializeField] private GameObject FonPause;
    [SerializeField] private Button _audioncontroll;
    [SerializeField] private Text[] _audioDisplay;

    private void Start()
    {
        _pause.onClick.AddListener(Pause);
        _resume.onClick.AddListener(Resume);
        _menu.onClick.AddListener(GoMenu);
        _audioncontroll.onClick.AddListener(AudioControll);
        DisplayAudio();
    }
    private void GoMenu()
    {
        AudioController.Instance.PlayButtons();
        Time.timeScale = 1;
        SceneManager.LoadScene("MenuScene");
    }
    private void Pause()
    {
        AudioController.Instance.PlayButtons();
        FonPause.SetActive(true);
        Time.timeScale = 0; 
    }
    private void Resume()
    {
        AudioController.Instance.PlayButtons();
        FonPause.SetActive(false);
        Time.timeScale = 1;
    }
    private void AudioControll()
    {
        AudioController.Instance.PlayButtons();
        AudioController.MuteSound();
        DisplayAudio();
    }

    private void DisplayAudio()
    {
        if (Saver.GetStringPrefs("MuteSound") == "False")
        {
            _audioDisplay[0].color = new Color(0.2f, 0.2f, 0.2f, 0.5f);
            _audioDisplay[1].color = new Color(0.03f, 0.6f, 0f, 1f);
        }
        if (Saver.GetStringPrefs("MuteSound") == "True")
        {
            _audioDisplay[1].color = new Color(0.2f, 0.2f, 0.2f, 0.5f);
            _audioDisplay[0].color = new Color(0.03f, 0.6f, 0f, 1f);
        }
    }
}
