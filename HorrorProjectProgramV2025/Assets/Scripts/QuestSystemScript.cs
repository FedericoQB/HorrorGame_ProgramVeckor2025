using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestSystemScript : MonoBehaviour
{
    #region Quests
    public GameObject quest1;
    public GameObject quest2;
    public GameObject quest3;
    public GameObject quest4;
    public GameObject quest5;
    public GameObject quest6;
    public GameObject quest7;

    #endregion

    #region Checkmarks
    public GameObject checkmark1;
    public GameObject checkmark2;
    public GameObject checkmark3;
    public GameObject checkmark4;
    public GameObject checkmark5;
    public GameObject checkmark6;
    public GameObject checkmark7;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        UpdateJournal();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateJournal()
    {
        Debug.Log("Updated Journal");
        if (JournalScript.questNumber == 2)
        {
            quest2.SetActive(true);
            checkmark2.SetActive(true);
        }
        else if (JournalScript.questNumber == 3)
        {
            quest3.SetActive(true);
            checkmark3.SetActive(true);

        }
        else if (JournalScript.questNumber == 4)
        {
            quest4.SetActive(true);
            checkmark4.SetActive(true);

        }
        else if (JournalScript.questNumber == 5)
        {
            quest5.SetActive(true);
            checkmark5.SetActive(true);

        }
        else if (JournalScript.questNumber == 6)
        {
            quest6.SetActive(true);
            checkmark6.SetActive(true);

        }
        else if (JournalScript.questNumber == 7)
        {
            quest7.SetActive(true);
            checkmark7.SetActive(true);

        }
    }
}
