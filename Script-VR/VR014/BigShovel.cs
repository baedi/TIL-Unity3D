using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigShovel : ItemManager {

    // 변수               
    private bool isSoilEnable;          /** 흙 활성화 여부 **/
    private float digDistance = 0.36f;
    private float lerpPoint = 4f;

    private GameObject shovel_normal_model;
    private GameObject shovel_lomp_model;


    // 초기화              
    private void Start() {
        /** 아이템을 최초 장착했을 시 동작함. **/
        Debug.Log("BigShovel Start( )");
        shovel_normal_model = transform.GetChild(0).gameObject;
        shovel_lomp_model = transform.GetChild(1).gameObject;
        shovel_normal_model.SetActive(true);
        shovel_lomp_model.SetActive(false);
    }

    // 반복문             
    private void Update() {

        /** 삽 파기 **/
        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) || Input.GetMouseButton(0)) {
            transform.localPosition = Vector3.Lerp(transform.localPosition, Vector3.forward * digDistance, lerpPoint * 2 * Time.deltaTime);
        }

        else if(OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) || Input.GetMouseButtonDown(0)) {
            /** 삽에 흙이 존재할 경우 뿌리기 **/
            if (isSoilEnable) {
                isSoilEnable = false;
                shovel_normal_model.SetActive(true);
                shovel_lomp_model.SetActive(false);
            }
        }


        /** 삽 원래대로 **/
        else {
            transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(0, 0, 0), lerpPoint * Time.deltaTime);
        }

        /** 아이템 장착 해제 **/
        if(OVRInput.GetDown(OVRInput.Button.Back) || Input.GetKeyDown(KeyCode.R)) {
            OnBackButtonClick();
        }
    }

    // 뒤로가기 버튼 클릭    
    public override void OnBackButtonClick() {
        base.OnBackButtonClick();
        Debug.Log("Big Shovel!");
    }


    // 트리거 감지           
    private void OnTriggerEnter(Collider other) {

        if (!other.gameObject.CompareTag("trig_dig")) return;

        /** 흙이 있으면서 버튼을 누른 상태 **/
        if(OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) && !isSoilEnable){
            isSoilEnable = true;
            shovel_normal_model.SetActive(false);
            shovel_lomp_model.SetActive(true);
        }
    }

}
