using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Transmission : MonoBehaviour
{
    public Image img;
    private float timeForTransmission;
    private float inAction = 0f;
    public Func<Action> function;

    private void Update()
    {
        if (function != null)
        {
            function();
        }
    }

    public void LeftToRight()
    {
        if (timeForTransmission == 0)
        {
            timeForTransmission = Time.time;
        }

        if (inAction > 0f)
        {
            img.fillOrigin = 0;

            inAction = 1 - (timeForTransmission / Time.time);
        }
    }
}
