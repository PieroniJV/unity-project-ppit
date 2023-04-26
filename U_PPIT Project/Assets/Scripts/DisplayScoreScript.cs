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
        playerNameText.text = "Player Name: " + ReadInputScript.playerName;
        killCountText.text = "Number of Enemies killed: " + ScoreScript.numberOfEnemiesKilled;
        timeText.text = "Time to Complete: " + TimerScript.finalTime;
    }
}
