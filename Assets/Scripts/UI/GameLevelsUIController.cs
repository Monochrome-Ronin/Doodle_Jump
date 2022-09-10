using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLevelsUIController : BaseGameUIController
{
    [SerializeField] LevelsController _levelsController;
    public override void DisplayInfoGameOver()
    {
        _scoreDisplay[0].text = "your level: " + Saver.GetIntPrefs("CurrentLevel").ToString();
        _coinsDisplay[0].text = "your coins: " + Saver.GetIntPrefs("Coins").ToString();
        _coinsDisplay[1].text = "continue for: " + Mathf.Clamp(_levelsController.ToFinished * 2, 10, 200);
    }
    protected override void RePlay()
    {
        AudioController.Instance.PlayButtons();
        SceneManager.LoadScene("GameLevelsScene");
    }
    protected override void ContinueGame()
    {
        StartCoroutine(_gameOver.Continue(_levelsController.ToFinished));
    }
}
