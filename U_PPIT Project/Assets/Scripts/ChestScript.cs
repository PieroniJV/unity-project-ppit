using System;
using System.Net.Mime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ChestScript : MonoBehaviour
{
    private Animator chestAnimator;
    [SerializeField] private Animator panel;
    [SerializeField] private GameObject giftImageGO;
    [SerializeField] private TextMeshProUGUI giftText;
    [SerializeField] private Sprite giftSprite;
    [SerializeField] private String giftName;
    [SerializeField] private float imageWidth = 0f;
    
    private Image giftImage;
    
    private void Awake()
    {
        giftImage = giftImageGO.GetComponent<Image>();
        chestAnimator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerCollider"))
        {
            DisplayGift();
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


    //The code from the method below was modified from code found on Unity Answers, link to reference is at the bottom of this script
    private void DisplayGift()
    {
        var giftImageRectTransform = giftImageGO.transform as RectTransform;
        giftImageRectTransform.sizeDelta = new Vector2 (imageWidth, giftImageRectTransform.sizeDelta.y);
        giftImage.sprite = giftSprite;
        giftText.text = giftName;
    }
}

//REFERENCES// 
/***************************************************************************************
*    Title: Change width of UI Image C#
*    Question By: FlashX 
*    Answer By: Kornikolia, Eudaimonium
*    Date Asked: Sep 27, 2015
     Date Answered: Sep 29, 2015
*    Availability: https://answers.unity.com/questions/1072456/change-width-of-ui-image-c.html
*
***************************************************************************************/