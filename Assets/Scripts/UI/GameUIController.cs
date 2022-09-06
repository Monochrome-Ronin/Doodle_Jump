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
    [SerializeField] private Button _continueGame;
    [SerializeField] private Text[] _audioDisplay;
    [SerializeField] private Text[] _vibrateDisplay;
    [SerializeField] private Text[] _scoreDisplay;
    [SerializeField] private Text[] _coinsDisplay;
    [SerializeField] private GameOver _gameOver;
    [SerializeField] private AudioClip _startAudio;
    public void ControllPausebutton(bool tap)
    {
        _pause.interactable = tap;
    }
    public void DisplayInfoGameOver()
    {
        _scoreDisplay[0].text = "high score: " + Saver.GetIntPrefs("HighScore").ToString();
        _scoreDisplay[1].text = "last score: " + Saver.GetIntPrefs("LastScore").ToString();
        _coinsDisplay[0].text = "your coins: " + Saver.GetIntPrefs("Coins").ToString();
        _coinsDisplay[1].text = "continue for: " + (int)(Mathf.Clamp(2 * (Saver.GetIntPrefs("LastScore") / 100), 10, 99));
    }
    private void Start()
    {
        AudioController.Instance.PlaySound(_startAudio);
        _pause.onClick.AddListener(Pause);
        _resume.onClick.AddListener(Resume);
        _menu[0].onClick.AddListener(GoMenu);
        _menu[1].onClick.AddListener(GoMenu);
        _replay.onClick.AddListener(RePlay);
        _vibrateControll.onClick.AddListener(VibrateControll);
        _audionControll.onClick.AddListener(AudioControll);
        _continueGame.onClick.AddListener(ContinueGame);
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
    private void ContinueGame()
    {
        StartCoroutine(_gameOver.Continue());
    }
}
