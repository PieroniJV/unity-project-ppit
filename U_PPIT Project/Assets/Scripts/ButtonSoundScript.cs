using UnityEngine;
using UnityEngine.UI;

public class ButtonSoundScript : MonoBehaviour
{
    [SerializeField] private AudioClip buttonClickSound;
    private AudioSource soundManager;
    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
        var soundManagerGO = GameObject.Find("SoundManager");
        if (soundManagerGO != null)
        {
            soundManager = soundManagerGO.GetComponent<AudioSource>();
        }
        button.onClick.AddListener(PlayButtonSound);
    }
    
    private void PlayButtonSound()
    {
        if (soundManager != null)
        {
            soundManager.PlayOneShot(buttonClickSound);
        }
    }
}

//REFERENCES// 
/***************************************************************************************
*    Title: How to detect if button is clicked unity?
*    Question By: Andrew Rohm
*    Answer By: TEEBQNE
*    Date Asked: Sep 20, 2021
     Date Answered: Sep 21, 2021
*    Availability: https://stackoverflow.com/questions/69259615/how-to-detect-if-button-is-clicked-unity
*
***************************************************************************************/
