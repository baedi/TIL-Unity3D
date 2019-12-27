using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {

    // 변수        
    public GameObject bullet;           // 총알 전용 게임오브젝트 
    private new Transform transform;    // Transform              

    // 초기화      
    void Start() {
        // 이 스크립트를 적용한 오브젝트의 Transform을 가져옴     
        transform = GetComponent<Transform>();
    }

    // 루프        
    void Update() {
        // 마우스를 누를 경우                   
        if (Input.GetMouseButtonDown(0)) {
            // 발사 위치 설정             
            Vector3 temp = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1.0f);

            // 오브젝트 복사 (총알 생성)  
            Instantiate(bullet, temp, transform.rotation);
        }
    }
}
