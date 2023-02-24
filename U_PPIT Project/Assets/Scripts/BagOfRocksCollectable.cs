using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagOfRocksCollectable : MonoBehaviour
{
    private GameObject projectile;

    private void Awake()
    {
        projectile = GameObject.Find("Projectile");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            projectile.GetComponent<Projectile>().enabled = true;
            Destroy(gameObject);
        }
    }
}
