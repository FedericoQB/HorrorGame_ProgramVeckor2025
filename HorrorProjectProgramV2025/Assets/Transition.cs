using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    public string functionName;
    Dictionary<string, Action> action;

    public float ActionTime;

    private void Awake()
    {
        action = new Dictionary<string, Action>
        {
            { "Left to right", leftToRight},
        };
    }

    void leftToRight()
    {

    }
}
