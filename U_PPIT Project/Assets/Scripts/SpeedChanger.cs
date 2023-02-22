using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedChanger : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && gameObject.name == "Mud")
        {
            other.GetComponent<PlayerMovement>().movementSpeed = 100f;
        }
        else if (other.CompareTag("Player") && gameObject.name == "Water Stream")
        {
            other.GetComponent<PlayerMovement>().movementSpeed = 50f;
        }else if (other.CompareTag("Player") && gameObject.CompareTag("BTN"))
        {
            other.GetComponent<PlayerMovement>().movementSpeed = 200f;
        }
        
    }
}
