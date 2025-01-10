using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JournalScript : MonoBehaviour
{
    public GameObject journalCanvas;
    public GameObject firstPage;
    public GameObject secondPage;
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

        if (journalOpen == true)
        {
            if (Input.GetKeyDown(KeyCode.X) && firstPage.activeInHierarchy == true)
            {
                firstPage.SetActive(false);
                secondPage.SetActive(true);
            }
            if (Input.GetKeyDown(KeyCode.Z) && secondPage.activeInHierarchy == true)
            {
                firstPage.SetActive(true);
                secondPage.SetActive(false);
            }
        }
        else
        {
            firstPage.SetActive(true);
            secondPage.SetActive(false);
        }
    }
}
