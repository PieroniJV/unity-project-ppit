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
   private SpriteRenderer actualEnemySprite;
   private void Awake()
   {
      actualEnemySprite = GetComponent<SpriteRenderer>();
   }

   private void Update()
   {
      if (actualEnemySprite.enabled)
      {
         enemyMovement.enemySpeed = 0.6f;
      }
      else
      {
         enemyMovement.enemySpeed = 5;
      }
      
   }
}
