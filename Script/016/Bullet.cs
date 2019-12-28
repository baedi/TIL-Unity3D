using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    // 변수                   
    private new Rigidbody rigidbody;        // 리지드바디    
    private float power = 3000;             // 발사 파워     
    private int lifeTime = 3;               // 지속 시간     

    private Vector3 startPos;

    // 초기화                  
    void Start() {
        // 발사 지점을 저장함                                                
        startPos = transform.position;

        // 이 스크립트를 적용한 오브젝트의 리지드바디 컴포넌트 가져오기      
        rigidbody = GetComponent<Rigidbody>();

        // 이 오브젝트를 전방으로 power수치만큼 발사함.                      
        rigidbody.AddForce(transform.forward * power);

        // 타이머 시작       
        StartCoroutine(lifeTimeManage());
    }

    // 발사 지점 값을 리턴하는 메서드            
    public Vector3 getStartPos() { return startPos; }

    // 시간이 지나면 사라지게 만드는 코루틴 함수  
    private IEnumerator lifeTimeManage() {

        // lifeTime 값만큼 대기                      
        yield return new WaitForSeconds(lifeTime);

        // 시간이 지나면 오브젝트 파괴               
        Destroy(this.gameObject);
        yield return null;
    }
}
