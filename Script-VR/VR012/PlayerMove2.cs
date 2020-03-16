using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

// 플레이어 이동 컨트롤 스크립트         
/**
 * Player 오브젝트 전용 스크립트
 **/

public class PlayerMove2 : MonoBehaviourPunCallbacks {

    // 변수               
    public float movingSpeed = 1.5f;        /** 이동 속도 **/
    public float rotatingSpeed = 80f;       /** 회전 속도 **/
    public float detect_touchAxis = 0.5f;   /** VR 컨트롤러 버튼 감지용 **/


    // 루프               
    private void Update() {

        /** 자신이 컨트롤하는 오브젝트가 아니면 리턴 **/
        if (!photonView.IsMine) return;

        /** VR 컨트롤러 터치 정보를 가져옴 **/
        Vector2 touchVector = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad, OVRInput.Controller.RTrackedRemote);


        /** 앞으로 이동 **/
        if (Input.GetKey(KeyCode.W) || touchVector.y >= detect_touchAxis)
            transform.Translate(Vector3.forward * movingSpeed * Time.deltaTime);

        /** 뒤로 이동 **/
        else if (Input.GetKey(KeyCode.S) || touchVector.y <= -detect_touchAxis)
            transform.Translate(Vector3.back * movingSpeed * Time.deltaTime);

        /** 좌측으로 회전 **/
        if (Input.GetKey(KeyCode.A) || touchVector.x <= -detect_touchAxis)
            transform.Rotate(Vector3.down * rotatingSpeed * Time.deltaTime);

        /** 우측으로 회전 **/
        else if (Input.GetKey(KeyCode.D) || touchVector.x >= detect_touchAxis)
            transform.Rotate(Vector3.up * rotatingSpeed * Time.deltaTime);
    }
}
