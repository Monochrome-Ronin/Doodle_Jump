using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] Player _player;
    [SerializeField] CameraController _cameraController;
    [SerializeField] private CanvasGroup _gameOver;
    [SerializeField] private AudioClip _clipFall;
    [SerializeField] private GameUIController _gameUIController;
    public IEnumerator Fall()
    {
        AudioController.Instance.PlaySound(_clipFall);
        _gameUIController.GameOver();
        _player.GetComponent<BoxCollider2D>().enabled = false;
        _cameraController.PlayerFall = true;
        yield return new WaitForSeconds(0.7f);
        Animations.DoMove(_gameOver.transform, new Vector3(0, 0, 0));
        _cameraController.PlayerFall = false;
    }
}
