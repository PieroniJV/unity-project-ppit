using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagOfRocksCollectable : MonoBehaviour
{
    private GameObject projectile;
    private GameObject sceneManager;
    private CameraZoom cameraZoom;

    private void Awake()
    {
        sceneManager = GameObject.Find("SceneManager");
        projectile = GameObject.Find("Projectile");

        cameraZoom = sceneManager.GetComponent<CameraZoom>();
        cameraZoom.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            cameraZoom.enabled = true;
            projectile.GetComponent<Projectile>().enabled = true;
            Destroy(gameObject);
        }
    }
}
