using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosition : MonoBehaviour
{
    [SerializeField] private Transform thingToPointTo;
    public bool isInTrigger = true;
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("point"))
        {
            thingToPointTo.GetComponent<SpriteRenderer>().color = Color.red;
            isInTrigger = false;
            Debug.Log("Thing Exited Trigger");
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("point"))
        {
            thingToPointTo.GetComponent<SpriteRenderer>().color = Color.white;
            isInTrigger = true;
            Debug.Log("Thing is staying in Trigger");
        }
    }
    
    
    // Update is called once per frame
    void Update()
    {
        Cursor.visible = false;
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0;
        thingToPointTo.position = mouseWorldPosition;
    }
}
