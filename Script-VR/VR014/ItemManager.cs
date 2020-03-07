using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * Item 부모 클래스
 * 
 **/
public class ItemManager : MonoBehaviour {

    // 변수               
    public GameObject playerManager;


    // 초기화             
    private void Awake(){

        /** 스크립트를 비활성화함 **/
        enabled = false;
    }

    /** 트리거 버튼 누를 시 수행할 동작 **/
    public virtual void OnTriggerButtonClick() { }

    /** 원형 버튼 누를 시 수행할 동작 **/
    public virtual void OnForwardButtonClick() { }

    /** 원형 버튼 터치 시 수행할 동작 **/
    public virtual void OnForwardButtonTouch() { }

    /** 뒤로가기 버튼 누를 시 수행할 동작 **/
    public virtual void OnBackButtonClick() {
        playerManager.GetComponent<PlayerManager>().OnItemRelease(this.gameObject);
    }
}
