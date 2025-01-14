using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneTimer : MonoBehaviour
{
    public float cutsceneDuration = 10f;  // Duration of the cutscene in seconds
    public string gameSceneName = "GameScene"; // The scene to load after the cutscene ends
    private bool hasCutsceneStarted = false;
    private float timer;

    void Start()
    {
        timer = cutsceneDuration;
    }

    void Update()
    {
        // Wait for the start button press (replace "Space" with your input if needed)
        if (!hasCutsceneStarted && Input.GetKeyDown(KeyCode.Space)) // You can change this to any key or button
        {
            StartCutscene();
        }

        if (hasCutsceneStarted)
        {
            // Countdown the timer while the cutscene is playing
            timer -= Time.deltaTime;

            // If the timer reaches zero, transition to the game scene
            if (timer <= 0f)
            {
                LoadGameScene();
            }
        }
    }

    void StartCutscene()
    {
        hasCutsceneStarted = true;
    }

    void LoadGameScene()
    {
        // Load the next scene after the cutscene ends
        SceneManager.LoadScene(gameSceneName);
    }
}
