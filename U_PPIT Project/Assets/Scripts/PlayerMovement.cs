using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 10.0f;
    private Rigidbody2D rb2D;
    private Vector2 movement;
    private Animator playerAnimator;

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
        Vector2 directionOfMovement = new Vector2(movement.x, movement.y);
        rb2D.velocity = directionOfMovement * (movementSpeed * Time.fixedDeltaTime);
    }
}