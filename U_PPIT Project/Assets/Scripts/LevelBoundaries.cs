using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBoundaries : MonoBehaviour
{
    [SerializeField] private Vector2 leftAndBottomPosition;
    [SerializeField] private Vector2 rightAndTopPosition;
    [SerializeField] private Transform currentObject;
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(Vector2.Lerp(leftAndBottomPosition, rightAndTopPosition, 0.5f), rightAndTopPosition - leftAndBottomPosition);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentObject != null)
        {
            KeepInBounds();
        }
    }

    //Reference: https://www.youtube.com/watch?v=ailbszpt_AI&t=204s
    private void KeepInBounds()
    {
        Vector3 viewPosition = currentObject.position;
        viewPosition.x = Mathf.Clamp(viewPosition.x, leftAndBottomPosition.x, rightAndTopPosition.x);
        viewPosition.y = Mathf.Clamp(viewPosition.y, leftAndBottomPosition.y, rightAndTopPosition.y);
        currentObject.position = viewPosition;
    }
    
    //////////////
    //REFERENCES//
    //////////////
    
    /***************************************************************************************
    *    Title: Unity - Keeping The Player Within Screen Boundaries
         Author: Press Start
         Date: Aug 18, 2018
    *    Code version: Unknown
    *    Availability: https://www.youtube.com/watch?v=ailbszpt_AI&t=204s
    *
    ***************************************************************************************/
}
