using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : Environments
{
    private AudioSource _audioCoin;
    private void Awake()
    {
        _audioCoin = GetComponent<AudioSource>();
    }
    private void Start()
    {
        ClampPosition();
    }
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.CompareTag("Player"))
        {
            _audioCoin.Play();
            Saver.SaverIntPrefs("Coins", Saver.GetIntPrefs("Coins") + 1);
            Destroy(gameObject, 0.1f);
        }
    }
    private void ClampPosition()
    {
        if (transform.position.x < -2.5f)
        {
            transform.position = new Vector3(-2.5f, transform.position.y, 0);
        }
        else if (transform.position.x > 2.5f)
        {
            transform.position = new Vector3(2.5f, transform.position.y, 0);
        }
    }
}
