using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneTimer : MonoBehaviour
{
    public float cutsceneDuration = 10f; // Duration of the cutscene in seconds
    public string gameSceneName = "GameScene"; // Name of the game scene to load

    private bool isCutscenePlaying = false;
    private float timer;

    void Start()
    {
        timer = cutsceneDuration;
    }

    void Update()
    {
        // Start cutscene when the space key is pressed
        if (!isCutscenePlaying && Input.GetKeyDown(KeyCode.Space))
        {
            StartCutscene();
        }

        // Countdown and check if the cutscene timer has expired
        if (isCutscenePlaying)
        {
            timer -= Time.deltaTime;

            if (timer <= 0f)
            {
                LoadGameScene();
            }
        }
    }

    void StartCutscene()
    {
        isCutscenePlaying = true;
        Debug.Log("Cutscene started. Timer: " + cutsceneDuration);
    }

    void LoadGameScene()
    {
        Debug.Log("Cutscene ended. Loading game scene...");
        SceneManager.LoadScene(gameSceneName);
    }
}
