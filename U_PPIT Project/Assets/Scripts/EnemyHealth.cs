using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private ScoreScript scoreScript;
    [SerializeField] private int maxHealth = 3;
    private int currentHealth;
    
    public int CurrentHealth
    {
        get => currentHealth;
        set => currentHealth = value;
    }

    private void Awake()
    {
        CurrentHealth = maxHealth;
        scoreScript = GameObject.Find("ScoreObject").GetComponent<ScoreScript>();
    }

    public void TakeAwayHealth(int damageAmount)
    {
        CurrentHealth -= damageAmount;
        Debug.Log("Health is now " + CurrentHealth);
        if (CurrentHealth <= 0)
        {
            scoreScript.AddToKillCount();
            Destroy(gameObject);
        }
    }
    
    //REFERENCES// 
    /***************************************************************************************
    *    Title: How to Make A Simple HEALTH SYSTEM in Unity
    *    Author: BMo
    *    Date: March 26, 2021
    *    Code version: Unknown
    *    Availability: https://www.youtube.com/watch?v=vNL4WYgvwd8
    *
    ***************************************************************************************/
}
