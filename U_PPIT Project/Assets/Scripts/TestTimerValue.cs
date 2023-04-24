using System;
using TMPro;
using UnityEngine;

public class TestTimerValue : MonoBehaviour
{
    [SerializeField] private TimerScript timerScript;
    private string timertext;
    private void Awake()
    {
        Debug.Log("Script is working fine");
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerCollider"))
        {
            timertext = timerScript.TimerText.text;
            Debug.Log(timertext);

        }
    }
}
