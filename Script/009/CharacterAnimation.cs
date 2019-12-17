using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour {

    private Rigidbody rigidbody;
    private Control control;
    private Animator animator;          // Animator 컴포넌트 변수 
    private float horizontal = 0.0f;    // 좌, 우측 움직임 용도   
    private float vertical = 0.0f;      // 전진, 후진 움직임 용도 
    private float jump = 0.0f;

    // 초기화          
    void Start() {

        rigidbody = GetComponentInParent<Rigidbody>();  // 부모로부터 Rigidbody 컴포넌트를 가져옴  
        control = GetComponentInParent<Control>();      // 부모로부터 Control 스크립트를 가져옴    

        // Animator 컴포넌트를 가져옴.          
        animator = GetComponent<Animator>();

        // (만약 이 스크립트를 ControlCube에 넣었을 경우 아래 코드를 사용해야됨.)   
        //animator = GetComponentInChildren<Animator>();
    }

    // 갱신           
    void Update() {

        horizontal = Input.GetAxis("Horizontal");   
        vertical = Input.GetAxis("Vertical");
        jump = rigidbody.velocity.normalized.y;     // 점프 상태를 가져옴.  

        Debug.Log(rigidbody.velocity.normalized.y + " " + vertical);

        // 점프 중인 상태         
        if (control.getIsJumpEnable()) {
            animator.SetBool("isJump", true);
            animator.SetBool("isWalk", false);
            animator.SetBool("isBackWalk", false);
        }

        // 점프가 아닌 중인 상태 
        else {
            animator.SetBool("isJump", false);

            // 전진 달리기               
            if (Input.GetKey(KeyCode.W))
            {
                animator.SetBool("isWalk", true);
                animator.SetBool("isBackWalk", false);
            }

            // 뒤로 달리기               
            else if (Input.GetKey(KeyCode.S))
            {
                animator.SetBool("isWalk", false);
                animator.SetBool("isBackWalk", true);
            }

            // 가만히 있는 상태          
            else
            {
                animator.SetBool("isWalk", false);
                animator.SetBool("isBackWalk", false);
            }
        }
    }
}
