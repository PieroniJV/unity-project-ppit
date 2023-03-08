using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScript : MonoBehaviour
{
    public float speed = 3f;
    private Rigidbody2D enemyRb;

    private void Awake()
    {
        enemyRb = transform.parent.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Vector3 distanceBetweenObjects = (other.transform.position - transform.parent.position).normalized;
            enemyRb.AddForce(distanceBetweenObjects * speed);
        }
    }
}
