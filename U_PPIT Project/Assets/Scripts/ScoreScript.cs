using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    private int numberOfEnemiesKilled;

    public int NumberOfEnemiesKilled
    {
        get => numberOfEnemiesKilled;
        set => numberOfEnemiesKilled = value;
    }

    private void Start()
    {
        NumberOfEnemiesKilled = 0;
    }

    public void AddToKillCount()
    {
        NumberOfEnemiesKilled++;
        Debug.Log("Number of enemies killed is " + NumberOfEnemiesKilled);
    }
}
