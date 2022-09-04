using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour
{
     protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    protected void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Destroy"))
            Destroy(transform.gameObject);
    }
}
