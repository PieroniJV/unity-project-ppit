using UnityEngine;

public class PlayerGruntSoundScript : MonoBehaviour
{
    [SerializeField] private AudioClip playerGruntSound;
    private AudioSource soundManager;
    
    private void Awake()
    {
        soundManager = GameObject.Find("SoundManager").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SmallEnemy") || other.CompareTag("Normal Enemy"))
        {
            soundManager.PlayOneShot(playerGruntSound);
        }
    }
}
