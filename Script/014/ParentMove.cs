﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 플레이어나 물체에게 적용시켜주는 스크립트                           
public class ParentMove : MonoBehaviour{

    // 변수           
    public Transform parentTransform;   // (부모 지정) 움직이는 발판의 Transform 객체    

    // 반복문          
    void Update() {
        
    }

    // 한 번 충돌이 감지된 경우 발생함           
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("MoveGround")) {
            parentTransform = collision.transform;  // 해당 오브젝트의 transform을 저장  
            transform.parent = parentTransform;     // 발판 Transform을 부모로 삼는다.   
        }
    }

    // 충돌했던 오브젝트가 접촉을 빠져나올 경우   
    private void OnCollisionExit(Collision collision) {
        if (collision.gameObject.CompareTag("MoveGround")) {
            parentTransform = null;
            transform.parent = null;                // 부모 관계를 해제한다.             
        }
    }
}
