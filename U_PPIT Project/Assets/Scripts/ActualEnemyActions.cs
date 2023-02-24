using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Mono.Cecil;
using UnityEngine;

public class ActualEnemyActions : MonoBehaviour
{
   
   [SerializeField] private EnemyMovement enemyMovement;
   [SerializeField] private GameObject enemyReflection;
   [SerializeField] private float timeToWait = 10f;
   [SerializeField] private GameObject bullet;
   [SerializeField] private float bulletWaitTime = 3f;
   [SerializeField] private float bulletSpeed = 4f;
   [SerializeField] private Transform bulletParent;
   [SerializeField] private float destroyBulletTime = 5f;
   
   
   private bool isShooting = false;
   private SpriteRenderer actualEnemySprite;
   private SpriteRenderer enemyReflectionSprite;
   
   private void Awake()
   {
      actualEnemySprite = GetComponent<SpriteRenderer>();
      enemyReflectionSprite = enemyReflection.GetComponent<SpriteRenderer>();
   }

   private void FixedUpdate()
   {
      if (actualEnemySprite.enabled)
      {
         enemyMovement.enemySpeed = 0.8f;
         ShootAtPlayer();
         StartCoroutine(Coroutine_WaitToEnterBackIntoReflectionState(timeToWait));
      }
      else
      {
         enemyMovement.enemySpeed = 5;
         isShooting = false;
         StopAllCoroutines();
         //Make actual enemy dissapear
         GetComponent<CapsuleCollider2D>().enabled = false;
      
         //Make enemy reflection reappear
         enemyReflectionSprite.enabled = true;
         enemyReflection.GetComponent<CapsuleCollider2D>().enabled = true;
      }
      
   }

   void ShootAtPlayer()
   {
      if (isShooting) return;
      
      StartCoroutine(Coroutine_ShootPlayer(bulletWaitTime));
   }

   IEnumerator Coroutine_ShootPlayer(float waitTime)
   {
      if (isShooting) yield break;

      isShooting = true;
      
      yield return new WaitForSeconds(waitTime);

      var spawnedBullet = Instantiate(bullet, bulletParent.position, Quaternion.identity);
      spawnedBullet.transform.position = transform.position;
      
      var spawnedBulletRb2D = spawnedBullet.GetComponent<Rigidbody2D>();
      spawnedBulletRb2D.velocity = Vector2.down * (bulletSpeed * Time.fixedDeltaTime);
      Destroy(spawnedBullet, destroyBulletTime);
      
      Debug.Log("Bullet should have spawned");
      
      isShooting = false;

   }
   
   IEnumerator Coroutine_WaitToEnterBackIntoReflectionState(float timeToWait)
   {
      yield return new WaitForSeconds(timeToWait);
      actualEnemySprite.enabled = false;
   }
   
   //////////////
   //REFERENCES//
   //////////////

/***************************************************************************************
*    Title: Enemy shooting bullets every 5 seconds in unity 3d
     Author: user12719872
     Date: Feb 15, 2021
*    Code version: Unknown
*    Availability: https://stackoverflow.com/questions/66210183/enemy-shooting-bullets-every-5-seconds-in-unity-3d
*

***************************************************************************************/
   
}
