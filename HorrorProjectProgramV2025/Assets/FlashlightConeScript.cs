using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightConeScript : MonoBehaviour
{
    public GameObject flashLight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (flashLight.transform.rotation.z == 0)
        {
            transform.rotation = flashLight.transform.rotation;
        }
        if (flashLight.transform.rotation.z == 90)
        {
            transform.rotation = flashLight.transform.rotation;
        }
        if (flashLight.transform.rotation.z == 180)
        {
            transform.rotation = flashLight.transform.rotation;
        }
        if (flashLight.transform.rotation.z == -90)
        {
            transform.rotation = flashLight.transform.rotation;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Debug.Log("Flashed");
        }
    }
}
