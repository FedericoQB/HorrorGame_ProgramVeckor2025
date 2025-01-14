using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;  // For Timeline control

public class SceneManagerScript : MonoBehaviour
{
    public PlayableDirector cutsceneDirector;  // Reference to the PlayableDirector that controls the cutscene timeline

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // Method to start the game, plays the cutscene first
    public void StartGame()
    {
    
        SceneManager.LoadScene(1);
    }

    public void EndApplication()
    {
        // Quit the application (works in built game, not in editor)
        Application.Quit();
    }
}
