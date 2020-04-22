using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovingControl : MonoBehaviour {

    // 변수                    
    public Transform target;

    private float movSpeed = 1.0f;
    private float rotSpeed = 2.0f;
    private float plusY = 1.0f;

    // 초기화                  
    private void Start() {
        
    }

    // 반복                    
    private void Update() {

        // 타깃의 y축 계산            
        Vector3 tempTargetPoint = 
            target.position + new Vector3(0, (target.transform.position.y - transform.position.y) + plusY, 0); 


        // 타깃을 바라보도록 함       
        transform.rotation = Quaternion.Lerp(
            transform.rotation,
            Quaternion.LookRotation(tempTargetPoint - transform.position), rotSpeed * Time.deltaTime);

        transform.position += transform.forward * movSpeed * Time.deltaTime;
    }
}
