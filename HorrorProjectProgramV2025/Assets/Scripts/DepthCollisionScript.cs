using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepthCollisionScript : MonoBehaviour
{
    public GameObject depthPivot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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
}
