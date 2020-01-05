using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlScreen : MonoBehaviour {

    // 변수                   
    private Text textObject;
    private bool touchpadClick;     // 터치패드 클릭 여부         
    private bool buttonOne;
    private bool touchpadTouch;     // 터치패드 터치 여부         
    private bool touchOne;
    private bool buttonTrigger;     // 트리거 버튼 클릭 여부      
    private bool buttonBack;        // 뒤로가기 버튼 클릭 여부    
    private bool buttonBack2;

    // 초기화                 
    void Start() {
        textObject = GetComponent<Text>();
    }

    // 반복                   
    private void Update() {

        // 터치패드 클릭 여부 확인        
        if (OVRInput.Get(OVRInput.Button.PrimaryTouchpad)) touchpadClick = true;
        else touchpadClick = false;

        if (OVRInput.Get(OVRInput.Button.One)) buttonOne = true;
        else buttonOne = false;

        // 터치패드 터치 여부 확인        
        if (OVRInput.Get(OVRInput.Touch.PrimaryTouchpad)) touchpadTouch = true;
        else touchpadTouch = false;

        if (OVRInput.Get(OVRInput.Touch.One)) touchOne = true;
        else touchOne = false;

        // 트리거 버튼 클릭 여부 확인      
        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger)) buttonTrigger = true;
        else buttonTrigger = false;

        // 뒤로가기 버튼 클릭 여부 확인     
        if (OVRInput.GetDown(OVRInput.Button.Back)) buttonBack = !buttonBack;
        if (OVRInput.GetDown(OVRInput.Button.Two)) buttonBack2 = !buttonBack2;


        // 텍스트 출력                      
        textObject.text = "touchpadClick = " + touchpadClick + "\n" +
                            "buttonOne = " + buttonOne + "\n" +
                            "touchpadTouch = " + touchpadTouch + "\n" +
                            "touchOne = " + touchOne + "\n" +
                            "buttonTrigger = " + buttonTrigger + "\n" +
                            "buttonBack = " + buttonBack + "\n" +
                            "buttonBack2 = " + buttonBack2 + "\n" +
                            "TouchpadVector = " + OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad, OVRInput.Controller.RTrackedRemote);

    }

}

