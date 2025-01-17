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
    public GameObject DoorFloor1;
    public GameObject Door1Floor2;
    public GameObject Door2Floor2;
    public GameObject Door3Floor2;
    public GameObject Door1Floor3;
    public GameObject Door2Floor3;
    public GameObject Door3Floor3;

    public bool f1 = true;
    public bool f2 = true;
    public bool f3 = true;

    public List<GameObject> SpawnPoints1;
    public List<GameObject> SpawnPoints2;
    public List<GameObject> SpawnPoints3;

    private Vector2 DoorPoint1F;
    private Vector2 DoorPoint2F1;
    private Vector2 DoorPoint2F2;
    private Vector2 DoorPoint2F3;
    private Vector2 DoorPoint3F1;
    private Vector2 DoorPoint3F2;
    private Vector2 DoorPoint3F3;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        SceneID = SceneManager.GetActiveScene().buildIndex;
        if (SceneID == 3)
        {
            DoorFloor1 = GameObject.Find("Door");
        }
        if (SceneID == 4)
        {
            Door1Floor2 = GameObject.Find("Door1");
            Door2Floor2 = GameObject.Find("Door2");
            Door3Floor2 = GameObject.Find("Door3");
        }
    }

    private void Update()
    {
        SceneID = SceneManager.GetActiveScene().buildIndex;

        if (SceneID == 3 && f1 && DoorFloor1 != null)
        {
            DoorFloor1.transform.position = SpawnPoints1[(int)Random.Range(0f, (float)SpawnPoints1.Count - 1f)].transform.position;
            DoorPoint1F = DoorFloor1.transform.position;
            f1 = false;
        }

        if (SceneID == 4 && f2)
        {
            int id = (int)Random.Range(0f, (float)SpawnPoints2.Count - 1f);
            Door1Floor2.transform.position = SpawnPoints2[id].transform.position;
            DoorPoint2F1 = Door1Floor2.transform.position;
            SpawnPoints2.RemoveAt(id);

            id = (int)Random.Range(0f, (float)SpawnPoints2.Count - 1f);
            Door2Floor2.transform.position = SpawnPoints2[id].transform.position;
            DoorPoint2F2 = Door2Floor2.transform.position;
            SpawnPoints2.RemoveAt(id);

            id = (int)Random.Range(0f, (float)SpawnPoints2.Count - 1f);
            Door3Floor2.transform.position = SpawnPoints2[id].transform.position;
            DoorPoint2F3 = Door3Floor2.transform.position;
            SpawnPoints2.RemoveAt(id);

            f2 = false;
        }

        if (SceneID == 5 && f3)
        {
            int id = (int)Random.Range(0f, (float)SpawnPoints3.Count - 1f);

            if (Door1Floor3 != null)
            {
                Door1Floor3.transform.position = SpawnPoints3[id].transform.position;
                DoorPoint3F1 = Door1Floor3.transform.position;
                SpawnPoints3.RemoveAt(id);
            }
            if (Door2Floor3 != null)
            {
                id = (int)Random.Range(0f, (float)SpawnPoints3.Count - 1f);
                Door2Floor3.transform.position = SpawnPoints3[id].transform.position;
                DoorPoint3F2 = Door2Floor3.transform.position;
                SpawnPoints2.RemoveAt(id);
            }
            if (Door3Floor3 != null)
            {
                id = (int)Random.Range(0f, (float)SpawnPoints3.Count - 1f);
                Door3Floor3.transform.position = SpawnPoints3[id].transform.position;
                DoorPoint3F3 = Door3Floor3.transform.position;
                SpawnPoints3.RemoveAt(id);
            }
            f3 = false;
        }

        if (SceneID == 3 && !f1)
        {
            try
            {
                DoorFloor1.transform.position = DoorPoint1F;
                GameObject door = GameObject.Find("Room 3");
                door.transform.position = new Vector3(DoorPoint1F.x + 3.7f, 1.09f, 3);
            }
            catch { }
        }

        if (SceneID == 4 && !f2)
        {
            try
            {
                Door1Floor2.transform.position = DoorPoint2F1;
                GameObject room1 = GameObject.Find("Door1");
                room1.transform.position = new Vector3(DoorPoint2F1.x + 3.7f, 1.09f, 3);

                Door2Floor2.transform.position = DoorPoint2F2;
                GameObject room2 = GameObject.Find("Door2");
                room2.transform.position = new Vector3(DoorPoint2F2.x + 3.7f, 1.09f, 3);

                Door3Floor2.transform.position = DoorPoint2F3;
                GameObject room3 = GameObject.Find("Door3");
                room3.transform.position = new Vector3(DoorPoint2F3.x + 3.7f, 1.09f, 3);
            }
            catch {}
        }

        if (SceneID == 5 && !f3)
        {
            Door1Floor3.transform.position = DoorPoint3F1;
            Door2Floor3.transform.position = DoorPoint3F2;
            Door3Floor3.transform.position = DoorPoint3F3;
        }
    }
}
