using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogInUI : MonoBehaviour {

    private GameObject keyboardObj;

    // Initialize   
    private void Awake() {
        keyboardObj = GameObject.Find("KeyboardCanvas");
        keyboardObj.GetComponent<Canvas>().enabled = false;
    }

    // Nickname input button click event.   
    public void NickNameButtonClick() {

        for (int count = 0; count < keyboardObj.GetComponentsInChildren<ButtonKey>().Length; count++)
            keyboardObj.GetComponentsInChildren<ButtonKey>()[count].setTargetTextObject(GameObject.Find("NicknameText"));

        Canvas temp = keyboardObj.GetComponent<Canvas>();

        if (temp.enabled == false)
            temp.enabled = true;

        else temp.enabled = false;
    }
}
