using UnityEngine;
using UnityEngine.SceneManagement;

// SceneController manages the transitions between scenes 
public class SceneController : MonoBehaviour
{
    [SerializeField] string levelName;
    
    // Exit only actually happens when playing a build version of the game
    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadLevel(string lname)
    {
        SceneManager.LoadScene(lname);
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
//REFERENCES// 
/***************************************************************************************
*    Title: How to load next scene when pressed a button while playing in unity
*    Asked By: Davian Vivian
*    Date Asked: Dec 2, 2021
*    Availability: https://stackoverflow.com/questions/70196826/how-to-load-next-scene-when-pressed-a-button-while-playing-in-unity
***************************************************************************************/