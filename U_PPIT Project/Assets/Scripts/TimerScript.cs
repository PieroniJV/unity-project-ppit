using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class TimerScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    private float timeValue = 0;

    public TextMeshProUGUI TimerText
    {
        get => timerText;
        set => timerText = value;
    }

    private void Update()
    {
        timeValue += Time.deltaTime;
        DisplayTime(timeValue);
    }

    private void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        float milliseconds = timeToDisplay % 1 * 1000;
        
        TimerText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);

    }
}
