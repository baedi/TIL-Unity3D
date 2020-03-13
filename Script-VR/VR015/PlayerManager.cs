using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Player 오브젝트 전용 스크립트.
 * 플레이어의 행동을 감지함. (아이템 장착 여부 등)
 **/
public class PlayerManager : MonoBehaviour {

    // 변수                
    public GameObject handSlot;                     /** 아이템 장착 전용 오브젝트 **/
    public GameObject handModel;                    /** 맨 손 모델링 **/
    public GameObject menuModel;                    /** 오큘러스 고 컨트롤러 모델링 **/
    public bool IsEquipItem { get; set; } = false;  /** 아이템 장착 여부 **/
    public bool IsPauseMenu { get; set; } = false;  /** 메뉴 창 활성화 여부 **/

    // 반복문              
    private void Update() {
        
        /** 메뉴 창 활성화 (Pause Menu) **/
        if(OVRInput.GetDown(OVRInput.Button.Back) && !IsEquipItem) {
            /** 메뉴 창 띄우기 **/

            /** 오큘러스 고 모델링으로 변경 **/

        }

    }

    // 아이템 장착 시 호출  
    public void OnItemEquip(GameObject equip) {

        IsEquipItem = true;

        /** 빈 손 모델링 비활성화 **/
        handModel.SetActive(false);

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
        handModel.SetActive(true);

        /** 중력, 충돌 활성화 **/
        equip.GetComponent<Rigidbody>().useGravity = true;

        Collider[] cols = equip.GetComponents<Collider>();
        for (int index = 0; index < cols.Length; index++)
            cols[index].isTrigger = false;

    }
}
