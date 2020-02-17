using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VRPointer_old3 : MonoBehaviour {

    // 변수        
    private LineRenderer lineRendererComp;      // 라인 렌더러                 
    private RaycastHit raycastHit;              // 충돌 감지 전용              
    private GameObject currentButtonRay;        // 최근 감지된 버튼 오브젝트   

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

            // 충돌 객체의 태그가 Button인 경우        
            if (raycastHit.collider.gameObject.CompareTag("Button")) {

                // 클릭할 경우           
                if (OVRInput.GetDown(OVRInput.Button.One)){
                    raycastHit.collider.gameObject.GetComponent<Button>().onClick.Invoke();
                }

                else {
                    // 포인터 in 처리        
                    raycastHit.collider.gameObject.GetComponent<Button>().OnPointerEnter(null);
                    currentButtonRay = raycastHit.collider.gameObject;
                }
            }
        }

        else {
            lineRendererComp.SetPosition(1, transform.position + (transform.forward * raycastDistance));

            // 최근 감지된 오브젝트가 Button인 경우    
            if(currentButtonRay != null) {
                // 포인터 out 처리       
                currentButtonRay.GetComponent<Button>().OnPointerExit(null);
                currentButtonRay = null;
            }
        }
    }


    // 루프 2         
    private void LateUpdate() {
        // 버튼을 누를 경우        
        if (OVRInput.GetDown(OVRInput.Button.One)) {
            lineRendererComp.material.color = new Color(255, 255, 255, 0.5f);
        }

        // 버튼을 뗄 경우          
        else if (OVRInput.GetUp(OVRInput.Button.One)) {
            lineRendererComp.material.color = new Color(0, 195, 255, 0.5f);
        }
    }


}
