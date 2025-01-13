using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorScript : MonoBehaviour
{
    public static bool isGeneratorOn = false;
    bool isOffCompletely = false;

    public GameObject lightSource;
    public GameObject lightSourceRoom;

    public GameObject lockedPowerDoor;
    public GameObject sequenceCollider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isGeneratorOn == true && isOffCompletely == false)
        {
            lightSource.SetActive(true);
            lightSourceRoom.SetActive(true);
            sequenceCollider.SetActive(true);

            isOffCompletely = true;

            // Add functioning power door
        }
    }
}
