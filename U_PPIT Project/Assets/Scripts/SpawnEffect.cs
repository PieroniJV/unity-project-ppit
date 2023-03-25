using UnityEngine;

public class SpawnEffect : MonoBehaviour
{
    [SerializeField] private GameObject effectToSpawn;
    [SerializeField] private float timeToDestroyEffect = 3f;
    [SerializeField] private string objectThatWasHit = "";
    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(objectThatWasHit))
        {
            if (other.gameObject != null)
            {
                var spawnedEffect = Instantiate(effectToSpawn);
                spawnedEffect.transform.position = other.transform.position;
                Destroy(spawnedEffect, timeToDestroyEffect);
            }
        }
    }
}
