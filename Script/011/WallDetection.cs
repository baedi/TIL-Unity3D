using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDetection : MonoBehaviour {
    private AccControl acccontrol;

    private float xPos;     // 충돌 지점 x축        
    private float yPos;     // 충돌 지점 y축        
    private float zPos;     // 충돌 지점 z축        
    private float speed;    // 플레이어 원래 속도   

    // 초기화                          
    void Start() {
        acccontrol = GetComponent<AccControl>();    // AccControl(사용자 정의 클래스) 컴포넌트 가져옴. 
        speed = acccontrol.getRunSpeed();
    }


    // 벽에 붙는 순간 속도 감소 및 스피드 레벨 초기화                  
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Wall")) {

            // 충돌 좌표 지점 출력                  
            Debug.Log(collision.impulse);

            // 플레이어의 현재 위치값을 저장, 출력  
            xPos = transform.position.x;
            yPos = transform.position.y;
            zPos = transform.position.z;

            Debug.Log(xPos + " " + yPos + " " + zPos);
            transform.position = new Vector3(xPos, yPos, zPos);

            acccontrol.setRunSpeed(0.01f);
            acccontrol.setRunLevel(0);

            //rigidbody.AddForce(collision.impulse * (5), ForceMode.Impulse);
        }
    }

    // 벽에 붙어있는 동안 벽의 어느 방향에서 충돌이 감지되었는지 확인  
    private void OnCollisionStay(Collision collision) {
        /*
        if (collision.gameObject.CompareTag("Wall")) {
            if (collision.impulse.x > 0)        Debug.Log("Impluse X");
            else if (collision.impulse.y > 0)   Debug.Log("Impluse Y");
            else if (collision.impulse.z > 0)   Debug.Log("Impluse Z");
            else if (collision.impulse.x < 0)   Debug.Log("Impluse -X");
            else if (collision.impulse.y < 0)   Debug.Log("Impluse -Y");
            else if (collision.impulse.z < 0)   Debug.Log("Impluse -Z");
        }
      */

    }

    // 벽을 빠져나오면 플레이어 속도를 원래대로 복귀함.                
    private void OnCollisionExit(Collision collision) {
        if (collision.gameObject.CompareTag("Wall")) {
            acccontrol.setRunSpeed(speed);
            acccontrol.setRunLevel(acccontrol.getMinLevel());
        }
    }
}
