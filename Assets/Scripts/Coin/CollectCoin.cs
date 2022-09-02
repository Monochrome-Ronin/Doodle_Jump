using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    public int _coin;
    private AudioSource _audioCoin;

    private void Start()
    {
        _coin = 0;
        _audioCoin = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.CompareTag("Player"))
        {
            _audioCoin.Play();
            Destroy(gameObject);
            _coin ++;
        }
    }
}
