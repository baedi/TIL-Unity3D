using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 각 키 버튼의 키를 세팅하는 스크립트     
/**
 * 주로 외부 호출용으로 사용되며,
 * KeyboardManager에 의해 초기화됨.
 **/
public class KeySettings : MonoBehaviour {

    // 프로퍼티         
    public string TextSmall{ get; set; }    // 소문자  
    public string TextBig { get; set; }     // 대문자  
    private Text textComp;


    // 키 초기화        
    public void KeyInitialize() {

        // 자식으로부터 Text 컴포넌트 가져옴     
        textComp = GetComponentInChildren<Text>();

        // 초기에는 소문자를 텍스트로 보여줌     
        textComp.text = TextSmall;


        // Button 컴포넌트 가져온 뒤 리스너 설정 
        GetComponent<Button>().onClick.AddListener(OnButtonClick);

    }


    // 버튼 클릭 이벤트    
    public void OnButtonClick() {

        // KeyboardManager 컴포넌트를 가져와서 함수 호출     
        GetComponentInParent<KeyboardManager>().OnKeyButtonClickInChildren(textComp.text);

    }


    // 대 소문자 키 변경   
    public void ChangeKeyText() {

        // 소문자로 설정된 경우 대문자로 변경  
        if (TextSmall.Equals(textComp.text))
            textComp.text = TextBig;

        // 대문자로 설정된 경우 소문자로 변경  
        else if (TextBig.Equals(textComp.text))
            textComp.text = TextSmall;

    }



}
