using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private SimplePlatform _simplePlatform;
    [SerializeField] private float _jumpForce = 5;
    public void Jump()
    {
        if (_simplePlatform.IsJump && _player.GetComponent<Rigidbody2D>().velocity == Vector2.zero)
        {
            _simplePlatform.Jump(_player, _jumpForce);
        }
    }
}
