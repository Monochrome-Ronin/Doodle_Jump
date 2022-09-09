using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _enemySpriteRenderer;
    [SerializeField] private AudioClip _clipJump;
    [SerializeField] private AudioClip _clipEnemy;
    [SerializeField] private float _jumpForce = 8f;
    [SerializeField] private bool _isJump = true;
    [SerializeField] private float _speed = 2f;
    [SerializeField] private BoxCollider2D _playerCollider2D;
    private float _contactOffsetY = .69f;
    private bool _moveWay = true;

    public bool IsJump { get => _isJump; }

    private void Start()
    {
        AudioController.Instance.EnemySound();
    }

    public void Jump(Player player, float jumpForce)
    {
        AudioController.Instance.PlaySound(_clipJump);
        Rigidbody2D rigidbody2D = player.GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = new Vector3(rigidbody2D.velocity.x, 0, 0);
        rigidbody2D.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        player.GetComponent<PlayerMover>().JumpAnim();
    }
    public void SetJump()
    {
        _isJump = !_isJump;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player) && _isJump)
        {

            if (_isJump)
            {
                float offset = collision.transform.localPosition.y - transform.localPosition.y;
                if (collision.relativeVelocity.y > 0 || Mathf.Abs(offset) < _contactOffsetY) return;
                Jump(player, _jumpForce);
                Destroy(gameObject);
            }
        }
    }

    void Update()
    {
        if (_moveWay)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(2, transform.position.y), _speed * Time.deltaTime);
            _enemySpriteRenderer.flipX = false;
        }

        else
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(-2, transform.position.y), _speed * Time.deltaTime);
            _enemySpriteRenderer.flipX = true;
        }
           
        if (Mathf.Abs(transform.position.x) == 2 )
            _moveWay = !_moveWay;
    }
}
