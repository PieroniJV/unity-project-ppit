using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaggerScript : MonoBehaviour
{
    [SerializeField] private GameObject dagger;
    public float daggerSpeed;
    private Rigidbody2D spawnedDaggerRb;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            var spawnedDagger = Instantiate(dagger, transform.position, Quaternion.identity);
            spawnedDaggerRb = spawnedDagger.GetComponent<Rigidbody2D>();
            spawnedDaggerRb.velocity = Vector2.up * (daggerSpeed * Time.deltaTime);
            Destroy(spawnedDaggerRb, 4f);
        }
        
    }
}
