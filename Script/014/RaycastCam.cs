using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastCam : MonoBehaviour
{

    // 변수           
    private GameObject cam3in;      // 카메라 3인칭용 오브젝트    
    private RaycastHit hit;         // 충돌감지용                 
    private float distance = 2f;    // 충돌 거리                  

    
    // 초기화         
    private void Start() {
        // CameraLocation 이라는 오브젝트 이름을 탐색   
        cam3in = GameObject.Find("CameraLocation");
    }


    // 반복           
    private void Update() {
        // 만약 3인칭 모드일 경우 객체를 감지하지 않음    
        if (cam3in != null && 
            cam3in.transform.position == transform.position) return;

        // 레이저 발사 (Scene에서만 확인 가능)            
        Debug.DrawRay(transform.position, transform.forward * distance, Color.green, 0.5f);

        // 일정 범위 내에 객체가 감지될 경우        
        if(Physics.Raycast(transform.position, transform.forward, out hit, distance)) {
            // 해당 객체의 오브젝트 이름 출력       
            Debug.Log(hit.transform.gameObject.name.ToString());

            // 만약 해당 오브젝트를 클릭했을 시 오브젝트 이름이 button일 경우   
            if (Input.GetMouseButtonDown(0) && hit.transform.gameObject.name.ToString().Equals("button")) {

                // ElevatorMove 스크립트 내에 있는 setUpDownMode 메서드 호출     
                GameObject temp = GameObject.Find("Elevator");
                temp.GetComponent<ElevatorMove>().setUpDownMode();

                Debug.Log("Elevator Enabled!");
            }
        }
    }
}
