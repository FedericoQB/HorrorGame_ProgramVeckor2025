using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsScript : MonoBehaviour
{
    public static bool hasChainKeys = false;
    public static bool hasKey = false;
   

    [Header("Battery Components")]
    public Image batteryBar;
    [Range(0.0f, 1f)]
    public float batteryProcent = 1f;
    //public float maxBatteryProcent = 100f;
    public static float flashlightBatteryProcent = 100;
    public int multiplierDrain = 2;
    public static int reserveBattery = 0;

    [Header("Insanity Settings")]
    public int insanityLevel = 1;
    GameObject volumeBox;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        batteryProcent = flashlightBatteryProcent / 100;

        if (Input.GetKeyDown(KeyCode.P))
        {
            Application.Quit();
        }

        CheckBattery(flashlightBatteryProcent);
        UpdateBatteryBar();

        if (flashlightBatteryProcent > 0 && FlashlightScript.lightOn)
        {
            flashlightBatteryProcent -= Time.deltaTime * multiplierDrain;
        }

        CheckInsanityLevel();
        
    }

    void CheckBattery(float battery)
    {
        if (battery <= 0)
        {
            if (reserveBattery > 0)
            {
                reserveBattery--;
                flashlightBatteryProcent = 100;
            }
            else
            {
                FlashlightScript.enoughBattery = false;
            }
            
        }
        else if (battery > 0)
        {
            FlashlightScript.enoughBattery = true;
        }
    }

    void UpdateBatteryBar()
    {
        batteryBar.fillAmount = batteryProcent;
    }

    void CheckInsanityLevel()
    {
        if (insanityLevel == 1)
        {

        }
    }
}
