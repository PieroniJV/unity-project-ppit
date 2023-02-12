using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBoundaries : MonoBehaviour
{
    [SerializeField] private Vector2 leftAndBottomPosition;
    [SerializeField] private Vector2 rightAndTopPosition;
    [SerializeField] private Transform player;
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(Vector2.Lerp(leftAndBottomPosition, rightAndTopPosition, 0.5f), rightAndTopPosition - leftAndBottomPosition);
    }

    // Update is called once per frame
    void Update()
    {
       KeepInBounds();
    }

    //Reference: https://www.youtube.com/watch?v=ailbszpt_AI&t=204s
    private void KeepInBounds()
    {
        Vector3 viewPosition = player.position;
        viewPosition.x = Mathf.Clamp(viewPosition.x, leftAndBottomPosition.x, rightAndTopPosition.x);
        viewPosition.y = Mathf.Clamp(viewPosition.y, leftAndBottomPosition.y, rightAndTopPosition.y);
        player.position = viewPosition;
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
