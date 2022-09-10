using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlatform : Environments
{
    [SerializeField] private AudioClip _clipJump;
    [SerializeField] private float _jumpForce = 6.5f;
    [SerializeField] private bool _isJump = true;
    private float _contactOffsetY = .69f;

    public bool IsJump { get => _isJump; }

    public override void JumpPlatform(Player player, float jumpForce)
    {
        AudioController.Instance.PlaySound(_clipJump);
        base.JumpPlatform(player, jumpForce);
    }
    public void SetJump(bool jump)
    {
        _isJump = jump;
    }
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player) && _isJump)
        {
            float offset = collision.transform.localPosition.y - transform.localPosition.y;
            if (collision.relativeVelocity.y > 0 || Mathf.Abs(offset) < _contactOffsetY) return;
            JumpPlatform(player, _jumpForce);
        }
    }
}
