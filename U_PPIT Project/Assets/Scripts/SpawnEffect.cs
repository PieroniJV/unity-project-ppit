using UnityEngine;

public class SpawnEffect : MonoBehaviour
{
    [SerializeField] private GameObject effectToSpawn;
    [SerializeField] private float timeToDestroyEffect = 3f;
    [SerializeField] private string objectThatWasHit = "";
    
    [SerializeField] private AudioClip bloodSound;
    private AudioSource soundManager;
    
    private void Awake()
    {
        soundManager = GameObject.Find("SoundManager").GetComponent<AudioSource>();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(objectThatWasHit))
        {
            if (other.gameObject != null)
            {
                soundManager.PlayOneShot(bloodSound);
                var spawnedEffect = Instantiate(effectToSpawn);
                spawnedEffect.transform.position = other.transform.position;
                Destroy(spawnedEffect, timeToDestroyEffect);
            }
        }
    }
}
