using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Trampoline : Boost
{
    [SerializeField] private AudioClip _clipSpring;
    [SerializeField] private float _jumpForce = 20f;
    [SerializeField] private Sprite _activeSpring;
    private float _contactOffsetY = .60f;
    protected override void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.TryGetComponent(out Player player))
        {
            float offset = collider2D.transform.localPosition.y - transform.localPosition.y;
            if (player.transform.GetComponent<Rigidbody2D>().velocity.y > 0 || Mathf.Abs(offset) < _contactOffsetY) return;
            Jump(player, _jumpForce);
        }
    }
    public void Jump(Player player, float jumpForce)
    {
        AudioController.Instance.PlaySound(_clipSpring);
        Rigidbody2D rigidbody2D = player.GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 0);
        rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        player.GetComponent<PlayerMover>().JumpAnim();
        transform.GetComponent<SpriteRenderer>().sprite = _activeSpring;
        transform.position += new Vector3(0, .1f, 0);
        player.transform.DORotate(new Vector3(0, 0, 360), 1, RotateMode.FastBeyond360) ;
    }
}
