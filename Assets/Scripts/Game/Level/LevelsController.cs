using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelsController : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Text[] _levelsDisplay;
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
        _toFinished = (int)(_player.transform.position.y / 300 * 100);
        if (_toFinished < 0) _toFinished = 0;
        _levelsDisplay[0].text = "levels: " + Saver.GetIntPrefs("CurrentLevel") + ", " + _toFinished + "%";
        _levelsDisplay[1].text = "you passed: " + _toFinished + "%";
    }
}
