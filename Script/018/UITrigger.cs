using UnityEngine;
using UnityEngine.UI;

public class UITrigger : MonoBehaviour {

    // 변수                    
    private Image imgComponent;         // 이미지 컴포넌트 
    private RectTransform uiTransform;  // UI 전용         
    private float radius;               // 트리거 범위     
    private float fullTransp = 0.8f;    // 최대 투명도     

    // 초기화                  
    void Start() {
        // 자식 오브젝트의 Image 컴포넌트를 가져온 뒤 투명도를 0으로 조절       
        imgComponent = gameObject.GetComponentInChildren<Image>();
        transpChange(0);

        // 트리거 범위 값을 가져옴                                              
        radius = GetComponentInChildren<SphereCollider>().radius;
        Debug.Log("Radius : " + radius);
        Debug.Log((5.0f / radius) * 100);

        // UI의 위치 컴포넌트(Transform)을 가져옴      
        uiTransform = GetComponentInChildren<RectTransform>();
    }

    // 트리거가 감지될 경우                      
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            Debug.Log("Trigger ON");    // 트리거 감지 메시지 출력    
        }
    }

    // 트리거에 감지된 물체가 계속 머무를 경우   
    private void OnTriggerStay(Collider other) {
        if (other.gameObject.CompareTag("Player")) {

            // 플레이어를 계속 바라보도록 함.                         
            uiTransform.LookAt(other.transform);

            // 물체와 플레이어(트리거) 간의 거리 계산 후 백분율 계산  
            float distance = Vector3.Distance(transform.position, other.transform.position);
            float transpTemp = distance / radius;

            // 거리에 따른 UI 투명도 조절                             
            transpChange(fullTransp - transpTemp);
        }
    }


    // 트리거에 감지된 물체가 벗어날 경우        
    private void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            Debug.Log("Trigger OFF");   // 트리거 벗어남 메시지 출력  
            transpChange(0);            // 투명도 0% 조절             
        }
    }

    // 투명도 조절 메소드                   
    private void transpChange(float transp) {
        imgComponent.color = new Color(imgComponent.color.r, imgComponent.color.g, imgComponent.color.b, transp);
    }
}
