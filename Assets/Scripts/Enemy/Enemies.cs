using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : Environments
{
    [SerializeField] private float _jumpForce = 8f;
    [SerializeField] private Vector2 _contactOffset = new Vector2(0.5f, 1f);    
    
    public override void Jump(Player player, float jumpForce, float jumpAnim = 0.2f) => base.Jump(player, jumpForce, jumpAnim);
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {

            Vector2 offset = new Vector2(collision.transform.localPosition.x - transform.localPosition.x, collision.transform.localPosition.y - transform.localPosition.y);
            if (collision.relativeVelocity.y < 0 || (Mathf.Abs(offset.y) > _contactOffset.y && Mathf.Abs(offset.x) < _contactOffset.x))
            {
                Jump(player, _jumpForce, -1f);
                Destroy(gameObject);
            }
            else
            {
                player.PlayerRigidbody2D.velocity = Vector2.zero;
                player.SetLayer("GameOver");
            }
        }
    }
    private void OnDestroy()
    {
        AudioController.Instance.PlaySound(_clip);
    }
}
