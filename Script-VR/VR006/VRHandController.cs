using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * HandModel 프리팹 전용 스크립트.
 * 아이템을 감지하고, 착용을 위해 사용함.
 **/
public class VRHandController : MonoBehaviour {

    // 변수                
    public GameObject raycastUICanvas;
    public float raycastDistance = 1.5f;

    private Transform cameraTransform;
    private RaycastHit raycastHit;
    private GameObject raycastHitGameObject;


    // 초기화              
    private void Start() {
        /** UI 비활성화 **/
        raycastUICanvas.SetActive(false);

        /** VR 카메라의 transform을 가져옴 **/
        cameraTransform = GetComponentInParent<OVRCameraRig>().gameObject.transform;
    }

    // 반복문              
    private void Update() {

        /** 충돌 감지 **/
        Debug.DrawRay(transform.position, transform.forward * raycastDistance, Color.blue, 0.5f);

        /** 충돌 확인 **/
        if(Physics.Raycast(transform.position, transform.forward, out raycastHit, raycastDistance)
            && gameObject.activeInHierarchy) {

            raycastHitGameObject = raycastHit.collider.gameObject;

            /** 감지된 물체가 아이템이고 트리거 버튼 누르면 장착 **/
            if(raycastHitGameObject.CompareTag("Item") && 
                (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) || Input.GetKeyDown(KeyCode.E))){
                raycastUICanvas.SetActive(false);

                /** 감지된 아이템을 장착함. **/
                GetComponentInParent<PlayerManager>().OnItemEquip(raycastHitGameObject);
            }

            /** 감지된 물체가 아이템일 경우 UI 표시 **/
            else if (raycastHitGameObject.CompareTag("Item")) {
                raycastUICanvas.GetComponentInChildren<Text>().text = "선택";
                raycastUICanvas.transform.LookAt(cameraTransform.position);                
                raycastUICanvas.transform.position = raycastHitGameObject.transform.position + (Vector3.up * 0.5f);
                raycastUICanvas.SetActive(true);
            }

            /** 감지된 물체가 CatchItem 태그를 가진 아이템일 때 트리거 버튼을 누른 상태면 옮기기 가능 **/
            else if (raycastHitGameObject.CompareTag("CatchItem") && 
                (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) || Input.GetKey(KeyCode.E))) {
                raycastHitGameObject.transform.position = 
                    Vector3.Lerp(raycastHitGameObject.transform.position, transform.position + (transform.forward * raycastDistance), 0.2f);

                raycastHitGameObject.transform.rotation =
                    new Quaternion(0, raycastHitGameObject.transform.rotation.y, 0, raycastHitGameObject.transform.rotation.w);
            }

            else {
                raycastUICanvas.SetActive(false);
            }
        }

        else {
            raycastUICanvas.SetActive(false);
        }
    }
}
