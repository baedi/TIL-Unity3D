using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccControl : MonoBehaviour {

    // 변수            
    private const int _MAX_VALUE = 10;
    private const int _MIN_VALUE = 3;
    private new Rigidbody rigidbody;

    private byte sp_ = (byte)_MIN_VALUE;    // 이동 속도 계산용    
    private float vertical;
    public float runSpeed = 0.1f;           // 이동 속도           



    // 초기화          
    void Start() {
        StartCoroutine(speedManager());

        rigidbody = GetComponent<Rigidbody>();  // 이 스크립트를 적용한 오브젝트의 Rigidbody 컴포넌트를 가져옴.    
        rigidbody.freezeRotation = true;        // 캐릭터의 회전축이 기울어지는 문제를 방지하기 위함.              
    }

    // 반복문          
    void Update() {
        vertical = Input.GetAxis("Vertical");

        // 방향키 관련 동작        
        if (Input.GetKey(KeyCode.W))        transform.Translate(0, 0, runSpeed * Mathf.Log10((float)sp_));  // 전진   
        else if (Input.GetKey(KeyCode.S))   transform.Translate(0, 0, -runSpeed);                           // 후진   
        if (Input.GetKey(KeyCode.A))        transform.Translate(-runSpeed, 0, 0);                           // 좌측   
        else if (Input.GetKey(KeyCode.D))   transform.Translate(runSpeed, 0, 0);                            // 우측   
        
    }


    private IEnumerator speedManager() {
        while (true) {

            // 상태 표시            
            Debug.Log("SP : " + sp_);

            // 전진 중일 경우 속도를 위한 값을 조금씩 증가함.  
            if (Input.GetKey(KeyCode.W) && sp_ < _MAX_VALUE + 1) {
                sp_++;
                yield return new WaitForSeconds(0.2f);
            }

            // 전진 중이 아닐 경우 속도를 위한 값을 감소함.   
            else if (sp_ > _MIN_VALUE) {
                sp_--;
                yield return null;
            }

            else yield return new WaitForSeconds(0.5f);

            yield return null;
        }
    }
}
