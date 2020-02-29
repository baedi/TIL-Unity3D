using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// 씬 정보를 초기화, 불러오기에 사용하는 스크립트.
/**
 * 파괴 불가능한 오브젝트 전용
 * 전용 오브젝트 이름 : SceneManager
 **/
public class NextSceneInfo : MonoBehaviour {

    // 프로퍼티        
    public string NextSceneName { get; set; } = "MainScene";


    // 초기화          
    /** 앱 실행 시 딱 1번 실행됨. **/
    private void Awake() {

        /** 씬이 바뀌어도 오브젝트가 파괴되지 않도록 함. **/
        DontDestroyOnLoad(this);

        SceneManager.LoadScene("LoadingScene");
    }
}
