using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{


   public void NewGameLoad()
    {
        Debug.Log("Click");
        SceneManager.LoadScene("Cutscene");
    }


    /*

    public string preloadSceneName = "Game"; // Name of the scene to preload
    public string targetSceneName = "Cutscene"; // Name of the scene to load

    private AsyncOperation preloadOperation;

    private void Start()
    {
        Debug.Log(preloadSceneName);
        Debug.Log(targetSceneName);

        // Preload the scene asynchronously
        preloadOperation = SceneManager.LoadSceneAsync("Game");
        preloadOperation.allowSceneActivation = false; // Don't immediately activate the preloaded scene
    }

    public void LoadTargetScene()
    {
        // Start loading the target scene asynchronously
        StartCoroutine(LoadTargetSceneAsync());
    }

    private IEnumerator LoadTargetSceneAsync()
    {
        yield return null; // Wait for a frame to avoid glitches

        // Activate the preloaded scene
        preloadOperation.allowSceneActivation = true;

        // Load the target scene asynchronously
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(targetSceneName);

        // Wait until the target scene is fully loaded
        while (!asyncLoad.isDone)
        {
            // You can display loading progress here if needed
            float progress = Mathf.Clamp01(asyncLoad.progress / 0.9f);
            Debug.Log("Loading progress: " + (progress * 100) + "%");

            yield return null;
        }
    }
    */
}
