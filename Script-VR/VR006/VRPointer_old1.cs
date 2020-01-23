using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRPointer_old1 : MonoBehaviour {

    // 변수        
    private LineRenderer lineRendererComp;  // 라인 렌더러    
    private RaycastHit raycastHit;          // 충돌 감지 전용 

    public float raycastDistance = 50f;     // 감지 거리      


    // 초기화      
    private void Awake() {

        // 컴포넌트 추가      
        lineRendererComp = this.gameObject.AddComponent<LineRenderer>();

        // 라인 설정          
        Material material = new Material(Shader.Find("Standard"));
        material.color = new Color(0, 195, 255, 0.5f);

        lineRendererComp.material = material;
        lineRendererComp.positionCount = 2;
        lineRendererComp.startWidth = 0.01f;
        lineRendererComp.endWidth = 0.01f;
    }


    // 루프        
    private void Update() {

        lineRendererComp.SetPosition(0, transform.position);

        Debug.DrawRay(transform.position, transform.forward * raycastDistance, Color.green, 0.5f);

        // 충돌 감지 시      
        if (Physics.Raycast(transform.position, transform.forward, out raycastHit, raycastDistance)) {
            lineRendererComp.SetPosition(1, raycastHit.point);
        }

        else {
            lineRendererComp.SetPosition(1, transform.position + (transform.forward * raycastDistance));
        }
    }
}
