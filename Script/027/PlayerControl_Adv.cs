using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl_Adv : MonoBehaviour {

    // 변수        
    private new Rigidbody rigidbody;
    private int curJumpCount;

    public float jumpPower = 100f;
    public int maxJumpCount = 5;
    public float gravity = 10f;


    // 초기화      
    private void Awake() {

        curJumpCount = 0;

        // 컴포넌트 가져오기        
        rigidbody = GetComponent<Rigidbody>();

        rigidbody.freezeRotation = true;
    }

    // 루프        
    private void Update() {
        // 스페이스 키 눌렀을 때 점프 수가 최대 점프수보다 적을 경우    
        if (Input.GetKeyDown(KeyCode.Space) && curJumpCount < maxJumpCount) {
            curJumpCount++;
            rigidbody.AddForce(Vector3.up * jumpPower * Time.deltaTime, ForceMode.Impulse);
        }

        if (Input.GetKey(KeyCode.Space) && rigidbody.velocity.y <= -0.1)
            rigidbody.drag = 10f;

        else if (!Input.GetKey(KeyCode.Space) && rigidbody.velocity.y <= -0.1)
            rigidbody.drag = 0f;
    }

    // 충돌 감지 함수     
    private void OnCollisionEnter(Collision collision) {
        curJumpCount = 0;
        rigidbody.drag = 0f;
    }
}
