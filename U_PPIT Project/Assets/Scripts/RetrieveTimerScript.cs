using UnityEngine;

public class RetrieveTimerScript : MonoBehaviour
{
    private TimerScript timerScript;
    private string timerText;

    public string TimerText
    {
        get => timerText;
        set => timerText = value;
    }

    private void Awake()
    {
        timerScript = GameObject.Find("Timer").GetComponent<TimerScript>();
    }

    private void Update()
    {
        TimerText = timerScript.TimerText.text;
    }
}
