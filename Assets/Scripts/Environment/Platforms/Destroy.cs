using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    [SerializeField] private CameraController _camera;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Environments environments))
        {
            Destroy(environments.gameObject);
        }

        else if (collision.TryGetComponent(out Player player))
        {
            _camera._playerFall = true;
        }
        
          
    }
}
