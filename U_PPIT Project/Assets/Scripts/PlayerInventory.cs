using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    private int numberOfGifts;
    [SerializeField] private GameObject goldSkullGO;
    [SerializeField] private GameObject breadGO;
    [SerializeField] private GameObject fishGO;
    [SerializeField] private GameObject meatGO;
    [SerializeField] private ChestScript chestScript;

    private Image goldSkullImage;
    private Image breadImage;
    private Image fishImage;
    private Image meatImage;
    
    private void Awake()
    {
        numberOfGifts = 0;
        goldSkullImage = goldSkullGO.GetComponent<Image>();
        breadImage = breadGO.GetComponent<Image>();
        fishImage = fishGO.GetComponent<Image>();
        meatImage = meatGO.GetComponent<Image>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
           EarnAllGifts();
           print("All gifts have been earned");
        }
    }

    private void EarnAllGifts()
    {
        numberOfGifts = 4;
        goldSkullGO.GetComponent<Image>().color = Color.white;
        breadGO.GetComponent<Image>().color = Color.white;
        fishGO.GetComponent<Image>().color = Color.white;
        meatGO.GetComponent<Image>().color = Color.white;
    }
    
    public void IncreaseNumberOfGifts()
    {
        numberOfGifts++;
        DisplaySpriteInInventory();
        print("Number of gifts is now " + numberOfGifts);
    }

    public int GetNumberOfGifts()
    {
        return numberOfGifts;
    }

    private void DisplaySpriteInInventory()
    {
        var currentGiftSprite = chestScript.GetGiftSprite();
        if (currentGiftSprite == goldSkullImage.sprite)
        {
            goldSkullGO.GetComponent<Image>().color = Color.white;
        }
        else if (currentGiftSprite == breadImage.sprite)
        {
            breadGO.GetComponent<Image>().color = Color.white;
        }
        else if (currentGiftSprite == fishImage.sprite)
        {
            fishGO.GetComponent<Image>().color = Color.white;
        }
        else if (currentGiftSprite == meatImage.sprite)
        {
            meatGO.GetComponent<Image>().color = Color.white;
        }
    }
    
}
