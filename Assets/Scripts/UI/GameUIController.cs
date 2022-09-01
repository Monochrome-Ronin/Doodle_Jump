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
    [SerializeField] private GameObject FonPause;

    private void Start()
    {
        _pause.onClick.AddListener(Pause);
        _resume.onClick.AddListener(Resume);

    }

    private void Pause()
    {
        FonPause.SetActive(true);
        Time.timeScale = 0; 
    }
    private void Resume()
    {
        FonPause.SetActive(false);
        Time.timeScale = 1;
    }
}
