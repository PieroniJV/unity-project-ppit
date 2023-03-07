using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// SceneController manages the transitions between scenes 
public class SceneController : MonoBehaviour
{
    [SerializeField] string levelName;

    // The next scene in the Scenes in build list is loaded
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

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
        // To be implemented
        // When player completes level this moves player to the next level/completion level scene
    }

}
