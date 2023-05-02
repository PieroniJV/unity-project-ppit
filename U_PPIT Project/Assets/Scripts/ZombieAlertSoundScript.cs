using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAlertSoundScript : MonoBehaviour
{
    [SerializeField] private AudioClip zombieAlertSound;
    private AudioSource soundManager;
    
    private void Awake()
    {
        soundManager = GameObject.Find("SoundManager").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerCollider"))
        {
            soundManager.PlayOneShot(zombieAlertSound);
        }
    }
}
