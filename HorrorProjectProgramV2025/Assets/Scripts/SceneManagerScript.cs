using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class CutsceneManager : MonoBehaviour
{
    public VideoPlayer videoPlayer;  // The VideoPlayer component
    public string gameSceneName;    // Name of the scene to load after the cutscene

    private bool cutsceneStarted = false;

    // Call this function when the Start button is pressed
    public void PlayCutsceneAndStartGame()
    {
        if (cutsceneStarted) return; // Prevent double triggers
        cutsceneStarted = true;

        if (videoPlayer != null)
        {
            videoPlayer.Play();
            StartCoroutine(WaitForCutsceneToEnd());
        }
        else
        {
            Debug.LogError("VideoPlayer not assigned!");
        }
    }

    private IEnumerator WaitForCutsceneToEnd()
    {
        // Wait until the video finishes playing
        while (videoPlayer.isPlaying)
        {
            yield return null;
        }

        // Load the main game scene
        SceneManager.LoadScene(gameSceneName);
    }

    void EndApplication()
    {
        Application.Quit();
    }
}
