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

    // 충돌 감지            
    private void OnCollisionEnter(Collision collision)
    {

        // 충돌한 물체(부모)의 태그 정보        
        Debug.Log(collision.gameObject.tag);

        // 충돌한 물체 부위의 태그 정보         
        Debug.Log(collision.collider.gameObject.tag);


        // 태그별 조건문          
        if (collision.collider.gameObject.CompareTag("chHead"))
            Debug.Log("Head!");

        else if (collision.collider.gameObject.CompareTag("chBody"))
            Debug.Log("Body!");

        else if (collision.collider.gameObject.CompareTag("chArm"))
            Debug.Log("Arm!");

        else if (collision.collider.gameObject.CompareTag("chLeg"))
            Debug.Log("Leg!");
    }

    // 트리거 감지           
    private void OnTriggerEnter(Collider other) {
        // 트리거가 감지된 부위의 태그 정보                                       
        Debug.Log(other.gameObject.tag);

        // 충돌한 오브젝트에서 리지드바디 컴포넌트를 가진 오브젝트의 태그 정보.   
        Debug.Log(other.attachedRigidbody.tag);
    }
}
