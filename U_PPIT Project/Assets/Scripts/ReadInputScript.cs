using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ReadInputScript : MonoBehaviour
{
    private string theName;
    [SerializeField] private GameObject inputField;
    [SerializeField] private GameObject textDisplay;

    public string TheName
    {
        get => theName;
        set => theName = value;
    }

    public void StoreName()
    {
        TheName = inputField.GetComponent<TextMeshProUGUI>().text;
        print(TheName);
    }
    
}
//REFERENCES// 
/***************************************************************************************
*    Title: HOW TO DISPLAY TEXT FROM AN INPUT FIELD USING C# UNITY TUTORIAL
*    Author: Jimmy Vegas
*    Date: Apr 24, 2019
*    Availability: https://www.youtube.com/watch?v=2liZtyMhIQQ
***************************************************************************************/