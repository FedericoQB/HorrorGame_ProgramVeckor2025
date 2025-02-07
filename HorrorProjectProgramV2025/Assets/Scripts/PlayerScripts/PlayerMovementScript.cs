using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    private string direction;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.Play("NGuardIdleAnim");
    }

    void Update()
    {
        rb.velocity = new Vector2();

        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = new Vector2(0, 1) * speed;
            anim.Play("NGuardBackWalk");
            conePivot.transform.position = transform.position;
            lightPivot.transform.position = transform.position;
            direction = "back";
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = new Vector2(0, -1) * speed;
            anim.Play("NGuardFrontWalkAnim");
            conePivot.transform.position = new Vector3(transform.position.x, transform.position.y, 1);
            lightPivot.transform.position = new Vector3(transform.position.x, transform.position.y, 1);
            direction = "forward";
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(1, 0) * speed;
            anim.Play("NGuardWalkAnim");

            conePivot.transform.position = new Vector3((transform.position.x + spaceBetweenPlayerAndFlashlight), transform.position.y, 1);
            lightPivot.transform.position = new Vector3((transform.position.x + spaceBetweenPlayerAndFlashlight), transform.position.y, 1);
            direction = "right";
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-1, 0) * speed;
            anim.Play("NGuardLeftWalkAnim");

            conePivot.transform.position = new Vector3((transform.position.x - spaceBetweenPlayerAndFlashlight), transform.position.y, 1);
            lightPivot.transform.position = new Vector3((transform.position.x - spaceBetweenPlayerAndFlashlight), transform.position.y, 1);
            direction = "left";
        }

        if (rb.velocity == new Vector2())
        {
            if (direction == "left")
            {
                anim.Play("NGuardIdleLeftAnim");

                conePivot.transform.position = new Vector3((transform.position.x - spaceBetweenPlayerAndFlashlight), transform.position.y, 1);
                lightPivot.transform.position = new Vector3((transform.position.x - spaceBetweenPlayerAndFlashlight), transform.position.y, 1);
            }
            else if (direction == "right")
            {
                anim.Play("NGuardIdleAnim");

                conePivot.transform.position = new Vector3((transform.position.x + spaceBetweenPlayerAndFlashlight), transform.position.y, 1);
                lightPivot.transform.position = new Vector3((transform.position.x + spaceBetweenPlayerAndFlashlight), transform.position.y, 1);
            }
            else if (direction == "back")
            {
                anim.Play("NGuardIdleBackAnim");
                conePivot.transform.position = transform.position;
                lightPivot.transform.position = transform.position;
            }
            else if (direction == "forward")
            {
                anim.Play("NGuardIdleFrontAnim");
                conePivot.transform.position = new Vector3(transform.position.x, transform.position.y, 1);
                lightPivot.transform.position = new Vector3(transform.position.x, transform.position.y, 1);
            }
        }

    }
}
