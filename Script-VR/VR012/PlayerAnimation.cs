using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerAnimation : MonoBehaviourPunCallbacks {

    // 변수                
    private Animator animator;
    public float detect_touchAxis = 0.5f;

    // 초기화              
    private void Start() {
        animator = GetComponent<Animator>();
    }

    // 루프                
    private void Update() {

        /** 자신이 컨트롤하는 오브젝트가 아니면 리턴 **/
        if (!photonView.IsMine) return;

        /** VR 컨트롤러 터치 정보를 가져옴 **/
        Vector2 touchVector = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad, OVRInput.Controller.RTrackedRemote);


        /** 앞으로 이동 **/
        if (Input.GetKey(KeyCode.W) || touchVector.y >= detect_touchAxis) {
            animator.SetBool("isWalking", true);
            animator.SetBool("isForward", true);
            animator.SetBool("isBackward", false);
        }

        /** 뒤로 이동 **/
        else if (Input.GetKey(KeyCode.S) || touchVector.y <= -detect_touchAxis) {
            animator.SetBool("isWalking", true);
            animator.SetBool("isForward", false);
            animator.SetBool("isBackward", true);
        }

        else animator.SetBool("isWalking", false);

    }
}
