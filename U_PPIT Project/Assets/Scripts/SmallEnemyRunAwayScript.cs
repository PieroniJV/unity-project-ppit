using UnityEngine;

public class SmallEnemyRunAwayScript : MonoBehaviour
{
    public float speed = 3f;
    [SerializeField] private Rigidbody2D enemyRb;
   
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("PlayerCollider"))
        {
            RunAwayFromPlayer(other);
        }
    }
    
    private void RunAwayFromPlayer(Collider2D player)
    {
        Vector3 distanceBetweenObjects = (transform.parent.position - player.transform.position).normalized;
        enemyRb.AddForce(distanceBetweenObjects * speed);
    }
    
}