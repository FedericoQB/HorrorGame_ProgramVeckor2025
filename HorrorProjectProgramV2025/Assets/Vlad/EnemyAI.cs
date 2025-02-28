using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.Burst.CompilerServices;
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
            { "Runaway Player", RunawayPlayer },
            { "Idle", Idle}
        };

        action = "Chase Player";
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

    public void Idle()
    {
        gameObject.GetComponent<Renderer>().enabled = true;
        gameObject.GetComponent<EnemyDamageExample>().enabled = false;

        GameObject[] targets = GameObject.FindGameObjectsWithTag("Player");
        if (targets.Length > 0)
        {
            float x = targets[0].transform.position.x;
            float y = targets[0].transform.position.y;

            float newX;
            float newY;

            Vector2 randomTarget;
            if (UnityEngine.Random.Range(0, 2) == 0)
            {
                newX = UnityEngine.Random.Range(x + 5f, x + 15f);
            }
            else
            {
                newX = UnityEngine.Random.Range(x - 5f, x - 15f);
            }

            if (UnityEngine.Random.Range(0, 2) == 0)
            {
                newY = UnityEngine.Random.Range(y + 5f, y + 15f);
            }
            else
            {
                newY = UnityEngine.Random.Range(y - 5f, y - 15f);
            }
            randomTarget = new Vector2(newX, newY);

            Vector2 direction = randomTarget - (Vector2)transform.position;
            Vector2 dir = targets[0].transform.position - transform.position;

            RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, Mathf.Infinity);
            if (hit.collider != null && hit.collider.CompareTag("Player"))
            {
                action = "Chase Player";
            }

            Vector2 targetVelocity = direction.normalized * speed;
            rb.velocity = Vector2.Lerp(rb.velocity, targetVelocity, Time.deltaTime * 5f);
        }
    }



    public void ChasePlayer()
    {
        gameObject.GetComponent<Renderer>().enabled = true;
        gameObject.GetComponent<EnemyDamageExample>().enabled = true;
        Collider2D hitboxCollider = GetHitboxCollider();
        if (hitboxCollider != null)
        {
            hitboxCollider.enabled = true;
        }
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Player");
        if (targets.Length > 0)
        {
            Vector2 direction = targets[0].transform.position - transform.position;
            rb.velocity = (Vector3.Normalize(direction) * speed);
        }
    }

    public void RunawayPlayer()
    {
        gameObject.GetComponent<Renderer>().enabled = false;

        EnemyDamageExample damageComponent = gameObject.GetComponent<EnemyDamageExample>();
        if (damageComponent != null)
        {
            damageComponent.enabled = false;
        }

        Collider2D hitboxCollider = GetHitboxCollider();
        if (hitboxCollider != null)
        {
            hitboxCollider.enabled = false;
        }

        GameObject[] targets = GameObject.FindGameObjectsWithTag("Player");
        if (targets.Length > 0)
        {
            Vector2 direction = targets[0].transform.position - transform.position;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, Mathf.Infinity);

            if (timeWhenWeNextDoSomething <= Time.time)
            {
                if (hit.collider != null && hit.collider.CompareTag("Player"))
                {
                    action = "Chase Player";
                }
                else if ((hit.collider != null && !hit.collider.CompareTag("Player")) || hit.collider == null)
                {
                    action = "Chase Player";
                }
            }

            float distance = Vector2.Distance(targets[0].transform.position, transform.position);

            rb.velocity = (Vector3.Normalize(-direction) * (speed / (distance / speedOffset)));
        }
    }

    private Collider2D GetHitboxCollider()
    {
        Collider2D[] colliders = GetComponents<Collider2D>();
        foreach (Collider2D collider in colliders)
        {
            if (collider.isTrigger)
            {
                return collider;
            }
        }
        return null;
    }


}
