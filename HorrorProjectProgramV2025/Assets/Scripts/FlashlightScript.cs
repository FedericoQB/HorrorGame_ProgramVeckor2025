using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightScript : MonoBehaviour
{
    public GameObject flashLight;
    bool lightOn = false;

    void Start()
    {
        flashLight.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && lightOn != true)
        {
            flashLight.SetActive(true);
            lightOn = true;
        }
        else if (Input.GetKeyDown(KeyCode.F) && lightOn == true)
        {
            flashLight.SetActive(false);
            lightOn = false;
        }
    }
}
