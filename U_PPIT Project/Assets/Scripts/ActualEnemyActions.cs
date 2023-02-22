using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActualEnemyActions : MonoBehaviour
{
   
   //Need out of state timer coroutine
   //Once timer is complete - renable sprite and collider of enemy reflection and disable actual enemy sprite and collider
   //Need this in update

   [SerializeField] private EnemyMovement enemyMovement;
   [SerializeField] private GameObject enemyReflection;
   [SerializeField] private float timeToWait = 10f;
   
   
   private SpriteRenderer actualEnemySprite;
   private SpriteRenderer enemyReflectionSprite;
   private void Awake()
   {
      actualEnemySprite = GetComponent<SpriteRenderer>();
      enemyReflectionSprite = enemyReflection.GetComponent<SpriteRenderer>();
   }

   private void Update()
   {
      if (actualEnemySprite.enabled)
      {
         enemyMovement.enemySpeed = 0.8f;
         StartCoroutine(Coroutine_WaitToEnterBackIntoReflectionState(timeToWait));
      }
      else
      {
         enemyMovement.enemySpeed = 5;
         StopAllCoroutines();
         //Make actual enemy dissapear
         GetComponent<CapsuleCollider2D>().enabled = false;
      
         //Make enemy reflection reappear
         enemyReflectionSprite.enabled = true;
         enemyReflection.GetComponent<CapsuleCollider2D>().enabled = true;
      }
      
   }

   IEnumerator Coroutine_WaitToEnterBackIntoReflectionState(float timeToWait)
   {
      yield return new WaitForSeconds(timeToWait);
      actualEnemySprite.enabled = false;
   }
}
