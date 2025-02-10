using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitScript : MonoBehaviour
{
    bool isOn = false;
    public GameObject exitCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isOn && Input.GetKeyDown(KeyCode.E) && HeartScript.hasPlayed)
        {
            Debug.Log("Quitting");
            Application.Quit();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isOn = true;
        }

        if (isOn == true && HeartScript.hasPlayed)
        {
            exitCanvas = GameObject.Find("UI Canvas").transform.GetChild(2).gameObject;
            exitCanvas.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (isOn == true && collision.CompareTag("Player"))
        {
            exitCanvas = GameObject.Find("UI Canvas").transform.GetChild(2).gameObject;
            exitCanvas.SetActive(false);
            isOn = false;
        }
    }
}
