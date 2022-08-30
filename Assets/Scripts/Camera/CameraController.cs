using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Player _player;
    private void Start()
    {
        _player = FindObjectOfType<Player>();
    }
    private void FixedUpdate()
    {
        if (_player.transform.position.y > transform.position.y * -2.7f)
        {
            Vector3 currentPostionCamera = Vector3.MoveTowards(transform.position, _player.transform.position, 1f);
            transform.position = new Vector3(transform.position.x, currentPostionCamera.y, transform.position.z);
        }
    }
}
