using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccControl : MonoBehaviour {

    // 변수            
    private const int _MAX_VALUE = 50;          // 최대 
    private const int _MIN_VALUE = 3;           // 최소 
    private new Rigidbody rigidbody;

    private int moveLevel = _MIN_VALUE;         // 이동 속도 계산용  (초기값 : _MIN_VALUE)  
    private float vertical;                     // ?        
    private bool isJumpEnable;                  // 점프 가능 여부                           

    public float runSpeed = 0.1f;               // 이동 속도           
    public float jumpPower = 5f;                // 점프력              



    // 초기화          
    void Start() {
        StartCoroutine(speedManager());

        rigidbody = GetComponent<Rigidbody>();  // 이 스크립트를 적용한 오브젝트의 Rigidbody 컴포넌트를 가져옴.    
        rigidbody.freezeRotation = true;        // 캐릭터의 회전축이 기울어지는 문제를 방지하기 위함.              
        isJumpEnable = true;                    // 점프 가능하도록 설정      
    }

    // 반복문          
    void Update() {
        vertical = Input.GetAxis("Vertical");

        // 방향키 관련 동작        
        if (Input.GetKey(KeyCode.W))        transform.Translate(0, 0, runSpeed * Mathf.Log10((float)moveLevel));   // 전진   
        else if (Input.GetKey(KeyCode.S))   transform.Translate(0, 0, -runSpeed * Mathf.Log10((float)_MIN_VALUE)); // 후진   
        if (Input.GetKey(KeyCode.A))        transform.Translate(-runSpeed * Mathf.Log10((float)_MIN_VALUE), 0, 0); // 좌측   
        else if (Input.GetKey(KeyCode.D))   transform.Translate(runSpeed * Mathf.Log10((float)_MIN_VALUE), 0, 0);  // 우측   

        if (Input.GetKeyDown(KeyCode.Space) && isJumpEnable) 
            rigidbody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        
    }


    private IEnumerator speedManager() {
        while (true) {

            // 상태 표시            
            Debug.Log("SP : " + moveLevel);

            // 전진 중일 경우 속도를 위한 값을 조금씩 증가함.  
            if (Input.GetKey(KeyCode.W) && moveLevel < _MAX_VALUE + 1) {
                moveLevel++;
                yield return new WaitForSeconds(0.2f - (moveLevel * 0.003f));
            }

            // 전진 중이 아닐 경우 속도를 위한 값을 감소함.   
            else if (!Input.GetKey(KeyCode.W) && moveLevel > _MIN_VALUE) {
                moveLevel -= 2;
                yield return null;
            }

            else yield return new WaitForSeconds(0.5f);

            yield return null;
        }
    }


    // Ground 물체와 충돌할 경우 점프 활성화     
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("MoveGround"))
            isJumpEnable = true;
    }

    private void OnCollisionExit(Collision collision) {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("MoveGround"))
            isJumpEnable = false;
    }
}
