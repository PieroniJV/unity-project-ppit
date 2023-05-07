using UnityEngine;


public class CameraZoom : MonoBehaviour
{
    private Camera mainCamera;
    [SerializeField] private float zoomSpeed = 2f;
        
        
    private void Awake()
    {
        mainCamera = Camera.main;
    }

    public void LateUpdate()
    {
        mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, 7.86f, zoomSpeed);
    }
    
} 

    
//////////////
//REFERENCES//
//////////////

/***************************************************************************************
*    Title: How to Make Smooth 2D Zoom Effect Camera Unity3D Tutorial
     Author: LemauDev
     Date: Feb 6, 2020
*    Code version: Unknown
*    Availability: https://www.youtube.com/watch?v=AvnrywsoTe0
*

***************************************************************************************/
