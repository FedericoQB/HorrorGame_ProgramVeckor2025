using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class JournalScript : MonoBehaviour
{
    public GameObject journalCanvas;
    public GameObject firstPage;
    public GameObject secondPage;

    public Sprite checkedMark;

    bool journalOpen = false;

    public static int questNumber = 1;
    int currentQuestNumber = 1;
    

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

        CheckQuestNumber(questNumber);

    }

    // This is to check which quest the player is on, if it is bigger than the previous number, the quest has been completed and will update the journal
    void CheckQuestNumber(int number)
    {
        if (number > currentQuestNumber)
        {
            currentQuestNumber++;
            Debug.Log("Quest Done");

            UpdateJournal();
        }
    }

    // This is to Update the journal, bring forth the next text and adding a check on the previous quest
    void UpdateJournal()
    {
        GameObject originalGameObject = firstPage;
        GameObject child = originalGameObject.transform.GetChild(1).gameObject;

        Debug.Log("Updated Journal");
        child.GetComponent<Image>().sprite = checkedMark;
    }
}
