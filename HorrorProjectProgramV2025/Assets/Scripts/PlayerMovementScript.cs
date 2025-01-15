using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    public float speed;
    public float spaceBetweenPlayerAndFlashlight;

    public GameObject conePivot;
    public GameObject lightPivot;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2();

        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = new Vector2(0, 1) * speed;
            anim.Play("NGuardWalkAnim");
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = new Vector2(0, -1) * speed;
            anim.Play("NGuardWalkAnim");
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(1, 0) * speed;
            anim.Play("NGuardWalkAnim");

            conePivot.transform.position = new Vector3((transform.position.x + spaceBetweenPlayerAndFlashlight), transform.position.y, 1);
            lightPivot.transform.position = new Vector3((transform.position.x + spaceBetweenPlayerAndFlashlight), transform.position.y, 1);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-1, 0) * speed;
            anim.Play("NGuardLeftWalkAnim");

            conePivot.transform.position = new Vector3((transform.position.x - spaceBetweenPlayerAndFlashlight), transform.position.y, 1);
            lightPivot.transform.position = new Vector3((transform.position.x - spaceBetweenPlayerAndFlashlight), transform.position.y, 1);
        }

        if (rb.velocity == new Vector2())
        {
            anim.Play("NGuardIdleAnim");

            conePivot.transform.position = new Vector3((transform.position.x + 0.6f), transform.position.y, 1);
            lightPivot.transform.position = new Vector3((transform.position.x + 0.6f), transform.position.y, 1);

            lightPivot.transform.rotation = new Quaternion(0, 0, 0.70711f, -0.70711f);
        }

    }
}
