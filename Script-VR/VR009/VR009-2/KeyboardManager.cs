using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

// VR 키보드 관리 스크립트               
/**
 * KeyboardManager 라는 빈 오브젝트를 만든 뒤 KeyboardCanvas 프리팹을 자식 오브젝트로 삼고, 
 * 이 스크립트를 적용하면 됨.
 **/
public class KeyboardManager : MonoBehaviour {

    // 변수               
    private GameObject targetInputButton;
    private GameObject keyboardPrefab;
    private string[] textBigSet;
    private string[] textSmallSet;
    private const int KEY_LENGTH = 39;

    public GameObject[] keys = new GameObject[KEY_LENGTH];


    // 초기화             
    private void Start() {

        // 키 텍스트 초기화                
        textBigSet = new string[KEY_LENGTH]{ "Q", "W", "E", "R", "T", "Y", "U", "I", "O", "P",
                                     "A", "S", "D", "F", "G", "H", "J", "K", "L",
                                     "Z", "X", "C", "V", "B", "N", "M",
                                    "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "←", "▲", "Close"};

        textSmallSet = new string[KEY_LENGTH]{ "q", "w", "e", "r", "t", "y", "u", "i", "o", "p",
                                     "a", "s", "d", "f", "g", "h", "j", "k", "l",
                                     "z", "x", "c", "v", "b", "n", "m",
                                    "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "←", "▽", "Close"};


        // 모든 키 버튼 초기화              
        for (int index = 0; index < keys.Length; index++) {
            KeySettings temp = keys[index].AddComponent<KeySettings>();
            temp.TextBig = textBigSet[index];
            temp.TextSmall = textSmallSet[index];
            temp.KeyInitialize();
        }


        // 0번 인덱스에 속한 자식 오브젝트(키보드 프리팹)을 가져옴.  
        keyboardPrefab = transform.GetChild(0).gameObject;

        // 키보드 프리팹을 비활성화시킴                              
        keyboardPrefab.SetActive(false);
    }


    // (이벤트) 외부의 입력 전용 버튼을 클릭할 경우   
    public void OnInputButtonClick() {

        // 누른 버튼의 오브젝트 정보를 가져옴      
        targetInputButton = EventSystem.current.currentSelectedGameObject;
        Debug.Log("Select : " + targetInputButton);


        // 키보드 활성화시킴                       
        keyboardPrefab.SetActive(true);
    }


    // 키 버튼을 클릭한 경우 (자식 오브젝트에 의해 호출됨)
    public void OnKeyButtonClickInChildren(string text) {

        Text temp_text = targetInputButton.GetComponentInChildren<Text>();


        // ← 문자 : 지우기                       
        if (text.Equals("←")) {
            try {
                temp_text.text = temp_text.text.Remove(temp_text.text.Length - 1);
            }
            catch (ArgumentOutOfRangeException) { }
        }

        // ▲,▽ 문자 : 대문자 or 소문자로 변경   
        else if (text.Equals("▲") || text.Equals("▽")) {
            for (int index = 0; index < keys.Length; index++)
                keys[index].GetComponent<KeySettings>().ChangeKeyText();
        }

        // Close 문자 : 닫기          
        else if (text.Equals("Close"))
            keyboardPrefab.SetActive(false);

        // 기타 : 문자 입력           
        else
            temp_text.text += text;

    }
}
