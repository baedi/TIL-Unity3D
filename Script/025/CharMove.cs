using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMove : MonoBehaviour {

    // Var                          
    private GameObject cameraPosSettingObject;  // 카메라 위치 전용 오브젝트 
    private GameObject cameraObject;            // 카메라 오브젝트           

    private new Rigidbody rigidbody;            // 리지드바디 컴포넌트       
    private Animator animator;                  // 애니메이터 컴포넌트       

    private bool isMoving;                      // 달리기(이동) 중인지 여부  
    private bool isJumping = true;              // 점프 중인지 여부          


    public float runSpeed = 3.5f;       // 달리기 속도           
    public float rotateSpeed = 150f;    // 회전 속도             
    public float jumpPower = 200f;      // 점프력                

    public float cameraMoveSpeed = 6f;  // 카메라 이동/회전 속도 



    // Constructor                                              
    private void Start() {

        // 컴포넌트 가져옴                             
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();

        // 리지드바디에서 모든 회전 좌표를 정지시킴    
        rigidbody.freezeRotation = true;


        // 메인 카메라 오브젝트를 찾아서 저장           
        cameraObject = GameObject.Find("Main Camera");


        // 카메라 전용 빈 오브젝트 공간 생성 및 초기화            
        cameraPosSettingObject = new GameObject();                              // 빈 오브젝트 생성         
        cameraPosSettingObject.name = "CamLocation";                            // 오브젝트 이름            
        cameraPosSettingObject.transform.position = this.transform.position;    // 위치 설정                
        cameraPosSettingObject.transform.Translate(Vector3.back * 3);           // 추가 위치 설정           
        cameraPosSettingObject.transform.Translate(Vector3.up * 1);
        cameraPosSettingObject.transform.eulerAngles = new Vector3(15, 0, 0);   // 회전 설정                
        cameraPosSettingObject.transform.parent = this.transform;               // Player의 자식이 됨       

    }


    // 루프 1 (기타 처리 사항)  
    private void Update() {

        // 애니메이션 설정                                      
        if (isMoving)   animator.SetBool("isRunning", true);    // 달리기 상태면 isRunning를 true로            
        else            animator.SetBool("isRunning", false);   // 달리기 상태가 아니면 isRunning을 false로    
    }


    // 루프 2 (연산 처리 사항)  
    private void FixedUpdate() {
        Run();          // 이동 처리     
        Rotation();     // 회전 처리     
        Jump();         // 점프 처리     
    }


    // 루프 3 (카메라 관련 처리) 
    private void LateUpdate() {

        // 카메라의 위치를 부드럽게 이동함.   (CamLocation 위치값 기준)    
        cameraObject.transform.position = Vector3.Lerp(cameraObject.transform.position, 
            cameraPosSettingObject.transform.position, cameraMoveSpeed * Time.deltaTime);

        // 카메라의 회전을 부드럽게 회전함.   (CamLocation 회전값 기준)    
        cameraObject.transform.rotation = Quaternion.Lerp(cameraObject.transform.rotation, 
            cameraPosSettingObject.transform.rotation, cameraMoveSpeed * Time.deltaTime);
    }


    // 달리기 메소드              
    private void Run() {
            
        // W키를 누를 경우 전진                   
        if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S)) {
            transform.Translate(Vector3.forward * (runSpeed * Time.deltaTime));
            isMoving = true;
        }

        // S키를 누를 경우 후진                   
        else if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W)) {
            transform.Translate(Vector3.back * (runSpeed * Time.deltaTime));
            isMoving = true;
        }

        // W, S키 중 어느 키도 누르지 않았을 경우 
        else isMoving = false;
    }


    // 회전 메소드               
    private void Rotation() {

        // Y축 회전 기준 전용 Quaternion 객체 생성     
        Quaternion temp = new Quaternion(0, 1, 0, 0);

        // 좌측 회전                                    
        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D)) 
            transform.Rotate(Vector3.down * (rotateSpeed * Time.deltaTime));

        // 우측 회전                                    
        else if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A)) 
            transform.Rotate(Vector3.up * (rotateSpeed * Time.deltaTime));

    }


    // 점프 메소드               
    private void Jump() {
        // Space 키 누를 시, 점프 상태가 아니면 점프       
        if (Input.GetKey(KeyCode.Space) && !isJumping) 
            rigidbody.AddForce(Vector3.up * (jumpPower * Time.deltaTime), ForceMode.Impulse);
        
    }


    // 충돌 확인                 
    private void OnCollisionEnter(Collision collision) {
        // Floor 태그의 오브젝트와 충돌 시 점프 상태 아닌 것으로 취급     
        if (collision.gameObject.CompareTag("Floor"))
            isJumping = false;

    }

    private void OnCollisionExit(Collision collision) {
        // Floor 태그의 오브젝트를 벗어날 시 점프 상태 중인 것으로 취급    
        if (collision.gameObject.CompareTag("Floor"))
            isJumping = true;

    }
}
