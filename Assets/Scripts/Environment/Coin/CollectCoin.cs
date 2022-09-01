using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : Environments
{
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.CompareTag("Player"))
        {
            Saver.SaverIntPrefs("Coins", Saver.GetIntPrefs("Coins") + 1);
            Destroy(gameObject);
        }
    }
}
