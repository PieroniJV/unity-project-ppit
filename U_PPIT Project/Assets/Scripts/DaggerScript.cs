using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaggerScript : MonoBehaviour
{
    [SerializeField] private GameObject dagger;
    
    public float daggerSpeed;
    private Rigidbody2D spawnedDaggerRb;
    private bool hasFired = false;

    //Update is used for input from player
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            hasFired = true;
        }
    }

    //Fixed Update used for physics of dagger
    void FixedUpdate()
    {
        if (hasFired)
        {
            var spawnedDagger = Instantiate(dagger, transform.position, Quaternion.identity);
            spawnedDaggerRb = spawnedDagger.GetComponent<Rigidbody2D>();
            spawnedDaggerRb.velocity = Vector2.up * (daggerSpeed * Time.fixedDeltaTime);
            Destroy(spawnedDagger, 4f);
            hasFired = false;
        }
    }
}
