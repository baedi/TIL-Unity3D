using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Auth;


public class FirebaseLoginManager : MonoBehaviour {

    // 변수            
    private Button signButton;
    private Text logText;
    private InputField id_field;
    private InputField pass_field;
    private static FirebaseApp firebaseApp;
    private static FirebaseAuth firebaseAuth;
    private static FirebaseUser user;

    
    // 프로퍼티        
    public bool IsFirebaseReady { get; private set; }
    public bool IsSignInOnProgress { get; private set; }

    // 초기화          
    private void Awake () {

        // 텍스트 컴포넌트 가져옴                       
        logText = GameObject.Find("LogText").GetComponent<Text>();
        logText.text = "Ready...";

        // 버튼 컴포넌트 가져온 후 버튼 비활성화        
        signButton = GameObject.Find("SignButton").GetComponent<Button>();
        signButton.interactable = false;

        // 파이어베이스 연결 여부 확인                  
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(continuationAction: task => {
            var result = task.Result;
            logText.text = "Connecting...";

            // 이용가능한 상태가 아닌 경우      
            if(result != DependencyStatus.Available) {
                IsFirebaseReady = false;
                logText.text = "Connection false";
            }

            else {
                IsFirebaseReady = true;
                firebaseApp = FirebaseApp.DefaultInstance;
                firebaseAuth = FirebaseAuth.DefaultInstance;

                logText.text = "Connection OK";
            }

            // IsFirebaseReady가 어떤 값을 반환하느냐에 따라 활성화 여부가 결정됨.    
            signButton.interactable = IsFirebaseReady;
        });
    }


    // 버튼 누를 시 이벤트 처리 함수        
    public void signButtonClick() {
        Application.Quit();
    }
}
