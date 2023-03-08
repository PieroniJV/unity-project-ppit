using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActualEnemyCollision : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint;
    
    private void Awake()
    {
        GetComponent<CapsuleCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Dagger"))
        {
            Destroy(other.gameObject);
            Destroy(transform.parent.gameObject);
        }

        if (other.CompareTag("Player"))
        {
            other.transform.position = respawnPoint.transform.position;
            other.GetComponent<PlayerMovement>().movementSpeed = 200f;
        }
    }
}
