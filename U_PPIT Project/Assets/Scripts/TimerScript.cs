using TMPro;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    public static string finalTime = "0:00";
    private float timeValue = 0;
    private bool hasStoppedTime;
    
    public bool HasStoppedTime
    {
        get => hasStoppedTime;
        set => hasStoppedTime = value;
    }

    private void Update()
    {
        if (!HasStoppedTime)
        {
            timeValue += Time.deltaTime;
            DisplayTime(timeValue);
        }
        else
        {
            finalTime = timerText.text;
        }
    }

    //Method below was gotten from Game Dev Begginer's video - reference is at the bottom of this script
    private void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

    }

   
}

//REFERENCES// 
/***************************************************************************************
*    Title: How to make a Countdown Timer in Unity (in minutes + seconds)
*    Author: Game Dev Beginner
*    Date: Apr 13, 2021
*    Availability: https://www.youtube.com/watch?v=HmHPJL-OcQE
*
***************************************************************************************/
