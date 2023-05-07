using UnityEngine;

public class PauseScript : MonoBehaviour
{
    private GameObject pausePanel;
    private GameObject player;
    private GameObject projectileGO;
    private PlayerMovement playerMovement;

    private void Awake()
    {
        pausePanel = GameObject.Find("Pause Panel");
        player = GameObject.Find("Player");
        projectileGO = GameObject.Find("Projectile");
        playerMovement = player.GetComponent<PlayerMovement>();
        pausePanel.SetActive(false);
    }

    private void Update()
    {
       PauseGame();
    }

    private void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            Cursor.visible = true;
            pausePanel.SetActive(true);
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        Cursor.visible = false;
        pausePanel.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
