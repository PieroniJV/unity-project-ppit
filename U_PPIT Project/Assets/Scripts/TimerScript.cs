using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class TimerScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    private float timeValue = 0;
    private bool hasStoppedTime;
    
    public TextMeshProUGUI TimerText
    {
        get => timerText;
        set => timerText = value;
    }

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
    }

    //Method below was gotten from Game Dev Begginer's video - reference is at the bottom of this script
    private void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        float milliseconds = timeToDisplay % 1 * 1000;
        
        TimerText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);

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
