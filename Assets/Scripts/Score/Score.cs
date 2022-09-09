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

    public int score { get => _score; }

    private void Start()
    {
        _player = FindObjectOfType<Player>();
    }
    private void Update()
    {
        int score = (int)(_scoreZeroPosition +  _player.transform.position.y * 10);
        if (score > this._score)
        {
            this._score = score;
            Saver.SaveIntPrefs("LastScore", this._score);
            if (this._score > Saver.GetIntPrefs("HighScore")) Saver.SaveIntPrefs("HighScore", this._score);
            _scoreText.text = this._score.ToString();
        }
    }

}
