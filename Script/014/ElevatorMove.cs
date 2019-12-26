using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorMove : MonoBehaviour {

    // 변수           
    private float locationLow;        // 낮은 y축 위치 (초기)  
    private float locationHigh;       // 높은 y축 위치         
    private float maxHeight = 50.0f;  // 최대 높이             

    private float currentSpeed;
    private float minSpeed = 0.01f;         // 최저 속도      
    private float maxSpeed = 0.1f;          // 최대 속도      
    private const float downSpeed = 0.95f;  // 속도 감소용    
    private const float upSpeed = 1.005f;   // 속도 증가용    

    private bool isUpMode;            // 엘리베이터 상태 여부  
    private bool enableOn;            // 엘리베이터 작동 여부  
    

    // 초기화         
    void Start() {

        // 엘리베이터 시작, 끝 위치 설정                  
        locationLow = transform.position.y;
        locationHigh = locationLow + maxHeight;

        // isUpMode를 false로 설정 (엘리베이터가 낮은 층에 있는 상태로 만드는 것)
        isUpMode = false;           
        enableOn = false;           // 엘리베이터 비활성화   
        currentSpeed = 0;           // 속도 초기화           
    }

    // 반복           
    void Update() {

        // 엘리베이터가 작동 상태일 경우     
        if (enableOn) {

            // 만약 올라기는 상태일 경우          
            if (isUpMode && (transform.position.y < locationHigh)) {
                currentSpeed = currentSpeed <= 0.1 ? currentSpeed * upSpeed : currentSpeed;
                transform.Translate(0, currentSpeed, 0);
            }

            // 만약 내려가는 상태일 경우          
            else if (!isUpMode && (transform.position.y > locationLow)) {
                currentSpeed = currentSpeed <= 0.1 ? currentSpeed * upSpeed : currentSpeed;
                transform.Translate(0, -currentSpeed, 0);
            }

            // 범위를 벗어날 경우 작동 상태 해제  
            else enableOn = false;
        }


        // 범위를 벗어날 경우  (속도가 조금씩 줄어듬)        
        else {
            currentSpeed = currentSpeed * downSpeed;
            transform.Translate(0, isUpMode ? currentSpeed : -currentSpeed, 0);
        }

    }

    // 외부 호출용 (한번 발생하면 isUpMode 상태를 매번 바꿈)  
    public void setUpDownMode() {
        isUpMode = !isUpMode;       // 엘리베이터 올라가기/내려가기  
        currentSpeed = minSpeed;    // 속도 초기화                   
        enableOn = true;            // 엘리베이터 활성화             
    }
}
