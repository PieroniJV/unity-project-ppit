using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// SceneController manages the transitions between scenes 
public class SceneController : MonoBehaviour
{
    [SerializeField] string levelName;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            // Get the current scene
            Scene currentScene = SceneManager.GetActiveScene();

            // Reload the current scene
            SceneManager.LoadScene(currentScene.name);
        }
    }

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
