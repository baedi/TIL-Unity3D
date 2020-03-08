using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homie : ItemManager {

    // 변수               
    private float digDistance = 0.35f;
    private float lerpPoint = 4f;
    

    // 반복문              
    private void Update() {

        /** 호미 파기 **/
        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) || Input.GetMouseButton(0))
            transform.localPosition = Vector3.Lerp(transform.localPosition, Vector3.forward * digDistance, lerpPoint * 2 * Time.deltaTime);

        /** 호미 원래대로 **/
        else
            transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(0, 0, 0), lerpPoint * Time.deltaTime);

        /** 아이템 장착 해제 **/
        if (OVRInput.GetDown(OVRInput.Button.Back) || Input.GetKeyDown(KeyCode.R))
            OnBackButtonClick();
    }

    // 뒤로가기 버튼 클릭   
    public override void OnBackButtonClick() {
        base.OnBackButtonClick();
        Debug.Log("Homie!");
    }


    // 트리거 감지           
    private void OnTriggerEnter(Collider other) {
        if (!other.gameObject.CompareTag("trig_bokjugi")) return;
    }
}
