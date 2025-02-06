using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class danceLightScript : MonoBehaviour
{
    public Light2D light;
    bool playerIsNear = false;
    int colorNumber = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerIsNear == true && Input.GetKeyDown(KeyCode.E))
        {
            if (colorNumber == 1)
            {
                light.color = Color.red;
                colorNumber++;
            }
            else if (colorNumber == 2)
            {
                light.color = Color.blue;
                colorNumber++;
            }
            else if (colorNumber == 3)
            {
                light.color = Color.yellow;
                colorNumber = 1;
            }
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerIsNear = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerIsNear = false;
        }
    }
}
