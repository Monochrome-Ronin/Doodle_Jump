using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    public int _coin;

    private void Start()
    {
        _coin = 0;
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            _coin ++;
            Debug.Log(_coin);
        }
    }
}
