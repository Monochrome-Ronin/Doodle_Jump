using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MovingPlatform : Environments
{
    [SerializeField] private AudioClip _clipJump;
    [SerializeField] private float _jumpForce = 8f;
    [SerializeField] private bool _isJump = true;
    [SerializeField] private float _speed = 0.5f;
    private float _contactOffsetY = .69f;
    private bool _moveWay = true;

    public bool IsJump { get => _isJump; }

    public void Jump(Player player, float jumpForce)
    {
        AudioController.Instance.PlaySound(_clipJump);
        Rigidbody2D rigidbody2D = player.GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 0);
        rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        player.GetComponent<PlayerMover>().JumpAnim();
    }
    public void SetJump()
    {
        _isJump = !_isJump;
    }
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player) && _isJump)
        {
            float offset = collision.transform.localPosition.y - transform.localPosition.y;
            if (collision.relativeVelocity.y > 0 || Mathf.Abs(offset) < _contactOffsetY) return;
            Jump(player, _jumpForce);
        }
    }

    void Update()
    {
        if(_moveWay)
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(2, transform.position.y), _speed * Time.deltaTime);
        else
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(-2, transform.position.y), _speed * Time.deltaTime);
        if (Mathf.Abs(transform.position.x) == 2 )
            _moveWay = !_moveWay;
    }
}
