using System;
using UnityEngine;

public class AngelStatueScript : MonoBehaviour
{
    [SerializeField] private AngelDialogueScript angelDialogueScript;
    [SerializeField] private Rigidbody2D playerRB2D;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private GameObject theEkey;
    
    private bool canTalkToStatue;

    private void Awake()
    {
        if (theEkey != null)
        {
            theEkey.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerCollider"))
        {
            if (theEkey != null)
            { 
                theEkey.SetActive(true);
            }
            canTalkToStatue = true;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canTalkToStatue)
        {
            BeginConversationWithStatue();
            StopMovingPlayer();
        }
    }

    private void StopMovingPlayer()
    {
        playerRB2D.constraints = RigidbodyConstraints2D.FreezePosition;
        playerAnimator.enabled = false;
    }

    public void MovePlayerAgain()
    {
        playerRB2D.constraints &= ~RigidbodyConstraints2D.FreezePosition;
        playerRB2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        playerAnimator.enabled = true;
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("PlayerCollider"))
        {
            canTalkToStatue = false;
            if (theEkey != null)
            {
                theEkey.SetActive(false);
            }
            angelDialogueScript.HasStartedDialogue = false;
            angelDialogueScript.gameObject.SetActive(false);
        }
    }

    private void BeginConversationWithStatue()
    {
        canTalkToStatue = false;
        if (theEkey != null)
        {
            theEkey.SetActive(false);  
        }
        angelDialogueScript.gameObject.SetActive(true);
        angelDialogueScript.ClearText();
        angelDialogueScript.StartDialogue();
        angelDialogueScript.HasStartedDialogue = true;
    }
}

   