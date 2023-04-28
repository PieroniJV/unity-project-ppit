using System;
using UnityEngine;

public class AddDaggerScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerCollider"))
        {
            print("Player found dagger");
            DaggerScript.AddDagger();
            Destroy(gameObject);
        }
    }
}