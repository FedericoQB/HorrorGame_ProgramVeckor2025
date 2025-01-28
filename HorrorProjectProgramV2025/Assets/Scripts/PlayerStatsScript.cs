using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsScript : MonoBehaviour
{
    public static bool hasChainKeys = false;
    public static bool hasKey = false;
    public static float flashlightBatteryProcent = 100;
    public int multiplierDrain = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Application.Quit();
        }

        CheckBattery(flashlightBatteryProcent);

        if (flashlightBatteryProcent > 0 && FlashlightScript.lightOn)
        {
            flashlightBatteryProcent -= Time.deltaTime * multiplierDrain;
        }
    }

    void CheckBattery(float battery)
    {
        Debug.Log(flashlightBatteryProcent);
        if (battery <= 0)
        {
            FlashlightScript.enoughBattery = false;
        }
        else if (battery > 0)
        {
            FlashlightScript.enoughBattery = true;
        }
    }
}
