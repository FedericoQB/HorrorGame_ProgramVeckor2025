using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnScript : MonoBehaviour
{
    public GameObject enemy1;
    public GameObject enemy2;

    bool hasSpawned = false;
    public bool spawnActive = false;

    public int amountOfEnemies;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (HeartScript.isDead == true && hasSpawned != true)
        {
            SpawnEnemy(enemy1);
            SpawnEnemy(enemy2);

            hasSpawned = true;
        }

        if (spawnActive == true)
        {
            SpawnEnemy(enemy1);
            spawnActive = false;
        }
    }

    void SpawnEnemy(GameObject enemy)
    {

        for (int i = 0; i < amountOfEnemies; i++)
        {
            GameObject enemyChild = Instantiate(enemy, new Vector3(Random.Range(-12f, 11f), transform.position.y, transform.position.z), Quaternion.identity);
            enemyChild.transform.parent = gameObject.transform;
        }
    }
}
