using System;
using TMPro;
using UnityEngine;

public class DisplayScoreScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private TextMeshProUGUI playerNameText;
    [SerializeField] private TextMeshProUGUI killCountText;

    private ScoreScript scoreObject;
    private ReadInputScript playerNameObject;
    private RetrieveTimerScript timerObject;
    
    private void Awake()
    {
        playerNameObject = GameObject.Find("PlayerNameObject").GetComponent<ReadInputScript>();
        scoreObject = GameObject.Find("ScoreObject").GetComponent<ScoreScript>();
        timerObject = GameObject.Find("RetrieveTimerObject").GetComponent<RetrieveTimerScript>();

        playerNameText.text = "Player Name: " + playerNameObject.TheName;
        killCountText.text = "Number of Enemies killed: " + scoreObject.NumberOfEnemiesKilled.ToString();
        timeText.text = "Time to Complete: " + timerObject.TimerText;
    }
}
