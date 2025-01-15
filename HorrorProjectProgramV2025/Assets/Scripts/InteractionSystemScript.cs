using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionSystemScript : MonoBehaviour
{
    bool isPlayerNear = false;
    public bool isAbleToPickUp = false;
    public bool isADoor = false;
    public bool isLocked = false;
    public bool isAbleToTurnOn = false;
    public bool isInteractableAgain = false;
    public bool completesQuest = false;

    public GameObject newRoom;
    public GameObject OriginalRoom;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isPlayerNear == true)
        {
            Debug.Log("Interacted");

            if (isAbleToPickUp == true)
            {
                if (gameObject.tag == "Note")
                {
                    PickUpObject("Note");
                }
                
                Debug.Log("Picked up object");
                if (completesQuest == true)
                {
                    AddToJournal();
                }
            }
            
            if (isADoor == true && isLocked != true)
            {
                Debug.Log("Opened Door");
                if (gameObject.tag == "Door")
                {
                    OriginalRoom.SetActive(false);
                    newRoom.SetActive(true);

                    if (completesQuest == true)
                    {
                        AddToJournal();
                    }
                }
            }
            else if (isADoor == true && isLocked == true)
            {
                Debug.Log("Locked Door");
            }

            if (isAbleToTurnOn == true && isInteractableAgain == true)
            {
                if (gameObject.tag == "Generator")
                {
                    Debug.Log("Generator is on");
                    GeneratorScript.isGeneratorOn = true;

                    JournalScript.questNumber++;

                    isInteractableAgain = false;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("TriggerOn");

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

    void PickUpObject(string obj)
    {
        if (obj == "Note")
        {
            JournalScript.notes++;
            Destroy(gameObject);
        }
        
    }

    void AddToJournal()
    {
        JournalScript.questNumber++;
    }
}
