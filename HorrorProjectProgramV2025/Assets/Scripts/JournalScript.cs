using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class JournalScript : MonoBehaviour
{
    public GameObject journalCanvas;
    public GameObject firstPage;
    public GameObject secondPage;

    public Sprite checkedMark;

    public AudioClip flipSound;  // Add this to assign your flip sound
    private AudioSource audioSource;  // Add an AudioSource component

    bool journalOpen = false;

    public static int questNumber = 1;
    int currentQuestNumber = 1;

    public static int notes = 0;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

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
                PlayFlipSound();  // Play sound when flipping
                firstPage.SetActive(false);
                secondPage.SetActive(true);
            }
            if (Input.GetKeyDown(KeyCode.Z) && secondPage.activeInHierarchy == true)
            {
                PlayFlipSound();  // Play sound when flipping
                firstPage.SetActive(true);
                secondPage.SetActive(false);
            }
        }
        else
        {
            firstPage.SetActive(true);
            secondPage.SetActive(false);
        }

        // Checks and updates journal
        CheckQuestNumber(questNumber);
        UpdateJournal();

        if (PlayerHealth.healthStat <= 0)
        {
            questNumber = 1;
            currentQuestNumber = 1;
        }
    }

    void PlayFlipSound()
    {
        if (audioSource != null && flipSound != null)
        {
            audioSource.PlayOneShot(flipSound);
        }
    }

    void CheckQuestNumber(int number)
    {
        if (number > currentQuestNumber)
        {
            Debug.Log("Quest Done");

            UpdateQuest(currentQuestNumber);

            currentQuestNumber++;
        }
    }

    void UpdateQuest(int questNumber)
    {
        GameObject originalGameObject = firstPage;

        GameObject child = originalGameObject.transform.GetChild(questNumber - 1).gameObject;

        Debug.Log("Updated Quests");
        child.GetComponent<Image>().sprite = checkedMark;
    }

    void UpdateJournal()
    {
        if (notes == 1)
        {
            Debug.Log("Updated Journal");
            notes--;
        }
    }


}
