using System;
using System.Collections;
using UnityEngine;

public class SpinAround : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject weapon;
    [SerializeField] private float rotationSpeed = 1.0f;
    [SerializeField] private float spinDuration = 5.0f;
    private bool isSpinning = false;
    private Quaternion initialRotation;
    
    private void Awake()
    {
        weapon.SetActive(false);
        initialRotation = transform.localRotation;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && !isSpinning)
        {
            StartCoroutine(Coroutine_SpinObject());
        }
    }

    IEnumerator Coroutine_SpinObject()
    {
        float spinTimer = 0.0f;
        isSpinning = true;
        
        weapon.SetActive(true);
        
        while (spinTimer < spinDuration)
        {
            float step = rotationSpeed * Time.deltaTime;
            transform.RotateAround(player.transform.position, Vector3.forward, step);
            spinTimer += Time.deltaTime;

            yield return null;
        }

        ResetWeaponRotation();
        weapon.SetActive(false);
        isSpinning = false;
    }
    
    public void ResetWeaponRotation()
    {
        // Set the weapon's local rotation back to the initial rotation
        transform.localRotation = initialRotation;
    }
    
}