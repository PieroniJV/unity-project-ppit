using UnityEngine;

public class NormalEnemyReactionScript : MonoBehaviour
{
    public float speed = 3f;
    [SerializeField] private Rigidbody2D enemyRb;
    [SerializeField] private Animator enemyAnimator;
    private Vector3 distanceBetweenObjects;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("ExitTrigger"))
        {
            FollowPlayer(other);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("ExitTrigger") && enemyAnimator != null)
        {
            enemyAnimator.speed = 0.3f;
            enemyAnimator.SetBool("isRunning", false);
        }
    }

    private void FollowPlayer(Collider2D player)
    {
        if (enemyAnimator != null)
        {
            enemyAnimator.speed = 1f;
        }

        //Code modified from The Code Anvil video - reference below
        distanceBetweenObjects = (player.transform.position - transform.parent.position).normalized;
        distanceBetweenObjects.Normalize();

        if (enemyAnimator != null)
        {
            //Code modified from The Code Anvil video - reference below
            enemyAnimator.SetFloat("Horizontal", distanceBetweenObjects.x);
            enemyAnimator.SetFloat("Vertical", distanceBetweenObjects.y);
        }

        enemyRb.AddForce(distanceBetweenObjects * speed);

        if (enemyAnimator != null)
        {
            enemyAnimator.SetBool("isRunning", true);
        }
    }
}

//////////////
//REFERENCES//
//////////////

/***************************************************************************************
*    Title: Unity top down Enemy AI and animation
     Author: The Code Anvil
     Date: Feb 1, 2021
*    Code version: Unknown
*    Availability: https://www.youtube.com/watch?v=2xaQYZW6LLA
*
***************************************************************************************/