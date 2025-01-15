using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class SceneManagerScript : MonoBehaviour
{
    public VideoPlayer videoPlayer; // Reference to the VideoPlayer component
    public string gameSceneName; // Name of the scene to load after the video

    public void StartGame()
    {
        // Start playing the video
        if (videoPlayer != null)
        {
            videoPlayer.Play();
            StartCoroutine(WaitForVideoToEnd());
        }
        else
        {
            Debug.LogError("No VideoPlayer assigned!");
        }
    }

    private IEnumerator WaitForVideoToEnd()
    {
        // Wait until the video finishes playing
        while (videoPlayer.isPlaying)
        {
            yield return null;
        }

        // Load the game scene
        SceneManager.LoadScene(gameSceneName);
    }
}
