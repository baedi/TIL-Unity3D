using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingProcess : MonoBehaviour {

    // Var.                 
    private Text loadingText;
    private Slider loadingSlider;       
    private AsyncOperation async;
    private bool isComplete = false;


    // Initialize           
    private void Start() {
        loadingText = GameObject.Find("LoadingText").GetComponent<Text>();
        loadingSlider = GameObject.Find("LoadingBar").GetComponent<Slider>();

        async = SceneManager.LoadSceneAsync("ShootingDefenceProject");
        async.allowSceneActivation = false;
        StartCoroutine(LoadingProcessManager());
        StartCoroutine(ProgressLerp());
    }


    // Coroutine Loop                 
    private IEnumerator LoadingProcessManager() {

        while (true) {
            loadingText.text = "Loading... " + (int)(async.progress * 100) + "%";
                
            if(async.progress >= 0.9f) {
                yield return new WaitForSeconds(1.5f);
                break;
            }

            yield return new WaitForSeconds(0.1f);
        }

        isComplete = true;
        loadingText.text = "Complete!";

        yield return new WaitForSeconds(1f);
        async.allowSceneActivation = true;
    }


    // Progress Lerp Coroutine          
    private IEnumerator ProgressLerp() {
        while (!async.isDone) {
            loadingSlider.value = Mathf.Lerp(loadingSlider.value, isComplete ? 1f : async.progress, 4f * Time.deltaTime);

            if (loadingSlider.value == 1f) break;

            yield return null;
        }

        yield return null;
    }
}

