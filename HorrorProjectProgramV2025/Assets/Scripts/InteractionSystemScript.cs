using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionSystemScript : MonoBehaviour
{
    public GameObject journalCanvas;
    bool journalOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && journalOpen != true)
        {
            journalCanvas.SetActive(true);
            journalOpen = true;
        }
        else if (Input.GetKeyDown(KeyCode.Tab) && journalOpen == true)
        {
            journalCanvas.SetActive(false);
            journalOpen = false;
        }
    }
}
