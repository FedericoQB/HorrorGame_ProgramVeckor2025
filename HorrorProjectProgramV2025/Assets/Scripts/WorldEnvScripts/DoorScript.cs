using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour
{
    bool isPlayerNear = false;
    public bool isLocked = false;
    public bool isOn = false;
    public static bool playerHasKey = false;
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
        if (Input.GetKeyDown(KeyCode.E) && isPlayerNear == true && isOn == true)
        {
            Debug.Log("Interacted");
            
            if (isLocked != true)
            {
                Debug.Log("Opened Door");

                OriginalRoom.SetActive(false);
                newRoom.SetActive(true);

                if (completesQuest == true)
                {
                    AddToJournal();
                    completesQuest = false;
                }

                if (gameObject.tag == "HeartRoomExit")
                {
                    if (HeartScript.hasPlayed == true)
                    {
                        HeartScript.isDead = true;
                        AddToJournal();
                    }
                    OriginalRoom.SetActive(false);
                    newRoom.SetActive(true);
                }
            }
            else if (isLocked == true)
            {
                Debug.Log("Locked Door");
                if (playerHasKey == true)
                {
                    Debug.Log("Opened Door");

                    OriginalRoom.SetActive(false);
                    newRoom.SetActive(true);

                    if (completesQuest == true)
                    {
                        AddToJournal();
                        completesQuest = false;
                    }

                    playerHasKey = false;
                }

                if (HeartScript.isDead == true && gameObject.tag == "Exit")
                {
                    SceneManager.LoadScene(0);
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

    void AddToJournal()
    {
        JournalScript.questNumber++;
    }
}
