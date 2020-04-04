using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniShovel : ItemManager {

    // 변수                    
    private bool isSoilEnable;          /** 흙 활성화 여부 **/
    private float digDistance = 0.32f;
    private float lerpPoint = 4f;

    private GameObject soilObject;


    // 초기화                  
    private void Start() {
        /** 아이템 최초 장착 시 동작 **/
        Debug.Log("MiniShovel Start( )");

        soilObject = transform.GetChild(1).gameObject;
        soilObject.SetActive(false);
    }

    // 반복문                  
    private void Update() {
        
        /** 삽 파기 **/
        if(OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) || Input.GetMouseButton(0)) 
            transform.localPosition = Vector3.Lerp(transform.localPosition, Vector3.forward * digDistance, lerpPoint * 2 * Time.deltaTime);
        

        /** 삽 원래대로 **/
        else 
            transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(0, 0, 0), lerpPoint * Time.deltaTime);
        

        /** 아이템 장착 해제 **/
        if (OVRInput.GetDown(OVRInput.Button.Back) || Input.GetKeyDown(KeyCode.R))
            OnBackButtonClick();
    }


    // 뒤로가기 버튼 클릭       
    public override void OnBackButtonClick() {
        base.OnBackButtonClick();
        Debug.Log("Mini Shovel!");
    }


    // 트리거 감지               
    private void OnTriggerEnter(Collider other) {

        /** 흙을 파지 않았고, 버튼을 누른 상태 **/
        if(OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) && !isSoilEnable) {
            if (!other.gameObject.CompareTag("trig_homiedig")) return;
            isSoilEnable = true;
            soilObject.SetActive(true);
            other.GetComponent<TriggerGenerator>().CallbackEffect(TriggerGenerator.GeneratorPointTypes.Lowdig);
        }

        /** 흙을 팠고, 버튼을 누른 상태 **/
        else if(OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) && isSoilEnable) {
            if (!other.gameObject.CompareTag("trig_homiestack")) return;
            isSoilEnable = false;
            soilObject.SetActive(false);
            other.GetComponent<TriggerGenerator>().CallbackEffect(TriggerGenerator.GeneratorPointTypes.Lowstack);
        }
    }
}
