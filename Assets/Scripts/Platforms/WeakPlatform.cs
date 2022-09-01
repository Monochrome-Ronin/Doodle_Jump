using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakPlatform : BasePlatform
{
    [SerializeField] Animator _animator;

    private float _contactOffsetY = .69f;

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            float offset = collision.transform.position.y - transform.position.y;
            if (collision.relativeVelocity.y > 0 || Mathf.Abs(offset) < _contactOffsetY) return;
            _animator.SetTrigger("Jump");
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
