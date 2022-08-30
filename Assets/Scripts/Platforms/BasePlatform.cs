using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasePlatform : MonoBehaviour
{
    protected abstract void OnCollisionEnter2D(Collision2D collision);
}
