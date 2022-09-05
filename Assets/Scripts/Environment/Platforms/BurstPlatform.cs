using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstPlatform : Environments
{
    [SerializeField] private AudioClip _clipJump;
    [SerializeField] private AudioClip _clipExplosion;
    [SerializeField] private float _jumpForce = 6.5f;
    [SerializeField] private bool _isJump = true;
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private float _animSpeed = 1;
    private int _spriteIndex = 0;
    private float _contactOffsetY = .69f;

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

    private void Start()
    {
        Invoke("ChangeSprite", _animSpeed);
    }

    void ChangeSprite()
    {
        transform.GetComponent<SpriteRenderer>().sprite = _sprites[_spriteIndex];
        _spriteIndex += 1;
        if(_spriteIndex > 3)
        {
            AudioController.Instance.PlaySound(_clipExplosion);
            Destroy(transform.gameObject, 0.1f);
        }
        else
            Invoke("ChangeSprite", _animSpeed);
    }
}
