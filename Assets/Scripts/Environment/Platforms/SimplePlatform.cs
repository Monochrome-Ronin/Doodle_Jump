using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlatform : Environments
{
    [SerializeField] private float _jumpForce = 6.5f;
    private float _contactOffsetY = .69f;

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            float offset = collision.transform.position.y - transform.position.y;
            if (collision.relativeVelocity.y > 0 || Mathf.Abs(offset) < _contactOffsetY) return;
            Rigidbody2D rigidbody2D = player.GetComponent<Rigidbody2D>();
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 0);
            rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            player.GetComponent<PlayerMover>().JumpAnim();
        }
    }
}
