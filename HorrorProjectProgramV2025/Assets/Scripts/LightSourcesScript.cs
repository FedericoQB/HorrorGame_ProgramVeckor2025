using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSourcesScript : MonoBehaviour
{
    public GameObject originalRoom;
    public GameObject newRoom;
    public GameObject lightSources;

    public bool isStillActive = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (newRoom.active == true && originalRoom.active != true && isStillActive == true)
        {
            lightSources.SetActive(true);
        }
        else
        {
            lightSources.SetActive(false);
        }
    }
}
