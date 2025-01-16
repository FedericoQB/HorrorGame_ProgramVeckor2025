using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.XR;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnDoorThing : MonoBehaviour
{
    public int SceneID;

    public List<GameObject> DoorsInHallway1;
    public bool ifDoorsInHallway1 = true;
    public List<GameObject> DoorsInHallway2;
    public bool ifDoorsInHallway2 = true;
    public List<GameObject> DoorsInHallway3;
    public bool ifDoorsInHallway3 = true;

    public List<GameObject> Doors1;
    public List<GameObject> Doors2;
    public List<GameObject> Doors3;

    private void Update()
    {
        SceneID = SceneManager.GetActiveScene().buildIndex;
        if (SceneID == 4 && ifDoorsInHallway2)
        {
            DoorsInHallway2 = GameObject.FindGameObjectsWithTag("Door").ToList();
            ifDoorsInHallway2 = false;
            for (int i = 0; i < 3; i++)
            {
                GameObject random = DoorsInHallway2[(int)Random.Range(0, DoorsInHallway2.Count)];
                Doors2.Add(random);
                DoorsInHallway2.Remove(random);
            }
        }
        if (SceneID == 3 && ifDoorsInHallway1)
        {
            DoorsInHallway1 = GameObject.FindGameObjectsWithTag("Door").ToList();
            ifDoorsInHallway1 = false;
            for (int i = 0; i < 3; i++)
            {
                GameObject random = DoorsInHallway1[(int)Random.Range(0, DoorsInHallway1.Count)];
                print(DoorsInHallway1.Count);
                Doors1.Add(random);
                DoorsInHallway1.Remove(random);
            }
        }
        if (SceneID == 5 && ifDoorsInHallway2)
        {
            DoorsInHallway3 = GameObject.FindGameObjectsWithTag("Door").ToList();
            ifDoorsInHallway3 = false;
            for (int i = 0; i < 3; i++)
            {
                GameObject random = DoorsInHallway3[(int)Random.Range(0, DoorsInHallway3.Count)];
                Doors3.Add(random);
                DoorsInHallway3.Remove(random);
            }
        }
    }
}
