using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using Unity.VisualScripting;

public class Globalize : MonoBehaviour
{
    public GameObject[] inactiveGameObjects;

    void Start()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("DontDestroy");

        foreach (GameObject dontDestroy in gameObjects)
        {
            DontDestroyOnLoad(dontDestroy);
        }
        DontDestroyOnLoad(GameObject.FindGameObjectWithTag("Player"));
        foreach (GameObject dontDestroy in inactiveGameObjects)
        {
            DontDestroyOnLoad(dontDestroy);
        }

        SceneManager.LoadScene(3);
    }
}
