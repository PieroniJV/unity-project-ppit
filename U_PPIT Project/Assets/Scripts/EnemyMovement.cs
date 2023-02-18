using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D enemyRb2D;

    [SerializeField] private Transform player;
    public float originalSpeed = 5f; // Adjust the speed in the inspector if needed
    private float currentSpeed; // Store the current speed of the object
    public float threshold = 0.1f; // Adjust the threshold for stopping the object in the inspector if needed
    private PlayerMovement _playerMovement;

    void Start() {
        currentSpeed = originalSpeed; // Store the original speed as the current speed
    }


    // Start is called before the first frame update
    private void Awake()
    {
        _playerMovement = player.GetComponent<PlayerMovement>();
        enemyRb2D = GetComponent<Rigidbody2D>();
    }
    
    // Update is called once per frame
    void Update()
    {
        float distanceFromPlayer = player.position.x - transform.position.x;

        if (Mathf.Abs(distanceFromPlayer) < threshold) {
            transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
        }
        else{
            float direction;
            
            if (distanceFromPlayer < 0) 
                direction = -1;
            else 
                direction = 1;
            
            // Check if the current speed is less than the original speed
            if (currentSpeed < originalSpeed) {
                // If it is, increase the current speed by a certain amount
                currentSpeed += 0.1f;
                // Limit the current speed to be no greater than the original speed
                currentSpeed = Mathf.Min(currentSpeed, originalSpeed);
            }
            
            transform.position += new Vector3(direction * currentSpeed * Time.deltaTime, 
                0, 0);
        }
        
    }
}
