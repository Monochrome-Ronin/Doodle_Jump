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
}
