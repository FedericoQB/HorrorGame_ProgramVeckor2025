using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;
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
    public float insanityLevel = 1f;
    public float breakingPoint = 10f;


    //public VolumeProfile volumeProfile;
    //ChromaticAberration cAb;

    // Start is called before the first frame update
    void Start()
    {
        //cAb = volumeProfile.GetComponent<ChromaticAberration>();
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

        //CheckInsanityLevel(insanityLevel);
        //insanityLevel += Time.deltaTime;
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

    /* Problematic
    void CheckInsanityLevel(float amount)
    {
        if (amount > breakingPoint / 2)
        {
            cAb.intensity.value = 0.5f;
        }
        else if (amount > breakingPoint)
        {
                cAb.intensity.value = 1f;
        }

        if (amount < breakingPoint / 2)
        {
            cAb.intensity.value = 0f;
        }
    }
    */
}
