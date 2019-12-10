using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove3 : MonoBehaviour
{
    // 변수       
    private Transform controlTransform;     // 컨트롤 전용 오브젝트의 Transform   
    private float yKey;                     // Mouse Y                            
    private bool position;                  // 화면 뒤집힘 방지와 관련된 변수     
    private bool isFirstPersonScreen;       // 1인칭 모드인지 여부                

    public float rotateSpeed = 100.0f;      // 회전 속도                          

    private Transform cameraLocationObject; // 카메라 전용 오브젝트의 Transform   
    

    // 시작       
    void Start()
    {
        // ControlCube 라는 이름의 오브젝트의 transform을 가져와서 변수에 할당하고     
        // 카메라는 해당 오브젝트의 자식이 됨.                                         
        transform.parent = controlTransform = GameObject.Find("ControlCube").transform;

        cameraLocationObject = GameObject.Find("CameraLocation").transform;

        // 카메라 위치 설정                    
        setOnePersonMode();
        isFirstPersonScreen = true;
    }

    // 루프       
    void Update() {
        yKey = Input.GetAxis("Mouse Y");
        Vector3 rotateSetting = Vector3.left * yKey;

        if (Input.GetKeyDown(KeyCode.E)) {
            if (isFirstPersonScreen) { setThreePersonMode(); isFirstPersonScreen = false; }
            else { setOnePersonMode(); isFirstPersonScreen = true; }
        }

        // 정상적인 범위 내에서 y축을 움직일 경우       
        if (transform.rotation.eulerAngles.z < 180) {
            position = yKey >= 0 ? true : false;                            // 최근 플레이어의 회전 행동을 기록   
            transform.Rotate(rotateSetting * rotateSpeed * Time.deltaTime); // 회전                               
        }

        // 정상 범위를 넘어설 경우 조치 필요            
        else {
            // 마우스를 끝까지 올렸던 상태에서 마우스를 내릴 경우 움직임 허용  
            // 하늘을 끝까지 보다가 뒤집어지는 문제를 방지하기 위함            
            if (position && yKey < 0)
                transform.Rotate(rotateSetting * rotateSpeed * Time.deltaTime);

            // 마우스를 끝까지 내렸던 상태에서 마우스를 올릴 경우 움직임 허용  
            // 땅을 끝까지 보다가 뒤집어지는 문제를 방지하기 위함              
            else if(!position && yKey >= 0)
                transform.Rotate(rotateSetting * rotateSpeed * Time.deltaTime);
        }
    }

    // 1인칭 모드   
    private void setOnePersonMode() {
        transform.SetPositionAndRotation(
            new Vector3(controlTransform.position.x,            // 컨트롤 오브젝트의 X축 
                        controlTransform.position.y + 0.5f,     // 컨트롤 오브젝트의 Y축 
                        controlTransform.position.z),           // 컨트롤 오브젝트의 Z축 
            new Quaternion()
        );
    }

    // 3인칭 모드   
    private void setThreePersonMode() {
        transform.SetPositionAndRotation(
            new Vector3(cameraLocationObject.position.x,
                        cameraLocationObject.position.y,
                        cameraLocationObject.position.z),
            new Quaternion()
        );
    }
}

