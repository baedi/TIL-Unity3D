using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCan : ItemManager {

    // 변수               
    private bool isWaterOn = false;     /** 물 이펙트 활성화 여부 **/
    private float lerpPoint = 4f;
    private float waterLerpPoint = 2f;
    private GameObject effectInstant;

    public GameObject rHandAnchor;      /** 우측 핸드 컨트롤러 Transform **/
    public GameObject effectObj;
    public GameObject effectPosition;    

    // 반복문             
    private void Update() {

        /** 위치 고정, 이펙트 선형 보간 이용 **/
        transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(0, 0, 0), lerpPoint * Time.deltaTime);

        if (effectInstant != null && isWaterOn) {
            effectInstant.transform.position = effectPosition.transform.position;
            effectInstant.transform.rotation = Quaternion.Lerp(effectInstant.transform.rotation, effectPosition.transform.rotation, waterLerpPoint * Time.deltaTime);
        }

        /** 기울기 여부 확인 **/
        if ((rHandAnchor.transform.localEulerAngles.x >= 45 && rHandAnchor.transform.localEulerAngles.x <= 80) && !isWaterOn)
            WaterEffect(true);

        else if(!(rHandAnchor.transform.localEulerAngles.x >= 45 && rHandAnchor.transform.localEulerAngles.x <= 80) && isWaterOn)
            WaterEffect(false);

        /** 아이템 장착 해제 **/
        if(OVRInput.GetDown(OVRInput.Button.Back) || Input.GetKeyDown(KeyCode.R)) {
            WaterEffect(false);
            OnBackButtonClick();
        }
        
    }

    // 뒤로가기 버튼 클릭   
    public override void OnBackButtonClick() {
        base.OnBackButtonClick();
        Debug.Log("Water Can!");
    }

    // 물 이펙트 발생 여부  
    private void WaterEffect(bool waterOn) {
        isWaterOn = waterOn;

        if (isWaterOn){
            effectInstant = Instantiate(effectObj);
            effectInstant.GetComponentInChildren<ParticleSystem>().Play();
        }

        else{
            if (effectInstant == null) return;
            effectInstant.GetComponentInChildren<ParticleSystem>().Stop();
            effectInstant = null;
        }
    }
}
