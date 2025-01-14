using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightDamageScript : MonoBehaviour
{
    public GameObject targetEnemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Trigger Collided");

        if (collision.gameObject.tag == "Enemy")
        {
            //Debug.Log("Collided With Enemy");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            //Debug.Log("Collided With Enemy");
            GameObject enemy = collision.gameObject;
            enemy.GetComponent<EnemyAI>().action = "Runaway Player";
            enemy.GetComponent<EnemyAI>().timeWhenWeNextDoSomething = Time.time + enemy.GetComponent<EnemyAI>().timeBetweenDoingSomething;
        }
    }
}
