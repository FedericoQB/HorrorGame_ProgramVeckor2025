using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2();

        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = new Vector2(0, 1) * speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = new Vector2(0, -1) * speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(1, 0) * speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-1, 0) * speed;
        }

    }
}
