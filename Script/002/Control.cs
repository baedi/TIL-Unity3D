using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour {

    private new Rigidbody rigidbody;    // 중력 관련 컴포넌트   
    private bool isJumpEnable;          // 점프 활성화 여부     
    public float speed = 0.1f;          // 이동 속도            
    public float jump = 0.2f;           // 점프 세기            

    // Start is called before the first frame update
    void Start() {
        isJumpEnable = true;
        
        rigidbody = GetComponent<Rigidbody>();  // 이 스크립트를 적용한 오브젝트의 Rigidbody 컴포넌트를 가져옴.   
        rigidbody.freezeRotation = true;        // 물리적 충돌에 의한 기울기가 변경되지 않도록 함.                
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.W)) transform.Translate(0, 0, speed);      // W키(전진)       
        if (Input.GetKey(KeyCode.A)) transform.Translate(-speed, 0, 0);     // A키(좌측)       
        if (Input.GetKey(KeyCode.S)) transform.Translate(0, 0, -speed);     // S키(후진)       
        if (Input.GetKey(KeyCode.D)) transform.Translate(speed, 0, 0);      // D키(우측)       
        if (Input.GetKey(KeyCode.Space) && !isJumpEnable){                  // SPACE키 (점프)  
            rigidbody.AddForce(Vector3.up * jump, ForceMode.Impulse);           // 점프            
            isJumpEnable = true;                                                // 점프 중인 경우이므로 true로 설정. 
        }
    }

    // Ground 라는 태그를 가진 물체와 충돌 시 점프 상태가 아님을 취함.
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("MoveGround"))
            isJumpEnable = false;
    }

    private void OnCollisionExit(Collision collision) {
        isJumpEnable = true;
    }
}
