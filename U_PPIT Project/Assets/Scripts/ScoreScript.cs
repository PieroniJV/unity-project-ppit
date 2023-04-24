using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    private int numberOfEnemiesKilled;

    private void Start()
    {
        numberOfEnemiesKilled = 0;
    }

    public void AddToKillCount()
    {
        numberOfEnemiesKilled++;
        Debug.Log("Number of enemies killed is " + numberOfEnemiesKilled);
    }
}
