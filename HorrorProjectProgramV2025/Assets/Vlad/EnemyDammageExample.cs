using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDammageExample : MonoBehaviour
{
    public float DamagePoints = 20f;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (collision.GetComponent<PlayerHealth>().collider == collision)
            collision.GetComponent<PlayerHealth>().damagePlayer(DamagePoints / 100f);
        }
    }
}
