using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManagerScript : MonoBehaviour
{
    [SerializeField] private AudioClip menuMusic;
    [SerializeField] private AudioClip mainLevelMusic;
    private AudioSource musicSource;
    
    private void Awake()
    {
        musicSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += HandleSceneLoading;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= HandleSceneLoading;
    }

    private void HandleSceneLoading(Scene scene, LoadSceneMode mode)
    {
        PlayMusicForLevel(scene);
    }
    
    private void PlayMusicForLevel(Scene scene)
    {
        if (scene.name == "Main Menu" && musicSource.clip != menuMusic)
        {
            musicSource.clip = menuMusic;
            musicSource.Play();
        }
        
        if (scene.name == "MainLevel" && musicSource.clip != mainLevelMusic)
        {
            musicSource.Stop();
            musicSource.clip = mainLevelMusic;
            musicSource.Play();
        }
    }
}