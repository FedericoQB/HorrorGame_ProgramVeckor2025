using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightScript : MonoBehaviour
{
    public GameObject flashLight;
    public GameObject lightConePivot;
    public GameObject lightCone;
    bool lightOn = false;
    Quaternion flashlightAngle = new Quaternion();

    void Start()
    {
        flashLight.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // FLASHLIGHT DAMAGE SYSTEM NEEDS TO BE IMPLEMENTED
        // Angle of Flashlight, a 180 degree angle is based in between 0 - 1 on both the z and w axis
        
        if (Input.GetKey(KeyCode.W))
        {
            flashlightAngle = new Quaternion(0, 0, 0, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            flashlightAngle = new Quaternion(0, 0, 1, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            flashlightAngle = new Quaternion(0, 0, 0.70711f, -0.70711f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            flashlightAngle = new Quaternion(0, 0, 0.70711f, 0.70711f);
        }
        
        // Activation of Flashlight
        if (Input.GetKeyDown(KeyCode.F) && lightOn != true)
        {
            flashLight.SetActive(true);
            lightConePivot.SetActive(true);
            lightCone.SetActive(true);
            lightOn = true;
        }
        else if (Input.GetKeyDown(KeyCode.F) && lightOn == true)
        {
            flashLight.SetActive(false);
            lightConePivot.SetActive(false);
            lightCone.SetActive(false);
            lightOn = false;
        }

        flashLight.transform.rotation = flashlightAngle;
        lightConePivot.transform.rotation = flashlightAngle;

        

        //Debug.Log(angle);
    }
}
