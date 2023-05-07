using UnityEngine;

public class ZombieAlertSoundScript : MonoBehaviour
{
    [SerializeField] private AudioClip zombieAlertSound;
    private AudioSource soundManager;
    
    private void Awake()
    {
        var soundManagerGO = GameObject.Find("SoundManager");
        if (soundManagerGO != null)
        {
            soundManager = soundManagerGO.GetComponent<AudioSource>();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerCollider"))
        {
            soundManager.PlayOneShot(zombieAlertSound);
        }
    }
}
