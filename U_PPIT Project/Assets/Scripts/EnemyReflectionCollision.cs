using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyReflectionCollision : MonoBehaviour
{
    [SerializeField] private GameObject actualEnemy;
    [SerializeField] private GameObject tempProjectileHolder;
    
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
        }       
    }
}
