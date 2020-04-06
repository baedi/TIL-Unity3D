using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/**
 * 음악, 사운드 볼륨 조절용 스크롤바에 사용되는 스크립트.
 * 음악, 사운드 볼륨을 조절하고 포인터에 손을 뗄 경우 사운드, 볼륨 값을 저장하는 스크립트임.
 **/
public class VolumeScrollbarPointerEvent : MonoBehaviour, IPointerUpHandler{

    // 변수                   
    public GameObject mainManager;
    private DatabaseManager dbManager;

    // 초기화                 
    public void Start() {
        if (mainManager == null)
            mainManager = GameObject.Find("MainManager");

        dbManager = mainManager.GetComponent<DatabaseManager>();
    }


    // 스크롤바에서 터치 뗄 시 호출되는 이벤트   
    public void OnPointerUp(PointerEventData eventData) {

        /** 볼륨 설정 저장 **/
        dbManager.SetupVolume();
        Debug.Log("Volume saved...");

        StartCoroutine(FlashingEffect());
    }

    // 세이브 효과 전용                           
    private IEnumerator FlashingEffect() {
        Text temp = this.transform.GetChild(2).GetComponent<Text>();
        temp.color = new Color(0, 255, 0);

        yield return new WaitForSeconds(0.3f);
        temp.color = new Color(0, 0, 0);

        yield return null;
    }
}
