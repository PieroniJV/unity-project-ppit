using UnityEngine;

public class RotateTowardsMouse : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 5f;

    
    // Update is called once per frame
    void Update()
    {
        Vector2 lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angleForRotation = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        Quaternion weaponRotation = Quaternion.AngleAxis(angleForRotation, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, weaponRotation, rotateSpeed * Time.deltaTime);
    }
    
    //REFERENCES// 
    /***************************************************************************************
    *    Title: Rotate or Aim Towards Mouse or Object in 2D - Unity [ENG]
    *    Author: Krister Cederlund
    *    Date: June 6, 2017
    *    Code version: Unknown
    *    Availability: https://www.youtube.com/watch?v=mKLp-2iseDc
    *
    ***************************************************************************************/
}
