using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyReflectionCollision : MonoBehaviour
{
    [SerializeField] private GameObject actualEnemy;
    [SerializeField] private Transform respawnPoint;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Projectile"))
        {
            if (actualEnemy != null)
            {
                actualEnemy.GetComponent<SpriteRenderer>().enabled = true;
                actualEnemy.GetComponent<CapsuleCollider2D>().enabled = true;
            }
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<CapsuleCollider2D>().enabled = false;
            other.GetComponent<CircleCollider2D>().enabled = false;
        }

        if (other.CompareTag("Player"))
        {
            other.transform.position = respawnPoint.transform.position;
            other.GetComponent<PlayerMovement>().movementSpeed = 200f;
        }
    }
}
