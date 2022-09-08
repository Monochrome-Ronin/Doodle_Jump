using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] bool _isMover = true;
    [SerializeField] private float _speed = 7.5f;
    [SerializeField] private float _jumpAnimTime = .2f;
    [Header("Sprite")]
    [SerializeField] private SpriteRenderer _playerSpriteRenderer;
    [SerializeField] private Sprite _jumpSprite;
    [SerializeField] private Sprite _idleSprite;
    [Header("Image")]
    [SerializeField] private Image _playerImage;
    private Rigidbody2D _rigidbody2D;
    private float _horizontalDirectory;
    private bool _isPhone;

    public Sprite JumpSprite { get => _jumpSprite; set => _jumpSprite = value; }
    public Sprite IdleSprite { get => _idleSprite; set => _idleSprite = value; }

    private void Start()
    {
#if UNITY_ANDROID_API
        _isPhone = true;
#endif
#if UNITY_EDITOR
        _isPhone = false;
#endif
        _rigidbody2D = GetComponent<Rigidbody2D>();
        if (_playerSpriteRenderer != null) _playerSpriteRenderer.sprite = _idleSprite;
        else _playerImage.sprite = _idleSprite;
    }
    private void Update()
    {
        ControllHorizontalPostion();

    }
    private void FixedUpdate()
    {
        if (_isMover == false) return;
        if (_isPhone) _horizontalDirectory = Input.acceleration.x;
        else if (!_isPhone) _horizontalDirectory = Input.GetAxis("Horizontal");
        MoveHorizontal();
    }
    private void MoveHorizontal()
    {
        if (_horizontalDirectory < 0 && _playerSpriteRenderer != null)
            _playerSpriteRenderer.flipX = true;
        else if (_horizontalDirectory > 0 && _playerSpriteRenderer != null)
            _playerSpriteRenderer.flipX = false;
        _rigidbody2D.velocity = new Vector3(_horizontalDirectory * _speed, _rigidbody2D.velocity.y, 0);
    }
    private void ControllHorizontalPostion()
    {
        if (transform.position.x < -3) transform.position = new Vector3(2.7f, transform.position.y, -1);
        else if (transform.position.x > 3) transform.position = new Vector3(-2.7f, transform.position.y, -1);
    }
    public void JumpAnim()
    {
        if (_playerSpriteRenderer != null) _playerSpriteRenderer.sprite = _jumpSprite;
        else _playerImage.sprite = _jumpSprite;
        Invoke("SetSpriteback", _jumpAnimTime);
    }
    private void SetSpriteback()
    {
        if (_playerSpriteRenderer != null) _playerSpriteRenderer.sprite = _idleSprite;
        else _playerImage.sprite = _idleSprite;
    }
}
