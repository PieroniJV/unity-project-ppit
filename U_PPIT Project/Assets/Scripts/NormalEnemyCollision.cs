using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NormalEnemyCollision : MonoBehaviour
{
    private GameObject respawnPoint;
    private GameObject gameOverScreen;
    private TextMeshProUGUI gameOverText;
    private EnemyHealth enemyHealth;
    
    
    private void Awake()
    {
        gameOverScreen = GameObject.Find("GameOverPanel");
        gameOverText = GameObject.Find("Died Text").GetComponent<TextMeshProUGUI>();
        enemyHealth = GetComponentInParent<EnemyHealth>();
        respawnPoint = GameObject.Find("RespawnPoint");
        
        gameOverScreen.GetComponent<Image>().color = Color.clear;
        gameOverText.GetComponent<TextMeshProUGUI>().color = Color.clear;
    }

    private void ShowGameOverScreen()
    {
        gameOverScreen.GetComponent<Image>().color = new Color(0f, 0f, 0f, 0.62f);
        gameOverText.GetComponent<TextMeshProUGUI>().color = Color.white;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerCollider"))
        {
            print("Player is dead");
            other.transform.parent.gameObject.SetActive(false);
            ShowGameOverScreen();
            if (respawnPoint != null)
            {
                other.transform.position = respawnPoint.transform.position;
            }
        }else if (other.CompareTag("Weapons/Dagger"))
        {
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
