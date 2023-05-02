using System;
using TMPro;
using UnityEngine;

public class DisplayScoreScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private TextMeshProUGUI playerNameText;
    [SerializeField] private TextMeshProUGUI killCountText;
      
    private void Awake()
    {

        string name = ReadInputScript.playerName;
        string time = TimerScript.finalTime;
        int killCount = ScoreScript.numberOfEnemiesKilled;

        playerNameText.text = "Player Name: " + name;
        killCountText.text = "Number of Enemies killed: " + killCount;
        timeText.text = "Time to Complete: " + time;

        Database.InsertData(name, time, killCount);

    }
}
