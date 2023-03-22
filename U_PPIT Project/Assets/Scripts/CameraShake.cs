using System.Collections;
using Cinemachine;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake cameraShakeInstance;
    private CinemachineVirtualCamera cinemachineVirtualCamera;

    private void Awake()
    {
        //Camera shake instance is equal to this instance of the class
        cameraShakeInstance = this;
        cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    public void ShakeTheCamera(float shakeIntensity, float shakeCameraTimer)
    {
        StartCoroutine(ShakeCamera_Coroutine(shakeIntensity, shakeCameraTimer));
    }

    IEnumerator ShakeCamera_Coroutine(float shakeIntensity, float shakeCameraTimer)
    {
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin
            = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = shakeIntensity;
        yield return new WaitForSeconds(shakeCameraTimer);
        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0f;
    }
    
    //REFERENCES// 
    /***************************************************************************************
    *    Title: How to do Camera Shake with Cinemachine!
    *    Author: Code Monkey
    *    Date: June 10, 2020
    *    Code version: Unknown
    *    Availability: https://www.youtube.com/watch?v=ACf1I27I6Tk
    *
    ***************************************************************************************/
    
}
