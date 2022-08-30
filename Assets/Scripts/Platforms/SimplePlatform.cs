using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlatform : BasePlatform
{
    [SerializeField] private float _jumpForce = 6.5f;

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            if (collision.relativeVelocity.y > 0) return;
            Rigidbody2D rigidbody2D = player.GetComponent<Rigidbody2D>();
            rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }
}
