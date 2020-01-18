using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRLookingControlMove : MonoBehaviour {

    // 변수        
    private Transform centerEyeAnchorTransform;     // VR 중앙 시야 Transform    

    public float moveSpeed = 2f;                    // 이동속도                  


    // 초기화      
    private void Start() {
        centerEyeAnchorTransform = GameObject.Find("CenterEyeAnchor").GetComponent<Transform>();
    }


    // 루프        
    private void Update() {
        // 트리거 버튼을 누를 경우        
        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) || Input.GetKey(KeyCode.W))
            transform.Translate(centerEyeAnchorTransform.forward * moveSpeed * Time.deltaTime);

        
    }
}
