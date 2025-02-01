using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupScript : MonoBehaviour
{
    bool isPlayerNear = false;
    public bool completesQuest;
    string tagOfObject;

    // Start is called before the first frame update
    void Start()
    {
        tagOfObject = gameObject.tag;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerNear == true && Input.GetKeyDown(KeyCode.E))
        {
            if (tagOfObject == "Key")
            {
                Debug.Log("Key Picked Up");
                PlayerStatsScript.hasKey = true;
            }
            else if (tagOfObject == "Battery")
            {
                Debug.Log("Battery Picked Up");
                PlayerStatsScript.reserveBattery++;
            }

            if (completesQuest == true)
            {
                UpdateJournal();
            }

            if (tagOfObject == "ChainKey")
            {
                PlayerStatsScript.hasChainKeys = true;
            }

            Destroy(gameObject);
        }
    }

    void UpdateJournal()
    {
        JournalScript.questNumber++;
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
}
