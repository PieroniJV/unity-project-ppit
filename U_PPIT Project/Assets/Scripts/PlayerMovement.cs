using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 10.0f;
    private Rigidbody2D rb2D;
    private Vector2 movement;
    private Animator playerAnimator;

    public Vector2 GetPlayerPosition()
    {
        return transform.position;
    }
    
    private void Awake()
    {
        playerAnimator = gameObject.GetComponentInChildren<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        
        playerAnimator.SetFloat("Horizontal", movement.x );
        playerAnimator.SetFloat("Vertical", movement.y);
        playerAnimator.SetFloat("PlayerSpeed", movement.sqrMagnitude);

        if (movement.x != 0 || movement.y != 0)
        {
            playerAnimator.SetFloat("LastHorizontal", movement.x);
            playerAnimator.SetFloat("LastVertical", movement.y);
        }
    }

    private void FixedUpdate()
    {
        UpdateVelocity();
    }
    
    public void UpdateVelocity()
    {
        Vector2 directionOfMovement = new Vector2(movement.x, movement.y);
        rb2D.velocity = directionOfMovement * (movementSpeed * Time.fixedDeltaTime);
    }
    
    public void SetXAxisMovement(float xValue)
    {
        movement.x = xValue;
    }

    public void SetYAxisMovement(float yValue)
    {
        movement.y = yValue;
    }

    public float GetMovementY()
    {
        return movement.y;
    }

    public float GetMovementX()
    {
        return movement.x;
    }

    
    //REFERENCES//
    /***************************************************************************************
    *    Title: How to make 2D Top Down Movement (Brackeys/Continued)(Unity Tutorial)
    *    Author: JTA Games
    *    Date: September 24, 2020
    *    Code version: Unknown
    *    Availability: https://www.youtube.com/watch?v=fRpoE4FfJf8&t=1s
    *
    ***************************************************************************************/
    
}