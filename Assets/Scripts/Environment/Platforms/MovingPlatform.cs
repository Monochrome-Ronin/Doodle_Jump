using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MovingPlatform : Environments
{
    [SerializeField] private float _jumpForce = 8f;
    [SerializeField] private bool _isJump = true;
    [SerializeField] private float _speed = 0.5f;
    private float _contactOffsetY = .69f;
    private bool _moveWay = true;

    public bool IsJump { get => _isJump; }

    public override void Jump(Player player, float jumpForce)
    {
        base.Jump(player, jumpForce);
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
