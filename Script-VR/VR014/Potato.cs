using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * ItemManager 자식 클래스.
 * 이 클래스는 아이템 역할을 수행함.
 * PotatoProcess.cs와 연계함.
 **/
public class Potato : ItemManager {

    // 변수               
    private float lerpPoint = 4f;
    private float raycastDistance = 1.5f;
    private RaycastHit raycastHit;
    private Transform cameraTransform;

    public GameObject raycastUICanvas;
    public GameObject growPotatoPrefab;


    // 초기화             
    private void Start() {
        /** 아이템을 최초로 장착했을 시 동작 **/
        cameraTransform = GetComponentInParent<OVRCameraRig>().gameObject.transform;
    }

    // 반복문             
    private void Update() {

        /** Raycast 활성화 **/
        Debug.DrawRay(transform.position, transform.forward * raycastDistance, Color.green, 0.5f);

        /** 감지 확인 **/
        if(Physics.Raycast(transform.position, transform.forward, out raycastHit, raycastDistance) && this.enabled) {

            /** plant 콜라이더를 감지했을 경우 UI 표시 **/
            if (raycastHit.collider.gameObject.CompareTag("col_plant")
                && !(OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) || Input.GetKeyDown(KeyCode.E))) {

                /** UI 표시 **/
                raycastUICanvas.GetComponentInChildren<Text>().text = "심기";
                raycastUICanvas.transform.LookAt(cameraTransform.position);
                raycastUICanvas.transform.position = raycastHit.collider.gameObject.transform.position + (Vector3.up * 0.5f);
                raycastUICanvas.SetActive(true);
            }

            /** 버튼도 같이 눌렀을 경우 동작 **/
            else if(raycastHit.collider.gameObject.CompareTag("col_plant")
                && (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) || Input.GetKeyDown(KeyCode.E))) {

                /** 감자 심기 **/
                GameObject temp = Instantiate(growPotatoPrefab);
                temp.transform.position = raycastHit.transform.position;
                raycastHit.collider.gameObject.GetComponent<TriggerGenerator>().CallbackEffect(TriggerGenerator.GeneratorPointTypes.Plant);

                playerManager.GetComponent<PlayerManager>().OnItemDestroy(this.gameObject);
            }

            else {
                raycastUICanvas.SetActive(false);
            }

        }


        /** 아이템이 항상 손에서 따라다님 **/
        transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(0, 0, 0), lerpPoint * Time.deltaTime);

        /** 아이템 장착 해제 **/
        if(OVRInput.GetDown(OVRInput.Button.Back) || Input.GetKeyDown(KeyCode.R)) {
            OnBackButtonClick();
        }
    }


    // 뒤로가기 버튼 클릭       
    public override void OnBackButtonClick() {
        base.OnBackButtonClick();
        Debug.Log("Potato!");
    }
}

