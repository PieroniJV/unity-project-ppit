using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Projectile : MonoBehaviour
{
    [SerializeField] private LineRenderer _Line;
    [SerializeField] private float _Step;
    [SerializeField] private Transform _FirePoint;
    [SerializeField] private float _Height;
    [SerializeField] private Transform thingToPointTo;
    [SerializeField] private MousePosition _mousePosition;
    [SerializeField] private Transform exitTrigger;

    [SerializeField] private Transform ParentOfFirePoint;
    
    private bool canShootProjectile = false;
    private bool hasShotProjectile;
    
    
    private void Awake()
    {
        hasShotProjectile = false;
        _FirePoint.position = ParentOfFirePoint.position;
        thingToPointTo.gameObject.SetActive(false);
        exitTrigger.GetChild(0).gameObject.SetActive(false);
    }

    private void Update()
    {
        Vector3 targetPos = thingToPointTo.position - _FirePoint.position;        
        targetPos.z = 0;
        
        float angle;
        float v0;
        float time;
        float distance = Vector3.Distance (thingToPointTo.position, _FirePoint.position);
        float exitTriggerRadius = exitTrigger.GetComponent<CircleCollider2D>().radius;
        
        CalculatePathWithHeight(targetPos, _Height, out v0, out angle, out time);
        
        //Right mouse button
        if (Input.GetMouseButton(1))
        {
            if (hasShotProjectile == false)
            {
                DoRightMouseButtonAction(distance, exitTriggerRadius, v0, angle, time);
            }
        }
        else
        {
            canShootProjectile = false;
            thingToPointTo.gameObject.SetActive(false);
            exitTrigger.GetChild(0).gameObject.SetActive(false);
            SetProjectileTrajectoryVisibility(0);
        }
        
        
        if (Input.GetMouseButtonDown(0) && canShootProjectile)
        {
            StartCoroutine(Coroutine_DisableProjectileAction(5f));
            StartCoroutine(Coroutine_Movement(v0, angle, time));  //Converts the angle to radians as sin and cosine functions use Radians instead of degrees
        }
    }

    private void DoRightMouseButtonAction(float distance, float exitTriggerRadius, float v0, float angle, float time)
    {
        exitTrigger.GetChild(0).gameObject.SetActive(true);
        thingToPointTo.gameObject.SetActive(true);

        if (_mousePosition.isInTrigger || distance < exitTriggerRadius)
        {
            canShootProjectile = true;
            thingToPointTo.GetComponent<SpriteRenderer>().color = Color.white;
            SetProjectileTrajectoryVisibility(1);
            DrawPath(v0, angle, time, _Step);
        }
        else
        {
            canShootProjectile = false;
            thingToPointTo.GetComponent<SpriteRenderer>().color = Color.red;
            SetProjectileTrajectoryVisibility(0);
        }
    }


    public void SetProjectileTrajectoryVisibility(int visibleNumber)
    {
        if (visibleNumber == 0)
        {
            _Line.gameObject.SetActive(false);
        }
        else
        {
            _Line.gameObject.SetActive(true);
        }
        
    }
    
    void DrawPath(float v0, float angle, float time, float step)
    {
        step = Mathf.Max(0.01f, step);
        
        //Ensures that the position count is never set to a negative value
        int positionCount = (int)(time / step) + 2;
        if (positionCount < 0)
        {
            positionCount = 0;
        }
        _Line.positionCount = positionCount;
        
        int count = 0;
        for (float i = 0; i < time; i += step)
        {
            float x = v0 * i * Mathf.Cos(angle);
            float y = v0 * i * Mathf.Sin(angle) - 0.5f * -Physics.gravity.y * Mathf.Pow(i, 2);
            
            if (count < _Line.positionCount)
            {
                _Line.SetPosition(count, _FirePoint.position + new Vector3(x,y,0));
                count++;
            }
        }

        float xfinal = v0 * time * Mathf.Cos(angle);
        float yfinal = v0 * time * Mathf.Sin(angle) - 0.5f * -Physics.gravity.y * Mathf.Pow(time, 2);
        
        //Ensures that the index is checked against the position count
        if (count < _Line.positionCount)
        {
            _Line.SetPosition(count, _FirePoint.position + new Vector3(xfinal, yfinal, 0));
        }

    }

    private float QuadraticEquation(float a, float b, float c, float sign)
    {
        return (-b + sign * Mathf.Sqrt(b * b - 4 * a * c)) / (2 * a);
    }

    void CalculatePathWithHeight(Vector3 targetPos, float h, out float v0, out float angle, out float time)
    {
        float xt = targetPos.x;
        float yt = targetPos.y;
        float g = -Physics.gravity.y;

        float b = Mathf.Sqrt(2 * g * h);
        float a = (-0.5f * g);
        float c = -yt;

        float tplus = QuadraticEquation(a, b, c, 1);
        float tmin = QuadraticEquation(a, b, c, -1);
        time = tplus > tmin ? tplus : tmin;

        angle = Mathf.Atan(b * time / xt);

        v0 = b / Mathf.Sin(angle);
    }
    
    
    IEnumerator Coroutine_Movement(float v0, float angle, float time)
    {
        float t = 0;
        while (t < time)
        {
            float x = v0 * t * Mathf.Cos(angle);
            float y = v0 * t * Mathf.Sin(angle) - (1f / 2f) * -Physics.gravity.y * Mathf.Pow(t, 2);

            transform.position = _FirePoint.position + new Vector3(x, y, 0);
            t += Time.deltaTime;
            yield return null;
        }
    }

    IEnumerator Coroutine_DisableProjectileAction(float timeToWait)
    {
        _FirePoint.SetParent(null);
        canShootProjectile = false;
        thingToPointTo.gameObject.SetActive(false);
        exitTrigger.GetChild(0).gameObject.SetActive(false);
        SetProjectileTrajectoryVisibility(0);
        hasShotProjectile = true;
        
        yield return new WaitForSeconds(timeToWait);
        _FirePoint.SetParent(ParentOfFirePoint);
        _FirePoint.position = ParentOfFirePoint.position;
        hasShotProjectile = false;
        Debug.Log("Can now shoot projectile again");
    }
    
}



//////////////
//REFERENCES//
//////////////

/***************************************************************************************
*    Title: Projectile Movement & Why is it Useful? ( Unity Engine Tutorial )
     Author: A Bit Of Game Dev
     Date: Oct 24, 2021
*    Code version: Unknown
*    Availability: https://www.youtube.com/watch?v=Qxs3GrhcZI8
*

***************************************************************************************/