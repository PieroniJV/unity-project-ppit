using UnityEngine;

public class PersistentDataScript : MonoBehaviour
{
    private static PersistentDataScript instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
//REFERENCES// 
/***************************************************************************************
*    Title: SINGLETON - Keeping one script between many Scenes
*    Author: SpeedTutor
*    Date: Oct 14, 2017
*    Availability: https://www.youtube.com/watch?v=5p2JlI7PV1w
***************************************************************************************/
