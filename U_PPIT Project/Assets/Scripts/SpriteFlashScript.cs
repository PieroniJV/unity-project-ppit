using System;
using System.Collections;
using UnityEngine;

public class SpriteFlashScript : MonoBehaviour
{
    [SerializeField] private float flashSpriteDelay = 2f;
    [SerializeField] private string weaponTag = "";
    [SerializeField] private Color defaultEnemyColor;
    private EnemyHealth spriteEnemyHealth;

    private void Awake()
    {
        spriteEnemyHealth = GetComponentInParent<EnemyHealth>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(weaponTag) && spriteEnemyHealth.CurrentHealth > 0)
        {
            StartCoroutine(FlashSprite_Coroutine());
        }
    }

    IEnumerator FlashSprite_Coroutine()
    {
        var enemySprite = GetComponentInParent<SpriteRenderer>();
        enemySprite.color = Color.red;
        yield return new WaitForSeconds(flashSpriteDelay);
        enemySprite.color = defaultEnemyColor;
    } 
}