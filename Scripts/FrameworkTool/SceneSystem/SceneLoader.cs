using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ERMM.FrameworkTool.SceneSystem
{
    public class SceneLoader : MonoBehaviour
    {
        public GameObject loadingScreen; // Reference to the loading screen GameObject
        public Slider progressBar;       // Reference to the slider UI element
        public TextMeshProUGUI progressText;        // Reference to the text UI element displaying load percentage

        public UnityEvent onBeforeLoadNewScene;
        public UnityEvent onAfterLoadNewScene;

        // Method to be called from anywhere to start loading a scene
        public void LoadScene(string sceneName)
        {
            HandleBeforeLoadNewScene();
            StartCoroutine(LoadSceneAsync(sceneName));
        }

        private IEnumerator LoadSceneAsync(string sceneName)
        {
            // Activate the loading screen
            loadingScreen.SetActive(true);

            // Start loading the scene asynchronously and output the progress to the progress bar and text
            AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

            while (!operation.isDone)
            {
                // Get progress value and display it in the UI. 
                // Note: operation.progress will only go up to 0.9 when the scene is fully loaded, because it waits for activation.
                float progress = Mathf.Clamp01(operation.progress / 0.9f);
                progressBar.value = progress;
                progressText.text = (int)(progress * 100f) + "%";

                // Return control to the runtime until the next frame
                yield return null;
            }

            // Once the load is finished, deactivate the loading screen
            loadingScreen.SetActive(false);
            HandleAfterLoadNewScene();
        }

        void HandleBeforeLoadNewScene()
        {
            onBeforeLoadNewScene?.Invoke();
        }

        void HandleAfterLoadNewScene()
        {
            onAfterLoadNewScene?.Invoke();
        }
    }
}
