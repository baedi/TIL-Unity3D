using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Player 오브젝트 전용 스크립트.
 * 플레이어의 행동을 감지함. (아이템 장착 여부 등)
 **/
public class PlayerManager : MonoBehaviour {

    // 변수                
    public GameObject handSlot;                             /** 아이템 장착 전용 오브젝트 **/
                                                            /** 0번 - OculusGoController, 1번 - HandModel, 2번 - EquipItem **/
    //public GameObject handModel;                            /** 맨 손 모델링 **/
    //public GameObject menuModel;                            /** 오큘러스 고 컨트롤러 모델링 **/
    public GameObject ui_options;                           /** 옵션 창 **/
    public GameObject focusPosition;                        /** CenterEyeAnchor **/
    public bool IsEquipItem { get; set; } = false;          /** 아이템 장착 여부 **/
    public bool IsPauseMenu { get; set; } = false;          /** 메뉴 창 활성화 여부 **/
    public bool IsGuideProcessing { get; set; } = false;    /** 가이드 진행 중 여부 **/

    private bool isClicking = false;

    // 반복문              
    private void Update() {

        /** 뒤로가기 버튼 클릭 시 **/
        if(OVRInput.GetDown(OVRInput.Button.Back) || Input.GetKeyDown(KeyCode.Escape)) {

            if (isClicking) return;

            /** 맨손 상태일 시 **/
            if (!IsEquipItem && !IsPauseMenu && !IsGuideProcessing)
                OptionsControl(true);

            /** 옵션 창을 띄운 상태일 시 **/
            else if (IsPauseMenu && !IsGuideProcessing)
                OptionsControl(false);

            isClicking = true;
        }

        else if (OVRInput.GetUp(OVRInput.Button.Back)) {
            isClicking = false;
        }

    }


    // 옵션 설정 (외부 가능)    
    public void OptionsControl(bool isOptionMode) {
        /** isOptionMode가 true이면 옵션 창이 활성화되도록 함. **/
        IsPauseMenu = isOptionMode;

        handSlot.transform.GetChild(1).gameObject.SetActive(!isOptionMode);
        handSlot.transform.GetChild(0).gameObject.SetActive(isOptionMode);

        //handModel.SetActive(!isOptionMode);
        //menuModel.SetActive(isOptionMode);
        ui_options.SetActive(isOptionMode);

        if (ui_options.activeInHierarchy) {
            ui_options.transform.position = focusPosition.transform.position + focusPosition.transform.forward;
            ui_options.transform.rotation = focusPosition.transform.rotation;
        }
    }

    // 가이드 설정 (외부 기능)   
    public void GuideControl(bool isProcessingGuide) {
        IsGuideProcessing = isProcessingGuide;

        /** 아이템이 존재하면 childCount는 3임. **/
        Debug.Log("Count : " + handSlot.transform.childCount);
        if (handSlot.transform.childCount == 3) handSlot.transform.GetChild(2).gameObject.SetActive(!isProcessingGuide);
        else handSlot.transform.GetChild(1).gameObject.SetActive(!isProcessingGuide);

        handSlot.transform.GetChild(0).gameObject.SetActive(isProcessingGuide);

        //handModel.SetActive(!isProcessingGuide);
        //menuModel.SetActive(isProcessingGuide);
    }


    // 아이템 장착 시 호출  
    public void OnItemEquip(GameObject equip) {

        IsEquipItem = true;

        /** 빈 손 모델링 비활성화 **/
        handSlot.transform.GetChild(1).gameObject.SetActive(false);
        //handModel.SetActive(false);

        /** 중력, 충돌 비활성화 **/
        equip.GetComponent<Rigidbody>().useGravity = false;

        Collider[] cols = equip.GetComponents<Collider>();
        for (int index = 0; index < cols.Length; index++)
            cols[index].isTrigger = true;

        /** 부모 관계 성립 **/
        equip.transform.parent = handSlot.transform;

        /** 위치 초기화 **/
        equip.transform.localPosition = new Vector3(0, 0, 0);
        equip.transform.localEulerAngles = new Vector3(0, 0, 0);

        /** 컴포넌트 활성화 **/
        equip.GetComponent<ItemManager>().enabled = true;
    }


    // 아이템 해제 시 호출  
    public void OnItemRelease(GameObject equip) {

        IsEquipItem = false;

        /** 컴포넌트 비활성화 **/
        equip.GetComponent<ItemManager>().enabled = false;

        /** 부모 관계 해제 **/
        equip.transform.parent = null;

        /** 빈 손 모델링 활성화 **/
        handSlot.transform.GetChild(1).gameObject.SetActive(true);
        //handModel.SetActive(true);

        /** 중력, 충돌 활성화 **/
        equip.GetComponent<Rigidbody>().useGravity = true;

        Collider[] cols = equip.GetComponents<Collider>();
        for (int index = 0; index < cols.Length; index++)
            cols[index].isTrigger = false;

    }


    // 아이템 사용(제거) 시 호출  
    public void OnItemDestroy(GameObject equip) {
        IsEquipItem = false;

        /** 아이템 제거 **/
        Destroy(equip);

        /** 빈 손 모델링 활성화 **/
        handSlot.transform.GetChild(1).gameObject.SetActive(true);
        //handModel.SetActive(true);
    }
}
