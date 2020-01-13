using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : MonoBehaviour {

    // 변수           
    private LineRenderer lineComponent;
    private const int MAX_BULLET = 12;
    private int currentBullet;

    public float lineDistance = 1;
    public GameObject bullet;

    // 초기화          
    [System.Obsolete]
    private void Awake() {

        // 머터리얼 생성/초기화           
        Material mat = new Material(Shader.Find("UI/Default"));
        mat.color = new Color(255, 0, 0, 0.5f);

        // LineComponent 생성/가져오기    
        lineComponent = gameObject.AddComponent<LineRenderer>().GetComponent<LineRenderer>();
        lineComponent.material = mat;
        lineComponent.SetWidth(0.005f, 0.005f);

        // 장전 수 설정                   
        currentBullet = MAX_BULLET;
    }


    // 루프 1         
    private void FixedUpdate() {

        // 선 그리기                        
        lineComponent.SetPosition(0, transform.position);
        lineComponent.SetPosition(1, transform.position + transform.forward * lineDistance);

    }


    // 루프 2         
    private void Update() {

        // 트리거 버튼 누를 시      
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) || Input.GetMouseButtonDown(0)) {

            // 총알이 존재할 경우       
            if(currentBullet != 0) {

                // 총알 발사                 
                Instantiate(bullet, transform.position, transform.rotation);

                // 총알 발사 사운드 추가     


                // 총알 수 줄이기            
                currentBullet--;
            }

            // 총알이 없는 경우         
            else {
                // 총알 부족 사운드 추가     
            }

        }

        // 원형 버튼 누를 시       
        else if(OVRInput.GetDown(OVRInput.Button.One) || Input.GetMouseButtonDown(1)) {
            currentBullet = MAX_BULLET;
        }

    }
}
