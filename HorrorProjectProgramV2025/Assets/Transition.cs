using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.XR;
using UnityEngine;
using UnityEngine.UI;

public class Transition : MonoBehaviour
{
    public string functionName;
    Dictionary<string, Action> action;

    public float ActionTime = 1f;
    private float timeInAction = 0f;
    public bool InAction = false;

    [Range(1, 60)]
    public int speedInFrames = 0; 

    public Image img;
    public int fps = 1;

    private void Start()
    {
        action = new Dictionary<string, Action>
        {
            { "Fill left to right", fillLeftToRight},
        };
    }

    private void Update()
    {
        fps = (int)(1f / Time.unscaledDeltaTime);
        try
        {
            if (functionName != null && InAction)
            {
                action[functionName]();
            }
        }
        catch { }

    }

    private void OnMouseDown()
    {
        timeInAction = 0f;
        InAction = true;
    }

    void fillLeftToRight()
    {
        if (timeInAction < ActionTime)
        {
            img.fillAmount = timeInAction;
            timeInAction += 1f / fps;
        }
        else
        {
            InAction = false;
            img.fillAmount = 1f;
            timeInAction = 0f;
        }
    }
}
