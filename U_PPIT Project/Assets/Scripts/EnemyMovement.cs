using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D enemyRb2D;

    [SerializeField] private Transform player;
    public float enemySpeed = 5f; // Adjust the speed in the inspector if needed
    
    // Start is called before the first frame update
    private void Awake()
    {
        enemyRb2D = GetComponent<Rigidbody2D>();
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        float distanceFromPlayer = player.position.x - transform.position.x;
        transform.position += new Vector3(distanceFromPlayer * enemySpeed * Time.fixedDeltaTime, 
            0, 0);
    }
}
