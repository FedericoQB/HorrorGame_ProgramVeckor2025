using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayerScript : MonoBehaviour
{
    public float positiveXBarrier;
    public float negativeXBarrier;
    bool isMovable = false;

    public GameObject player;
    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectsWithTag("Player")[0];
        }

        if (player.transform.position.x > negativeXBarrier && player.transform.position.x < positiveXBarrier)
        {
            isMovable = true;
        }
        else if (player.transform.position.x > 0)
        {
            transform.position = new Vector3(positiveXBarrier, 0.3f, -10);
        }
        else if (player.transform.position.x < 0)
        {
            transform.position = new Vector3(negativeXBarrier, 0.3f, -10);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectsWithTag("Player")[0];
        }
        if (isMovable == true)
        {
            transform.position = new Vector3(player.transform.position.x, 0.3f, -10);
        }

        if (player.transform.position.x > positiveXBarrier || player.transform.position.x < negativeXBarrier)
        {
            isMovable = false;
        }

        if (player.transform.position.x > negativeXBarrier && player.transform.position.x < positiveXBarrier)
        {
            isMovable = true;
        }
    }
}
