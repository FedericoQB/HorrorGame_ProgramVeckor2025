using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionSystemScript : MonoBehaviour
{
    bool isPlayerNear = false;
    public bool isAbleToPickUp = false;
    public bool isADoor = false;
    public bool isKeyLocked = false;
    public bool isAbleToTurnOn = false;

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
                PickUpObject();
                Debug.Log("Picked up object");
            }
            
            if (isADoor == true && isKeyLocked != true)
            {
                Debug.Log("Opened Door");
            }
            else if (isADoor == true && isKeyLocked == true)
            {
                Debug.Log("Locked Door");
            }

            if (isAbleToTurnOn == true)
            {
                if (gameObject.tag == "Generator")
                {
                    Debug.Log("Generator is on");
                    GeneratorScript.isGeneratorOn = true;

                    JournalScript.questNumber++;
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

    void PickUpObject()
    {
        // Temporary Function
        Destroy(gameObject);
    }
}
