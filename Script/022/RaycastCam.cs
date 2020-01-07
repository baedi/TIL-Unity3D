using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastCam : MonoBehaviour
{

    // 변수           
    private GameObject cam3in;      // 카메라 3인칭용 오브젝트    
    private RaycastHit hit;         // 충돌감지용                 
    private float distance;         // 충돌 거리                  
    private GameObject pointerObj;  // 포인터 UI 게임오브젝트     
    

    // 초기화         
    private void Start() {
        // CameraLocation 이라는 오브젝트 이름을 탐색   
        cam3in = GameObject.Find("CameraLocation");
        distance = GetComponent<DrawLine>().getLineDistance();

        pointerObj = GameObject.Find("Pointer");
        pointerObj.SetActive(false);
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

            // 만약 감지된 객체가 트리거일 경우 리턴  
            if (hit.collider.isTrigger) {
                pointerObj.SetActive(false);
                return;
            }

            // 해당 객체의 오브젝트 이름 & 지점 출력   
            Debug.Log(hit.transform.gameObject.name.ToString() + " Location : " + hit.point);

            // 충돌 지점 표시                          
            pointerObj.SetActive(true);
            pointerObj.transform.position = hit.point + new Vector3(0, 0.01f, 0);


            // 만약 해당 오브젝트를 클릭했을 시 오브젝트 이름이 button일 경우   
            if (Input.GetMouseButtonDown(0) && hit.transform.gameObject.name.ToString().Equals("button")) {

                // ElevatorMove 스크립트 내에 있는 setUpDownMode 메서드 호출     
                GameObject temp = GameObject.Find("Elevator");
                temp.GetComponent<ElevatorMove>().setUpDownMode();

                Debug.Log("Elevator Enabled!");
            }

            
            /*
            if(Input.GetMouseButtonDown(0) && hit.transform.gameObject.CompareTag("Ground")) {
                Debug.Log("Create Sphere Object");
                GameObject objectSp = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                objectSp.transform.position = hit.point;
                objectSp.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                objectSp.GetComponent<SphereCollider>().isTrigger = true;
            }
            */
        }

        else {
            pointerObj.SetActive(false);
        }
    }
}
