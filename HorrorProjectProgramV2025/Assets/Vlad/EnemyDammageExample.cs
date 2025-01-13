using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageExample : MonoBehaviour
{
    public float DamagePoints = 20f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();

            if (playerHealth != null && playerHealth.playerBoxCollider2D == collision)
            {
                playerHealth.damagePlayer(DamagePoints / 100f);
            }
        }
    }
}
