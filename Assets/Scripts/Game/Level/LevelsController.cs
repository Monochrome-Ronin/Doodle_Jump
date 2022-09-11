using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelsController : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Text[] _levelsDisplay;
    [SerializeField] Score _score;
    private int _toFinished;
    public int ToFinished { get => _toFinished; }
    private void Start()
    {
        Display();
    }
    private void Update()
    {
        Display();
    }

    private void Display()
    {
        if (_score.score != 0)
            _toFinished = (int)(_score.score * 100 / (Saver.GetIntPrefs("CurrentLevel") * 1000));
        if (_toFinished > 100)
            _toFinished = 100;
        if (_toFinished < 0) _toFinished = 0;
        _levelsDisplay[0].text = "levels: " + Saver.GetIntPrefs("CurrentLevel") + ", " + _toFinished + "%";
        _levelsDisplay[1].text = "you passed: " + _toFinished + "%";
    }
}
