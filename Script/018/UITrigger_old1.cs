using UnityEngine;
using UnityEngine.UI;

public class UITrigger_old1 : MonoBehaviour {

    // 변수                    
    private Image imgComponent;

    // 초기화                  
    void Start() {
        // 자식 오브젝트의 Image 컴포넌트를 가져온 뒤 투명도를 0으로 조절       
        imgComponent = gameObject.GetComponentInChildren<Image>();
        transpChange(0);
    }

    // 트리거가 감지될 경우                  
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            Debug.Log("Trigger ON");    // 트리거 감지 메시지 출력    
            transpChange(0.5f);         // 투명도 50% 조절            
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
