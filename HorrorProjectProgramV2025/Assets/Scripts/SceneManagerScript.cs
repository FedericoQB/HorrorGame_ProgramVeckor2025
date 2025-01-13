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
        // Start the cutscene
        cutsceneDirector.Play();

        // Start a coroutine to wait for the cutscene to finish and then load the next scene
        StartCoroutine(WaitForCutsceneToFinish());
    }

    // Coroutine that waits for the cutscene to finish before loading the game scene
    IEnumerator WaitForCutsceneToFinish()
    {
        // Wait for the cutscene to finish (based on the duration of the cutscene)
        yield return new WaitForSeconds((float)cutsceneDirector.duration);

        // After the cutscene ends, load the game scene (Scene index 1 in this case)
        SceneManager.LoadScene(1);
    }

    // Method to exit the application
    public void EndApplication()
    {
        // Quit the application (works in built game, not in editor)
        Application.Quit();
    }
}
