using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class EnemyDamageExample : MonoBehaviour
{
    public float DamagePoints = 20f;
    public float timeBetweenDoingSomething = 5f;
    public float timeWhenWeNextDoSomething;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();

            if (playerHealth != null && playerHealth.playerBoxCollider2D == collision)
            {
                playerHealth.damagePlayer(DamagePoints / 100f);
                timeWhenWeNextDoSomething = Time.time + timeBetweenDoingSomething;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
            if (timeWhenWeNextDoSomething <= Time.time)
            {
                timeWhenWeNextDoSomething = Time.time + timeBetweenDoingSomething;
                playerHealth.damagePlayer(DamagePoints / 100f);
            }
        }
    }
}
