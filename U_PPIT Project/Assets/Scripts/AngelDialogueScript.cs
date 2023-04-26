using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class AngelDialogueScript : MonoBehaviour
{
    [SerializeField] private PlayerInventory playerInventory;
    [SerializeField] private Animator flashToWhiteAnimator;
    [SerializeField] private AngelStatueScript angelStatueScript;
    [SerializeField] private TimerScript timerScript;
    [SerializeField] private SpinAround spinAround;
    [SerializeField] private DaggerScript daggerScript;
    
    
    [SerializeField] private TextMeshProUGUI textComponent;
    [SerializeField] private string[] lines;
    [SerializeField] private float textSpeed;
    private int index;
    private bool hasStartedDialogue = false;
    private bool hasWonGame = false;

    public bool HasStartedDialogue
    {
        set => hasStartedDialogue = value;
    }

    private void Start()
    {
        hasWonGame = false;
        flashToWhiteAnimator.SetBool("hasWonGame", hasWonGame);
        ClearText();
        gameObject.SetActive(false);
    }

    public void ClearText()
    {
        textComponent.text = string.Empty;
    }

    private void Update()
    {
        if (hasStartedDialogue)
        {
            spinAround.enabled = false;
            daggerScript.enabled = false;
            timerScript.HasStoppedTime = true;
            RunThroughDialogue();
        }
    }

    private void RunThroughDialogue()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
                if (lines[index] == "....")
                {
                    if (playerInventory.GetNumberOfGifts() >= 4)
                    {
                        lines[index + 1] = "Congratulations Traveller!";
                        lines[index + 2] = "You have successfully brought all the gifts to me.";
                        lines[index + 3] = "I shall bring this land back to it's former glory!";
                        hasWonGame = true;
                    }
                    else
                    {
                        lines[index + 1] = "It seems you do not have all the gifts with you.";
                        lines[index + 2] = "Please go back and find all four gifts scattered across the land! Then return to me once you have completed this task.";
                        lines[index + 3] = "Now traveller, make haste!";
                    }
                    
                }
            }
            else //Allows you to skip dialogue in the process of dialogue running
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            } 
        }
    }

    public void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            if (hasWonGame)
            {
                flashToWhiteAnimator.SetBool("hasWonGame", hasWonGame);
            }
            else
            {
                angelStatueScript.MovePlayerAgain();
                timerScript.HasStoppedTime = false;
                spinAround.enabled = true;
                daggerScript.enabled = true;
            }
            gameObject.SetActive(false);
        }
    }
    
    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
}

//REFERENCES// 
/***************************************************************************************
*    Title: 5 Minute DIALOGUE SYSTEM in UNITY Tutorial
*    Author: BMo
*    Date: Mar 19, 2021
*    Availability: https://www.youtube.com/watch?v=8oTYabhj248
***************************************************************************************/


