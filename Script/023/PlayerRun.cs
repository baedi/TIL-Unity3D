using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRun : MonoBehaviour {

    // 변수            
    public float runSpeed = 6f;      // 이동 속도    
    public float rotateSpeed = 90f;    // 회전 속도    
    public float jumpPower = 50f;     // 점프력       

    private GameObject cameraObj;       // 카메라 오브젝트      
    private Animator animatorManager;   // Animator 컴포넌트    
    private new Rigidbody rigidbody;    // Rigidbody 컴포넌트   
    

    // 초기화          
    void Awake() {
        // Animator 컴포넌트 가져오기                               
        animatorManager = GetComponentInChildren<Animator>();

        // 카메라 오브젝트 가져온 뒤 플레이어의 자식이 되도록 설정  
        cameraObj = GameObject.Find("Main Camera");
        cameraObj.transform.parent = this.transform;

        // 카메라의 좌표, 회전값을 플레이어의 시점에 맞게 조절      
        cameraObj.transform.position = transform.position + (transform.forward * -5f) + (Vector3.up * 2f);
        cameraObj.transform.Rotate(new Vector3(15, 0, 0));

        // 리지드바디 컴포넌트 가져오기                             
        rigidbody = GetComponent<Rigidbody>();
    }

    // 루프            
    void FixedUpdate() {

        // 플레이어 이동(전/후진) 관련 반복문         
        if (Input.GetKey(KeyCode.W)) {
            transform.Translate(Vector3.forward * runSpeed * Time.deltaTime);
            animatorManager.SetBool("isRun", true);
        }

        else if (Input.GetKey(KeyCode.S)) {
            transform.Translate(Vector3.back * runSpeed * Time.deltaTime);
            animatorManager.SetBool("isRun", true);
        }

        else {
            animatorManager.SetBool("isRun", false);
        }


        // 플레이어 회전(좌/우) 관련 조건문            
        if (Input.GetKey(KeyCode.A))
            transform.Rotate(Vector3.down * rotateSpeed * Time.deltaTime);

        else if (Input.GetKey(KeyCode.D))
            transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);


        // 플레이어 점프 관련 조건문                   
        if (Input.GetKey(KeyCode.Space)) {
            rigidbody.AddForce(Vector3.up * jumpPower * Time.deltaTime, ForceMode.Impulse);
        }
        
    }
}
