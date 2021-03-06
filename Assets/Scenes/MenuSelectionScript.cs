﻿using UnityEngine;
using System.Collections;

public class MenuSelectionScript : MonoBehaviour
{
    const float DEAD_ZONE = 0.01f;
    const int MS_DELAY = 300;
    const int MS_REPEAT = 120;

    float timeHeld;
    float timeSinceRepeat;

    public float menuDirSel = 0;
    public int elemAmount = 4;
    public int currSel = 0;
    private float spacing = 40;

    public void Update()
    {
        menuDirSel = GetStepping(Input.GetAxisRaw("Vertical"));
        Debug.Log(menuDirSel);
        //Debug.Log(Input.GetAxisRaw("Vertical"));
        currSel += Mathf.RoundToInt(menuDirSel);
        if (currSel < 0)
        {
            currSel = elemAmount-1;
        }
        if (currSel >= elemAmount)
        {
            currSel = 0;
        }

        Vector3 pos = transform.localPosition;
        
        float midVal = (elemAmount / 2) - 0.5f;
        pos.y = (currSel - midVal) * spacing;
        transform.localPosition = pos;
    }

    public float GetStepping(float direction)
    {
        bool stepThisFrame = false;

        // If moving along any axis, normalize along that axis.
        if (direction != 0)
        {
            if (direction < -DEAD_ZONE)
            {
                direction = -1;
            }
            else if (direction > DEAD_ZONE)
            {
                direction = 1;
            }
        }

        // If we have input outside the dead zone
        if (direction != 0)
        {
            if (timeHeld == 0)
            {
                // If this is new input, we go
                stepThisFrame = true;
            }

            timeHeld += Time.deltaTime *1000;

            if (timeHeld > MS_DELAY - MS_REPEAT)
            {
                // start counting up to the first repetetion
                timeSinceRepeat += Time.deltaTime * 1000;

                if (timeSinceRepeat > MS_REPEAT)
                {
                    timeSinceRepeat -= MS_REPEAT;
                    stepThisFrame = true;
                }
            }
        }
        else
        {
            // If there is completely new input, we reset the time held.
            timeHeld = 0;
            timeSinceRepeat = 0;
        }

        if (stepThisFrame)
        {
            return direction;
        }

        return 0;
    }
}
