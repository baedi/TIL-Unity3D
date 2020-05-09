using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/** MessageManager.cs
 * 
 *  알림과 관련된 정보 출력용.
 *  버튼을 누르면 창이 닫히며, 외부에서 이 스크립트의 메서드를 호출하여 출력함.
**/
public class MessageManager : MonoBehaviour {

    /** 변수 **/
    public GameObject mainManager;      // 메인 매니저              
    public GameObject messageUI;        // 메시지 UI                
    public GameObject messageUI_Text;   // 메시지 UI의 Text         
    public GameObject ok_button;        // 메시지 UI의 Button_OK    

    private Text messageText;


    /** 초기화 **/
    private void Start() {
        // 버튼에 대한 리스너 설정        
        Button button = ok_button.GetComponent<Button>();
        button.onClick.AddListener(buttonClickEvent);                                       // 버튼 클릭 이벤트    
        button.onClick.AddListener(mainManager.GetComponent<SoundManager>().Sound_click);   // 클릭 사운드 재생    

        // 컴포넌트 가져오기              
        messageText = messageUI_Text.GetComponent<Text>();
    }


    /** 버튼 클릭 이벤트 **/
    private void buttonClickEvent() {
        messageUI.SetActive(false);     // 창 비활성화   
    }


    /** 메시지 창 열기 **/
    public void SetMessageAndActive(string message) {
        messageUI.SetActive(true);      // 창 활성화     

        messageText.text = "[알림]\n\n" + message;
    }

}
