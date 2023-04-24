using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ReadInputScript : MonoBehaviour
{
    [SerializeField] private string theName;
    [SerializeField] private GameObject inputField;
    [SerializeField] private GameObject textDisplay;

    public void StoreName()
    {
        theName = inputField.GetComponent<TextMeshProUGUI>().text;
        textDisplay.GetComponent<TextMeshProUGUI>().text = "Welcome " + theName;
    }
}
//REFERENCES// 
/***************************************************************************************
*    Title: HOW TO DISPLAY TEXT FROM AN INPUT FIELD USING C# UNITY TUTORIAL
*    Author: Jimmy Vegas
*    Date: Apr 24, 2019
*    Availability: https://www.youtube.com/watch?v=2liZtyMhIQQ
***************************************************************************************/