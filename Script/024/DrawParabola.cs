using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawParabola : MonoBehaviour {

    // 변수                
    private LineRenderer lineRendererComponent; // LineRenderer 컴포넌트    
    public float parabolaHeight = 10f;          // 포물선 높이              

    private Vector3 targetPoint;                // 포물선의 끝 지점       
    private Vector3 center = Vector3.zero;      // 포물선 중앙 지점       
    private Vector3 theArc = Vector3.zero;

    private bool isDrawLineEnable;
    private RaycastCam rayCastCam;


    // 초기화              
    [System.Obsolete]
    void Start() {

        // 머터리얼 생성 및 색상 초기화                 
        Material material = new Material(Shader.Find("Standard"));
        material.color = new Color(255, 0, 0);

        // LineRenderer 컴포넌트 생성 및 가져오기       
        this.gameObject.AddComponent<LineRenderer>();
        lineRendererComponent = GetComponent<LineRenderer>();

        // LineRenderer Material 적용 및 크기 설정      
        lineRendererComponent.material = material;
        lineRendererComponent.SetWidth(0.05f, 0.05f);
        lineRendererComponent.positionCount = 25;       // 포지션 인덱스 설정   (포물선 계산 크기만큼)   

        // RaycastCam 스크립트 가져오기                 
        rayCastCam = GetComponent<RaycastCam>();
    }

    // 반복문              
    void Update() {

        // RaycastCam에 의해 물체 충돌이 감지될 경우     
        if (isDrawLineEnable) {

            // LineRenderer 컴포넌트 활성화.             
            lineRendererComponent.enabled = true;

            // 충돌지점 가져와서 targetPoint 변수에 저장 
            targetPoint = rayCastCam.getCollisionPoint();

            // 중앙지점 설정                             
            center = (transform.position + targetPoint) * 0.5f;
            center.y -= parabolaHeight;

            Vector3 relCenter = transform.position - center;
            Vector3 aimRelCenter = targetPoint - center;

            // 포물선 그리기                              
            float interval = -0.0417f;
            for(int index = 0; interval < 1.0f;) {
                theArc = Vector3.Slerp(relCenter, aimRelCenter, interval += 0.0417f);
                lineRendererComponent.SetPosition(index++, theArc + center);
                //Debug.Log("Index : " + index + "\tPosition : " + (theArc + center));
            }
        }


        else {
            targetPoint = Vector3.zero;
            lineRendererComponent.enabled = false;
        }
    }

    // 충돌 감지 여부 판단 메서드               
    public void setDrawLine(bool temp) { isDrawLineEnable = temp; }
}
