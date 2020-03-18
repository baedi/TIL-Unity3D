using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBox : ItemManager {

    // 변수                
    private bool isEffectEnable = true;     /** 이펙트 발생 가능 여부 **/
    private float lerpPoint = 4f;           /** 선형 보간 전용 **/

    public GameObject effectObj;            /** 이펙트 오브젝트 **/


    // 반복문              
    private void Update() {

        /** 위치 고정 **/
        transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(0, 0, 0), lerpPoint * Time.deltaTime);

        /** 버튼 클릭 여부 확인 **/
        if (isEffectEnable && (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) || Input.GetKeyDown(KeyCode.E))) {
            isEffectEnable = false;
            StartCoroutine(DelayEffect());
            FertilizerEffect();
        }

        /** 아이템 장착 해제 **/
        if(OVRInput.GetDown(OVRInput.Button.Back) || Input.GetKeyDown(KeyCode.R)) {
            OnBackButtonClick();
        }
    }


    // 뒤로가기 버튼 클릭  
    public override void OnBackButtonClick() {
        base.OnBackButtonClick();
        Debug.Log("Green Box!");
    }

    // 이펙트 발생         
    private void FertilizerEffect() {
        GameObject effectTemp = Instantiate(effectObj);
        effectTemp.transform.position = this.transform.position;
        effectTemp.transform.rotation = this.transform.rotation;
    }

    // 이펙트 딜레이용     
    private IEnumerator DelayEffect() {
        /** 1초 딜레이 **/
        yield return new WaitForSeconds(1);

        isEffectEnable = true;
        yield return null;
    }
}
