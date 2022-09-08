using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    [SerializeField] private float _scoreZeroPosition;
    private Player _player;
    public int score;
    private void Start()
    {
        _player = FindObjectOfType<Player>();
    }
    private void Update()
    {
        int score = (int)(_scoreZeroPosition +  _player.transform.position.y * 10);
        if (score > this.score)
        {
            this.score = score;
            Saver.SaveIntPrefs("LastScore", this.score);
            if (this.score > Saver.GetIntPrefs("HighScore")) Saver.SaveIntPrefs("HighScore", this.score);
            _scoreText.text = this.score.ToString();
        }
    }

}
