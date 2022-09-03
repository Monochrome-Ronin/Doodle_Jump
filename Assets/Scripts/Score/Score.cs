using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    [SerializeField] private float _scoreZeroPosition;
    private Player _player;
    private int _score;
    private void Start()
    {
        _player = FindObjectOfType<Player>();
    }
    private void Update()
    {
        int score = (int)(_scoreZeroPosition +  _player.transform.position.y * 10);
        if (score > _score)
        {
            _score = score;
            Saver.SaverIntPrefs("LastScore", _score);
            if (_score > Saver.GetIntPrefs("HighScore")) Saver.SaverIntPrefs("HighScore", _score);
            _scoreText.text = _score.ToString();
        }
    }
}
