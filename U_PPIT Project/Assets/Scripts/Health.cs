using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 3;
    private int currentHealth;
    
    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeAwayHealth(int damageAmount)
    {
        currentHealth -= damageAmount;
        Debug.Log("Health is now " + currentHealth);
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            Debug.Log("Enemy is dead");
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
