using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class AngelStatueScript : MonoBehaviour
{
    [SerializeField] private DialogueScript dialogueScript;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerCollider"))
        {
           BeginConversationWithStatue();
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("PlayerCollider"))
        {
            dialogueScript.HasStartedDialogue = false;
            dialogueScript.gameObject.SetActive(false);
        }
    }

    private void BeginConversationWithStatue()
    {
        dialogueScript.gameObject.SetActive(true);
        dialogueScript.ClearText();
        dialogueScript.StartDialogue();
        dialogueScript.HasStartedDialogue = true;
    }
}

   