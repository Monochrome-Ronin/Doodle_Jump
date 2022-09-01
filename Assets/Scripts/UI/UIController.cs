using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] private Button _playEndeless;
    [SerializeField] private Button _playLevels;
    [SerializeField] private Button _options;
    [SerializeField] private Button _shop;
    [SerializeField] private Button _score;

    private void Start()
    {
        _playEndeless.onClick.AddListener(StartGameEndeless);
        _playLevels.onClick.AddListener(StartGameLeveles);

    }
    private void StartGameEndeless()
    {
        SceneManager.LoadScene("GameScene");
    }
    private void StartGameLeveles()
    {
        SceneManager.LoadScene("GameSceneLeveles");
    }
}
