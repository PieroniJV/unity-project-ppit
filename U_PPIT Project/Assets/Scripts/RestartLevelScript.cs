using UnityEngine;

public class RestartLevelScript : MonoBehaviour
{
    [SerializeField] private Animator fadeOutScreenAnimator;
    private AudioSource musicSource;

    private void Awake()
    {
        var musicSourceGO = GameObject.Find("SoundManager");
        if (musicSourceGO != null)
        {
            musicSource = musicSourceGO.GetComponent<AudioSource>();
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            musicSource.Stop();
            fadeOutScreenAnimator.Play("LevelFadeIn");
        }
    }

}