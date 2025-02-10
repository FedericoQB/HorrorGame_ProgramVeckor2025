using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyPersistentObjectsScript : MonoBehaviour
{
    public static DestroyPersistentObjectsScript Instance;

    private List<GameObject> dontDestroyObjects = new List<GameObject>();
    public string targetSceneName;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void RegisterDontDestroyObject(GameObject obj)
    {
        if (!dontDestroyObjects.Contains(obj))
        {
            dontDestroyObjects.Add(obj);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == targetSceneName)
        {
            DestroyAllTrackedObjects();
        }
    }

    private void DestroyAllTrackedObjects()
    {
        foreach (GameObject obj in dontDestroyObjects)
        {
            if (obj != null)
            {
                Destroy(obj);
            }
        }
        dontDestroyObjects.Clear();
    }
}
