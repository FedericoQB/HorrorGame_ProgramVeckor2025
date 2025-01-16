using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EnemyMovementScript : MonoBehaviour
{
    Rigidbody2D rb;
    GameObject targetObject;
    public float speed;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        targetObject = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        Vector2 direction = targetObject.transform.position - transform.position;

        rb.velocity = (Vector3.Normalize(direction) * speed);
    }
}
