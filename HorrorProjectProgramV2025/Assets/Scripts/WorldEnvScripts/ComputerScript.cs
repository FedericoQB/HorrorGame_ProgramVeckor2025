using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ComputerScript : MonoBehaviour
{
    public static bool isOn = false;
    public GameObject computerCanvas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isOn = true;
        }

        if (isOn == true)
        {
            computerCanvas = GameObject.Find("UI Canvas").transform.GetChild(1).gameObject;
            computerCanvas.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (isOn == true && collision.CompareTag("Player"))
        {
            computerCanvas = GameObject.Find("UI Canvas").transform.GetChild(1).gameObject;
            computerCanvas.SetActive(false);
            isOn = false;
        }
    }
}
