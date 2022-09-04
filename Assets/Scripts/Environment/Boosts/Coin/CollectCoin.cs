using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : Boost
{
   [SerializeField] private AudioClip _clipCoin;
   
    private void Start()
    {
        ClampPosition();
    }
    protected override void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.CompareTag("Player"))
        {
            AudioController.Instance.PlaySound(_clipCoin);
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
