using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Player _player;
    [SerializeField] private CanvasGroup _gameOver;
    [SerializeField] private AudioClip _clipFall;
    
    public bool _playerFall;

   
    private void FixedUpdate()
    {
        if (_player.transform.position.y > transform.position.y || _playerFall)
        {
            Vector3 currentPostionCamera = Vector3.MoveTowards(transform.position, _player.transform.position, 1f);
            transform.position = new Vector3(transform.position.x, currentPostionCamera.y, transform.position.z);
        }

        if (_playerFall)
        {
            Invoke("StopFall", 1f);
        }
    }

    private void StopFall()
    {
        GameOver(_gameOver);
        _playerFall = false;
    }

    private void GameOver(CanvasGroup canvasGroup)
    {
        Animations.DoMove(canvasGroup.transform, new Vector3(0, 0, 0));
    }
}
