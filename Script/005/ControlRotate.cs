using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlRotate : MonoBehaviour
{

    public float rotateSpeed = 100.0f;    // 회전 속도            
    private float xMouse;                 // 마우스 X축           

    // 시작 함수    
    void Start() { }

    // 루프 함수    
    void Update()
    {
        xMouse = Input.GetAxis("Mouse X");
        Vector3 rotateSetting = Vector3.up * xMouse;

        transform.Rotate(rotateSetting * rotateSpeed * Time.deltaTime);
    }
}
