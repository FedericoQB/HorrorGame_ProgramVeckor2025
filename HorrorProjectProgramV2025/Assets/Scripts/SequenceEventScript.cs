using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceEventScript : MonoBehaviour
{
    bool isTriggered = false;

    public GameObject lightSources;
    public GameObject enemy;
    public GameObject enemySpawn;

    Vector3 enemySpawnLocation;

    // Start is called before the first frame update
    void Start()
    {
        enemySpawnLocation = enemySpawn.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && isTriggered == false)
        {
            isTriggered = true;
            lightSources.SetActive(false);
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemy, enemySpawnLocation, Quaternion.identity);
    }
}
