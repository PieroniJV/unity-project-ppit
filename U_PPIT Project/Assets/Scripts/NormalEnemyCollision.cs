using UnityEngine;

public class NormalEnemyCollision : MonoBehaviour
{
    private GameObject respawnPoint;
    private Health enemyHealth;
    
    private void Awake()
    {
        enemyHealth = GetComponentInParent<Health>();
        respawnPoint = GameObject.Find("RespawnPoint");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerCollider"))
        {
            print("Player is dead");
            other.transform.parent.gameObject.SetActive(false);
            if (respawnPoint != null)
            {
                other.transform.position = respawnPoint.transform.position;
            }
        }else if (other.CompareTag("Weapons/Dagger"))
        {
            Destroy(other.gameObject);
            Destroy(transform.parent.gameObject);
        }else if (other.CompareTag("Weapons/Sword"))
        {
            enemyHealth.TakeAwayHealth(1);
        }else if (other.CompareTag("Weapons/Maul"))
        {
            enemyHealth.TakeAwayHealth(1);
        }
    }
}
