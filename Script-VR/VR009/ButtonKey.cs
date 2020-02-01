using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonKey : MonoBehaviour {

    public string key_big;
    public string key_small;

    private bool isKeyBigMode;
    private Text targetTextObject;


    // Initialize                       
    private void Awake() {
        isKeyBigMode = false;
        GetComponentInChildren<Text>().text = key_small;

        this.GetComponent<Button>().onClick.AddListener(keyClick);
    }

    // Target Text Component Settings.  
    public void setTargetTextObject(GameObject temp) {
        targetTextObject = temp.GetComponent<Text>();
    }


    // Keyboard click event.            
    public void keyClick() {

        // Remove String. (last index)  
        if (key_big.Equals("←")) {
            try { targetTextObject.text = targetTextObject.text.Remove(targetTextObject.text.Length - 1); }
            catch (System.ArgumentOutOfRangeException) { }
            
        }

        // Input String. (last index)   
        else if (!isKeyBigMode) targetTextObject.text += key_small;
        else targetTextObject.text += key_big;
    }
}
