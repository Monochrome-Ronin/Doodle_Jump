using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _playerSprite;
    [SerializeField] private float _speed = 7.5f;
    private Rigidbody2D _rigidbody2D;
    private float _horizontalDirectory;
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
#if UNITY_ANDROID_API
        MoveHorizontal();
#endif
    }

    private void MoveHorizontal()
    {
        _horizontalDirectory = Input.acceleration.x;
        if (_horizontalDirectory < 0)
            _playerSprite.flipX = true;
        else if (_horizontalDirectory > 0)
            _playerSprite.flipX = false;
        _rigidbody2D.velocity = new Vector2(_horizontalDirectory * _speed, _rigidbody2D.velocity.y);
    }

    private void ControllHorizontalPostion()
    {
        if (transform.position.x < -3) transform.position = new Vector2(2.7f, transform.position.y);
        else if (transform.position.x > 3) transform.position = new Vector2(-2.7f, transform.position.y);
    }

}
