using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : MonoBehaviour
{
    private Animator chestAnimator;
    [SerializeField] private Animator panel;
    
    private void Awake()
    {
        chestAnimator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerCollider"))
        {
            chestAnimator.SetBool("isOpen", true);
            panel.SetBool("hasOpenedPanel", true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("PlayerCollider"))
        {
            chestAnimator.SetBool("isOpen", false);
            panel.SetBool("hasOpenedPanel", false);
        }
    }
}
