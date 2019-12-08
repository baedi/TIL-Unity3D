using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    // 변수       
    private Transform controlTransform;     // 컨트롤 전용 오브젝트의 Transform   

    // 시작       
    void Start()
    {
        // ControlCube 라는 이름의 오브젝트의 transform을 가져와서 변수에 할당하고     
        // 카메라는 해당 오브젝트의 자식이 됨.                                         
        transform.parent = controlTransform = GameObject.Find("ControlCube").transform;

        // 카메라 위치 설정                    
        transform.SetPositionAndRotation(
            new Vector3(controlTransform.position.x,            // 컨트롤 오브젝트의 X축 
                        controlTransform.position.y + 0.5f,     // 컨트롤 오브젝트의 Y축 
                        controlTransform.position.z),           // 컨트롤 오브젝트의 Z축 
            new Quaternion()
        );
    }

    // 루프       
    void Update()
    {
        
    }
}
