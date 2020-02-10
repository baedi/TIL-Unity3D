using UnityEngine;

public class ObjectViewManager : MonoBehaviour {

    // 변수           
    public GameObject targetObject;


    // 루프           
    private void Update() {

        // 스페이스 키를 누를 시 함수 호출   
        if (Input.GetKeyDown(KeyCode.Space))
            OnEnableSettingEvent();
    }


    // 게임 오브젝트 활성화 여부 설정 함수     
    public void OnEnableSettingEvent() {

        // 오브젝트가 활성화된 상태이면 -> 비활성화  
        if (targetObject.activeInHierarchy)
            targetObject.SetActive(false);

        // 오브젝트가 비활성화된 상태이면 -> 활성화  
        else
            targetObject.SetActive(true);

    }
}
