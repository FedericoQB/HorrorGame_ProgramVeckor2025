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

            SpawnEnemy(5);
            SpawnEnemy(-5);
        }
    }

    void SpawnEnemy(float xValue)
    {
        GameObject newSpawnedObject = Instantiate(enemy, new Vector3(xValue, enemySpawnLocation.y, 1), Quaternion.identity);
        newSpawnedObject.transform.parent = gameObject.transform;
    }
}
