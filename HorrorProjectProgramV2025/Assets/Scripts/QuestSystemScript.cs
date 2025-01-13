using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestSystemScript : MonoBehaviour
{
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

        }
    }
}
