using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActualEnemyCollision : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<CapsuleCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Projectile"))
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
