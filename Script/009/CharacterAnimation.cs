using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour {

    private Animator animator;      // Animator 컴포넌트 변수 

    // 초기화          
    void Start() {

        // Animator 컴포넌트를 가져옴.          
        animator = GetComponent<Animator>();

        // (만약 이 스크립트를 ControlCube에 넣었을 경우 아래 코드를 사용해야됨.)   
        //animator = GetComponentInChildren<Animator>();
    }

    // 갱신           
    void Update() {
        if (Input.GetKey(KeyCode.W)) {
            animator.SetBool("isWalk", true);
            animator.SetBool("isBackWalk", false);
        }

        else if (Input.GetKey(KeyCode.S)) {
            animator.SetBool("isWalk", false);
            animator.SetBool("isBackWalk", true);
        }

        else {
            animator.SetBool("isWalk", false);
            animator.SetBool("isBackWalk", false);
        }
    }
}
