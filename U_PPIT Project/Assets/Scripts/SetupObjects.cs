using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class SetupObjects : MonoBehaviour
{
    private GameObject canvas;
    private GameObject projectile;

    private void Awake()
    {
        //Find gameobjects
        canvas = GameObject.Find("Canvas");
        projectile = GameObject.Find("Projectile");
        
        canvas.GetComponentInChildren<Animator>(true).gameObject.SetActive(true);
        projectile.GetComponent<Projectile>().enabled = false;
    }
}
