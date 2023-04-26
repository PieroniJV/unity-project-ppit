using TMPro;
using UnityEngine;

public class ReadInputScript : MonoBehaviour
{
    public static string playerName = "Guest";
    [SerializeField] private GameObject inputField;
    [SerializeField] private GameObject textDisplay;

    
    public void StoreName()
    {
        playerName = inputField.GetComponent<TextMeshProUGUI>().text;
        print(playerName);
    }
    
}
//REFERENCES// 
/***************************************************************************************
*    Title: HOW TO DISPLAY TEXT FROM AN INPUT FIELD USING C# UNITY TUTORIAL
*    Author: Jimmy Vegas
*    Date: Apr 24, 2019
*    Availability: https://www.youtube.com/watch?v=2liZtyMhIQQ
***************************************************************************************/