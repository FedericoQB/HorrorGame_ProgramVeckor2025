using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnOffScript : MonoBehaviour
{
    bool isPlayerNear = false;
    public bool isInteractableAgain = false;
    public bool isOn = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerNear == true && Input.GetKeyDown(KeyCode.E) && isOn == true)
        {
            isOn = false;
            if (gameObject.tag == "Generator")
            {
                Debug.Log("Generator is on");
                GeneratorScript.isGeneratorOn = true;

                AddToJournal();
            }
        }

        if (isInteractableAgain == true)
        {
            isOn = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isPlayerNear = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isPlayerNear = false;
        }
    }

    void AddToJournal()
    {
        JournalScript.questNumber++;
    }
}
