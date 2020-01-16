using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_old : MonoBehaviour {

    // 변수            
    private new Rigidbody rigidbody;        // 리지드바디    
    private float power = 3000;             // 발사 파워     

    // 초기화          
    void Start() {
        // 이 스크립트를 적용한 오브젝트의 리지드바디 컴포넌트 가져오기      
        rigidbody = GetComponent<Rigidbody>();

        // 이 오브젝트를 전방으로 power수치만큼 발사함.                      
        rigidbody.AddForce(transform.forward * power);
    }

}
