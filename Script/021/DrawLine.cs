using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour {

    // 변수                
    private LineRenderer lineRendererComponent; // LineRenderer 컴포넌트    
    public float lineDistance = 2;              // 선 길이                  

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
    }

    // 반복문              
    void Update() {
        // 시작점 설정           
        lineRendererComponent.SetPosition(0, transform.position);

        // 종료점 설정 (이 스크립트를 적용한 물체가 바라보는 방향의 2 길이까지를 종료점으로 설정)   
        lineRendererComponent.SetPosition(1, transform.position + transform.forward * lineDistance);
    }
}
