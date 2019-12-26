using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorMove_Old1 : MonoBehaviour {

    // 변수           
    private float locationLow;        // 낮은 y축 위치 (초기)  
    private float locationHigh;       // 높은 y축 위치         
    private float maxHeight = 10.0f;  // 최대 높이             
    private float moveSpeed = 0.1f;   // 속도                  

    private bool isUpMode;            // 엘리베이터 상태 여부  

    // 초기화         
    void Start() {

        // 엘리베이터 시작, 끝 위치 설정                  
        locationLow = transform.position.y;
        locationHigh = locationLow + maxHeight;

        // isUpMode를 false로 설정 (엘리베이터가 낮은 층에 있는 상태로 만드는 것)
        isUpMode = false;

    }

    // 반복           
    void Update() {
        
        // 만약 올라기는 상태일 경우       
        if(isUpMode && (transform.position.y < locationHigh)) 
            transform.Translate(0, moveSpeed, 0);
        

        // 만약 내려가는 상태일 경우       
        else if(!isUpMode && (transform.position.y > locationLow)) 
            transform.Translate(0, -moveSpeed, 0);
        
    }

    // 외부 호출용 (한번 발생하면 isUpMode 상태를 매번 바꿈)  
    public void setUpDownMode() { isUpMode = !isUpMode; }
}
