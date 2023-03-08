using System;
using System.Collections;
using System.Collections.Generic;
using System.Resources;
using System.Security.Cryptography;
using UnityEngine;

public class NormalEnemyCollision : MonoBehaviour
{
    private GameObject respawnPoint;

    private void Awake()
    {
        respawnPoint = GameObject.Find("RespawnPoint");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = respawnPoint.transform.position;
        }else if (other.CompareTag("Dagger"))
        {
            Destroy(other.gameObject);
            Destroy(transform.parent.gameObject);
        }
    }
}
