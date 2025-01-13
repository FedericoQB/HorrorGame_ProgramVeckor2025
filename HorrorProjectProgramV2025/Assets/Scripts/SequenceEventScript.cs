using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceEventScript : MonoBehaviour
{
    bool isTriggered = false;

    public GameObject lightSources;

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
        if (collision.gameObject.tag == "Player" && isTriggered == false)
        {
            isTriggered = true;
            lightSources.SetActive(false);
        }
    }
}
