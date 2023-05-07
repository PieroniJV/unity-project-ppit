using UnityEngine;

public class SmallEnemyFollowScript : MonoBehaviour
{
    public float speed = 3f;
    [SerializeField] private Rigidbody2D enemyRb;
    [SerializeField] private Collider2D playerCollider;
   
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Normal Enemy"))
        {
            FollowPlayer(other);
        }
    }
    
    
    private void FollowPlayer(Collider2D player)
    {
        Vector3 distanceBetweenObjects = (player.transform.position - transform.parent.position).normalized;
        enemyRb.AddForce(distanceBetweenObjects * speed);
    }
}