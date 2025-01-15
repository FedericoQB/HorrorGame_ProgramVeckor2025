using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Transform SpawnPosition;
    GameObject player;

    private void Start()
    {
        if (SpawnPosition != null)
        {
            player = GameObject.FindGameObjectsWithTag("Player")[0];
            player.transform.position = SpawnPosition.transform.position;
        }
        else
        {
            player = GameObject.FindGameObjectsWithTag("Player")[0];
            player.transform.position = new Vector3(0f, 0f, 1f);
        }
    }
}
