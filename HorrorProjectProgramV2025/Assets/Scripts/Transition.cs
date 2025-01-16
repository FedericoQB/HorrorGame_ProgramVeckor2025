using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.XR;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    public string functionName;
    Dictionary<string, Action> action;

    public float ActionTime = 1f;
    private float timeInAction = 0f;
    public bool InAction = false;

    [Range(1, 60)]
    public int speedInFrames = 0;

    public int ToSceneById = 0;

    public Image img;
    public int fps = 1;



    private void Start()
    {
        action = new Dictionary<string, Action>
        {
            { "Fill left to right", fillLeftToRight},
            { "Empty right to left", emptyRightToLeft},
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !InAction)
        {
            functionName = "Fill left to right";
            InAction = true;
            timeInAction = 0f;
        }
    }

    void fillLeftToRight()
    {
        img.fillOrigin = 0;
        if (timeInAction < ActionTime)
        {
            img.fillAmount = timeInAction;
            timeInAction += (float)speedInFrames / (float)fps;
        }
        else
        {
            InAction = false;
            img.fillAmount = 1f;
            timeInAction = 0f;
            SceneManager.LoadScene(ToSceneById);
        }
    }

    void emptyRightToLeft()
    {
        img.fillOrigin = 1;
        if (timeInAction < ActionTime)
        {
            img.fillAmount = ActionTime - timeInAction;
            timeInAction += (float)speedInFrames / (float)fps;
        }
        else
        {
            InAction = false;
            img.fillAmount = 0f;
            timeInAction = 0f;
        }
    }
}
