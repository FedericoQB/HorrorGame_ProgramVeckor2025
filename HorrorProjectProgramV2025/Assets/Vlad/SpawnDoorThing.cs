using System.Collections;
using System.Collections.Generic;
using UnityEditor.XR;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnDoorThing : MonoBehaviour
{
    public int SceneID;

    public GameObject[] DoorsInHallway2;
    public bool ifDoorsInHallway2 = true;
    public GameObject[] DoorsInHallway3;

    private void Update()
    {
        SceneID = SceneManager.GetActiveScene().buildIndex;
        if (SceneID == 4)
        {
            DoorsInHallway2 = GameObject.FindGameObjectsWithTag("Door");
            ifDoorsInHallway2 = false;
        }
    }
}
