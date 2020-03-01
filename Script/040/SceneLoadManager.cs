using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// 로딩 씬 전용 스크립트         
/**
 * 파괴 불가능한 오브젝트 전용
 * NextSceneInfo로부터 씬 정보를 가져온 뒤 로드함.
 **/
public class SceneLoadManager : MonoBehaviour {

    // 변수               
    public GameObject loadCanvas;

    private Text loadingText;
    private Slider loadingBar;
    private AsyncOperation async;
    private bool isComplete = false;


    // 초기화              
    private void Start() {

        /** 컴포넌트 가져옴 **/
        loadingText = loadCanvas.GetComponentInChildren<Text>();
        loadingBar = loadCanvas.GetComponentInChildren<Slider>();

        /** 불러올 씬 이름을 가져온 뒤 로드함 **/
        string loadSceneName = GameObject.Find("SceneManager").GetComponent<NextSceneInfo>().NextSceneName;
        async = SceneManager.LoadSceneAsync(loadSceneName);

        /** 로딩이 끝나면 자동으로 불러오지 않도록 설정함 **/
        async.allowSceneActivation = false;

        StartCoroutine(LoadingProcessManager());
        StartCoroutine(ProgressLerp());
    }

    // (코루틴) 불러올 씬의 로드를 확인하기 위한 함수         
    private IEnumerator LoadingProcessManager() {

        while (true) {
            loadingText.text = $"로딩 중... ({(int)(async.progress * 100)}%)";

            /** 90%에 도달할 경우 일정 시간 지연 후 반복문 탈출 **/
            if(async.progress >= 0.9f) {
                yield return new WaitForSeconds(1.5f);
                break;
            }

            yield return new WaitForSeconds(0.1f);
        }

        isComplete = true;
        loadingText.text = "불러오는 중...";

        yield return new WaitForSeconds(1f);
        async.allowSceneActivation = true;

        yield return null;
    }


    // (코루틴) 로딩 바의 흐름을 부드럽게 연출하기 위한 함수  
    private IEnumerator ProgressLerp() {

        while (!async.isDone) {

            /** 부드러운 로딩 바 연출 **/
            loadingBar.value = Mathf.Lerp(loadingBar.value, isComplete ? 1f : async.progress, 
                                            4f * Time.deltaTime);

            if (loadingBar.value == 1f) break;

            yield return null;
        }

        yield return null;
    }
}
