using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineTest : MonoBehaviour {

    // 변수                     
    private GameObject cube;
    public float moveSpeed = 0.3f;
    public bool moveMode = false;

    // 메인 함수                
    void Start() {
        cube = GameObject.Find("TestCube");     // TestCube라는 이름을 찾아 cube 객체에 삽입한다. 
        StartCoroutine(TestCoroutine());        // 코루틴 함수를 실행한다.                        
    }

    // 업데이트 함수            
    void Update() {
        moveControl(moveMode);
    }

    // 코루틴 함수              
    private IEnumerator TestCoroutine() {

        // 무한 루프    
        while (true) {
            yield return new WaitForSeconds(1); // 1초 대기        
            moveMode = !moveMode;               // 이동 방향 전환  
        }
    }

    // 이동 메서드              
    private void moveControl(bool isPlusX) {
        if (isPlusX)    transform.Translate(moveSpeed, 0, 0);   //  x축 이동   
        else            transform.Translate(-moveSpeed, 0, 0);  // -x축 이동   
        
    }
}
