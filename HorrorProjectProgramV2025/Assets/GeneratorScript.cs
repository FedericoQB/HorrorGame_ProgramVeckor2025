using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorScript : MonoBehaviour
{
    public static bool isGeneratorOn = false;

    public GameObject lightSource;

    public GameObject lockedPowerDoor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isGeneratorOn == true)
        {
            lightSource.SetActive(true);

            // Add functioning power door
        }
    }
}
