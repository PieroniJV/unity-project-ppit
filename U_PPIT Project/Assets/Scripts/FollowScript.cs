using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScript : MonoBehaviour
{
    public float speed = 3f;
    [SerializeField] private Rigidbody2D enemyRb;
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("PlayerCollider"))
        {
            Vector3 distanceBetweenObjects = (other.transform.position - transform.parent.position).normalized;
            enemyRb.AddForce(distanceBetweenObjects * speed);
        }
    }
}
