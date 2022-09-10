using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : Environments
{
    [SerializeField] private AudioClip _clipEnemy;
    [SerializeField] private float _jumpForce = 8f;
    [SerializeField] private bool _isJump = true;
    [SerializeField] private Vector2 _contactOffset = new Vector2(0.5f, 1f);
    private BoxCollider2D _playerCollider2D;
    
    public bool IsJump { get => _isJump; }
    
    public override void Jump(Player player, float jumpForce)
    {
        base.Jump(player, jumpForce);
        
    }

    public void SetJump()
    {
        _isJump = !_isJump;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {

            if (_isJump)
            {
                Vector2 offset = new Vector2(collision.transform.localPosition.x - transform.localPosition.x,collision.transform.localPosition.y - transform.localPosition.y);
                if (collision.relativeVelocity.y < 0 || (Mathf.Abs(offset.y) > _contactOffset.y && Mathf.Abs(offset.x) < _contactOffset.x))
                {
                    Jump(player, _jumpForce);
                    AudioController.Instance.PlaySound(_clipEnemy);
                    Destroy(gameObject);
                }
                else
                {
                    player.PlayerRigidbody2D.velocity = Vector2.zero;
                    player.SetLayer("GameOver");
                }
            }
        }
    }
}
