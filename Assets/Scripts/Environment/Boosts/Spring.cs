using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : Boost
{
    [SerializeField] private AudioClip _clipSpring;
    [SerializeField] private float _jumpForce = 15f;
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
        transform.position += new Vector3(0, .2f, 0);
    }
}
