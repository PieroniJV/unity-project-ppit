using UnityEngine;

public class AddDaggerScript : MonoBehaviour
{
    [SerializeField] private AudioClip pickUpDaggerSound;
    private AudioSource soundManager;
    
    private void Awake()
    {
        soundManager = GameObject.Find("SoundManager").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerCollider"))
        {
            soundManager.PlayOneShot(pickUpDaggerSound);
            DaggerScript.AddDagger();
            Destroy(gameObject);
        }
    }
}