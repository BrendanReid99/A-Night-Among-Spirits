using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneController : MonoBehaviour
{
    //public GameObject cutsceneCamera; // Reference to the camera used for the cutscene
    public float cutsceneDuration = 44f; // Duration of the cutscene in seconds
    public string preloadSceneName; // Name of the scene to preload (e.g., "Scene2")

    private bool cutsceneFinished = false;

    private void Start()
    {
        // Start the cutscene
        StartCutscene();

        // Preload the target scene asynchronously in the background
        StartCoroutine(PreloadTargetSceneAsync());
    }

    private void Update()
    {
        if (cutsceneFinished)
        {
            // Transition to Scene 2 after the cutscene finishes
            SceneManager.LoadScene("Game");
        }
    }

    private void StartCutscene()
    {
        // Play your cutscene animations, camera movements, etc.

        // Invoke the method to mark the cutscene as finished after a certain duration
        Invoke("FinishCutscene", cutsceneDuration);
    }

    private void FinishCutscene()
    {
        // Disable cutscene-related objects or animations
        //cutsceneCamera.SetActive(false);

        // Mark the cutscene as finished
        cutsceneFinished = true;
    }

    private IEnumerator PreloadTargetSceneAsync()
    {
        // Preload the target scene asynchronously in the background
        AsyncOperation preloadOperation = SceneManager.LoadSceneAsync("Game");
        preloadOperation.allowSceneActivation = false;

        // Wait until the target scene is fully preloaded
        while (!preloadOperation.isDone)
        {
            yield return null;
        }
    }
}