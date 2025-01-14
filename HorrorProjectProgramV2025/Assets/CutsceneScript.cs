using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoCutsceneManager : MonoBehaviour
{
    public VideoPlayer videoPlayer; // Reference to the Video Player component
    public string gameSceneName;   // Name or index of the game scene

    void Start()
    {
        if (videoPlayer != null)
        {
            // Subscribe to the video end event
            videoPlayer.loopPointReached += OnVideoFinished;

            // Play the video
            videoPlayer.Play();
        }
        else
        {
            Debug.LogError("VideoPlayer is not assigned!");
        }
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        // Unsubscribe to avoid multiple calls
        vp.loopPointReached -= OnVideoFinished;

        // Load the next scene
        SceneManager.LoadScene(gameSceneName);
    }
}
