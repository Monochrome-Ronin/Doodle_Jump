using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] bool _isMover = true;
    [SerializeField] private float _speed = 7.5f;
    [SerializeField] private float _jumpAnimTime = .2f;
    private Rigidbody2D _rigidbody2D;
    private float _horizontalDirectory;
    private Boost _currentBoost;
    public Boost CurrentBoost { get => _currentBoost; set => _currentBoost = value; }

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();       
    }
    private void Update()
    {
        ControllHorizontalPostion();

    }
    private void FixedUpdate()
    {
        if (_isMover == false) return;
        if (Application.platform == RuntimePlatform.Android) _horizontalDirectory = Input.acceleration.x;
        else if (Application.isEditor) _horizontalDirectory = Input.GetAxis("Horizontal");
        MoveHorizontal();
    }
    private void MoveHorizontal()
    {
        if (_horizontalDirectory < 0 && _player.PlayerSpriteRenderer != null && !_player.IsShoot)
            _player.PlayerSpriteRenderer.flipX = true;
        else if (_horizontalDirectory > 0 && _player.PlayerSpriteRenderer != null && !_player.IsShoot)
            _player.PlayerSpriteRenderer.flipX = false;
        _rigidbody2D.velocity = new Vector3(_horizontalDirectory * _speed, _rigidbody2D.velocity.y, 0);
    }
    private void ControllHorizontalPostion()
    {
        if (transform.position.x < -3) transform.position = new Vector3(2.7f, transform.position.y, -1);
        else if (transform.position.x > 3) transform.position = new Vector3(-2.7f, transform.position.y, -1);
    }
    public IEnumerator JumpAnim()
    {
        _player.JumpAnim();
        yield return new WaitForSeconds(_jumpAnimTime);
        _player.IdelAnim();
    }
}
