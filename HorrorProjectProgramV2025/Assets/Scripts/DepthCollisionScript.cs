using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepthCollisionScript : MonoBehaviour
{
    public GameObject depthPivot;

    void Update()
    {
        if (depthPivot != null)
        {
            if (transform.position.y > depthPivot.transform.position.y)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, 2);
            }

            if (transform.position.y < depthPivot.transform.position.y)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, 0);
            }
        }
        else
        {
            depthPivot = GameObject.FindGameObjectWithTag("depthPivot");
        }
    }
}
