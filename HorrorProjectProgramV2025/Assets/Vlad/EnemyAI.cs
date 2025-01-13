using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    Dictionary<string, Action> behaviour;
    public string action;
    Rigidbody2D rb;
    public float speed;
    [Range(1, 20)]
    public int speedOffset;
    public float timeBetweenDoingSomething = 5f;
    public float timeWhenWeNextDoSomething;

    private void Awake()
    {
        behaviour = new Dictionary<string, Action>
        {
            { "Chase Player", ChasePlayer },
            { "Runaway Player", RunawayPlayer }
        };

        action = "Runaway Player";
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timeWhenWeNextDoSomething = Time.time + timeBetweenDoingSomething;
    }

    private void Update()
    {
        if (behaviour.ContainsKey(action))
        {
            behaviour[action].Invoke();
        }
    }

    public void ChasePlayer()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Player");
        if (targets.Length > 0)
        {

            Vector2 direction = targets[0].transform.position - transform.position;

            rb.velocity = (Vector3.Normalize(direction) * speed);
        }
    }

    public void RunawayPlayer()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Player");
        if (targets.Length > 0)
        {
            if (timeWhenWeNextDoSomething <= Time.time)
            {
                action = "Chase Player";

                timeWhenWeNextDoSomething = Time.time + timeBetweenDoingSomething;
            }

            Vector2 direction = targets[0].transform.position - transform.position;
            float distance = Vector2.Distance(targets[0].transform.position, transform.position);

            rb.velocity = (Vector3.Normalize(-direction) * (speed / (distance / speedOffset)));
        }
    }
}
