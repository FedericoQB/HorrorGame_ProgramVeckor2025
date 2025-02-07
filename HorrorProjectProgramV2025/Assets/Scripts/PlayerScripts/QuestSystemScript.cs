using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestSystemScript : MonoBehaviour
{
    #region Quests
    public List<GameObject> quests = new List<GameObject>();

    #endregion

    #region Checkmarks
    public List<GameObject> checkMarks = new List<GameObject>();

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        UpdateJournal();
        Debug.Log("QuestSystemActive");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateJournal()
    {
        Debug.Log("Updated Journal");
        try
        {
            quests[JournalScript.questNumber - 1].gameObject.SetActive(true);
            checkMarks[JournalScript.questNumber - 1].gameObject.SetActive(true);
        }
        catch
        {
            print("Error to update Journal");
        }
    }
}
