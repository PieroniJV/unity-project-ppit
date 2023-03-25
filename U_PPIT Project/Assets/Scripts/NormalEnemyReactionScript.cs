using UnityEngine;

public class NormalEnemyReactionScript : MonoBehaviour
{
    public float speed = 3f;
    [SerializeField] private Rigidbody2D enemyRb;
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("ExitTrigger"))
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
