using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    public static int numberOfEnemiesKilled;
    

    private void Awake()
    {
        numberOfEnemiesKilled = 0;
    }

    public void AddToKillCount()
    {
        numberOfEnemiesKilled++;
        Debug.Log("Number of enemies killed is " + numberOfEnemiesKilled);
    }
}
