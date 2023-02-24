using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollisions : MonoBehaviour
{
    private GameObject respawnPoint;
    private SpriteRenderer actualEnemySprite;
    private GameObject actualEnemyGO;
    
    private void Awake()
    {
        actualEnemyGO = GameObject.FindWithTag("Actual Enemy");
        actualEnemySprite = actualEnemyGO.GetComponent<SpriteRenderer>();
        respawnPoint = GameObject.Find("RespawnPoint");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = respawnPoint.transform.position;
            other.GetComponent<PlayerMovement>().movementSpeed = 200f;
            actualEnemySprite.enabled = false;
            Destroy(gameObject);
        }
    }
}
