using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    [SerializeField] private GameOver _gameOver;
    [SerializeField] private Camera _mainCamera;
    private void Start()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Environments environments))
        {
            Destroy(environments.gameObject);
        }

        else if (collision.TryGetComponent(out Player player))
        {
            StartCoroutine(_gameOver.Fall());
        }       
    }
}
