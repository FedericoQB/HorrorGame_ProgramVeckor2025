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

    public bool f1;
    public bool f2;
    public bool f3;

    public List<Vector2> SpawnPoints1;
    public List<Vector2> SpawnPoints2;
    public List<Vector2> SpawnPoints3;

    private void Update()
    {
        SceneID = SceneManager.GetActiveScene().buildIndex;

        if (SceneID == 3 && f1 && DoorFloor1 != null)
        {
            DoorFloor1.transform.position = SpawnPoints1[(int)Random.Range(0f, (float)SpawnPoints1.Count - 1f)];
            f1 = false;
        }

        if (SceneID == 4 && f2)
        {
            int id = (int)Random.Range(0f, (float)SpawnPoints2.Count - 1f);
            Door1Floor2.transform.position = SpawnPoints2[id];
            SpawnPoints2.RemoveAt(id);

            id = (int)Random.Range(0f, (float)SpawnPoints2.Count - 1f);
            Door2Floor2.transform.position = SpawnPoints2[id];
            SpawnPoints2.RemoveAt(id);

            id = (int)Random.Range(0f, (float)SpawnPoints2.Count - 1f);
            Door3Floor2.transform.position = SpawnPoints2[id];
            SpawnPoints2.RemoveAt(id);

            f2 = false;
        }

        if (SceneID == 5 && f3)
        {
            int id = (int)Random.Range(0f, (float)SpawnPoints3.Count - 1f);
            Door1Floor3.transform.position = SpawnPoints3[id];
            SpawnPoints3.RemoveAt(id);

            id = (int)Random.Range(0f, (float)SpawnPoints3.Count - 1f);
            Door2Floor3.transform.position = SpawnPoints3[id];
            SpawnPoints2.RemoveAt(id);

            id = (int)Random.Range(0f, (float)SpawnPoints3.Count - 1f);
            Door3Floor3.transform.position = SpawnPoints3[id];
            SpawnPoints3.RemoveAt(id);

            f3 = false;
        }
    }
}
