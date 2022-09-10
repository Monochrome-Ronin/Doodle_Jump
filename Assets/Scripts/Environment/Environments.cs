using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Environments : MonoBehaviour
{
    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {

    }
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
    public virtual void JumpPlatform(Player player, float jumpForce)
    {
        Rigidbody2D rigidbody2D = player.GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = new Vector3(rigidbody2D.velocity.x, 0, 0);
        rigidbody2D.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        StartCoroutine(player.GetComponent<PlayerMover>().JumpAnim());
    }
}
