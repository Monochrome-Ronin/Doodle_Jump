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
    [SerializeField] private Button[] _menu;
    [SerializeField] private Button _replay;
    [SerializeField] private GameObject FonPause;
    [SerializeField] private Button _audionControll;
    [SerializeField] private Button _vibrateControll;
    [SerializeField] private Text[] _audioDisplay;
    [SerializeField] private Text[] _vibrateDisplay;
    [SerializeField] private Text[] _scoreDisplay;

    public void GameOver()
    {
        _pause.interactable = false;
        _scoreDisplay[0].text = "high score: " + Saver.GetIntPrefs("HighScore").ToString();
        _scoreDisplay[1].text = "last score: " + Saver.GetIntPrefs("LastScore").ToString();
    }
    private void Start()
    {
        _pause.onClick.AddListener(Pause);
        _resume.onClick.AddListener(Resume);
        _menu[0].onClick.AddListener(GoMenu);
        _menu[1].onClick.AddListener(GoMenu);
        _replay.onClick.AddListener(RePlay);
        _vibrateControll.onClick.AddListener(VibrateControll);
        _audionControll.onClick.AddListener(AudioControll);
        DisplayInfo("MuteSound", _audioDisplay);
        DisplayInfo("MuteVibrate", _vibrateDisplay);
    }
    private void RePlay()
    {
        AudioController.Instance.PlayButtons();
        SceneManager.LoadScene("GameScene");
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
        DisplayInfo("MuteSound", _audioDisplay);
    }
    private void VibrateControll()
    {
        AudioController.Instance.PlayButtons();
        VibrateController.MuteVibrate();
        DisplayInfo("MuteVibrate", _vibrateDisplay);
    }

    private void DisplayInfo(string namePrefs, Text[] text)
    {
        if (Saver.GetStringPrefs(namePrefs) == "False")
        {
            text[0].color = new Color(0.2f, 0.2f, 0.2f, 0.5f);
            text[1].color = new Color(0.03f, 0.6f, 0f, 1f);
        }
        if (Saver.GetStringPrefs(namePrefs) == "True")
        {
            text[1].color = new Color(0.2f, 0.2f, 0.2f, 0.5f);
            text[0].color = new Color(0.03f, 0.6f, 0f, 1f);
        }
    }
}
