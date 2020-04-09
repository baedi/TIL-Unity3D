using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * 가상현실용 플레이어 이동 스크립트
 * 앞으로 제끼기 범위 : 290 ~ 310
 * 뒤로 제끼기 범위 : 40 ~ 60
 **/ 
public class VRPlayerMove : MonoBehaviour {

    public GameObject focusPosition;
    public GameObject rightHandAnchor;
    private float movingSpeed = 1.2f;
    private bool isControlFront = false;

    // 루프                 
    private void Update() {

        /** 앞으로 제낀 이후 뒤로 제낀 경우 **/
        if (!isControlFront &&
            rightHandAnchor.transform.eulerAngles.x > 290f &&
            rightHandAnchor.transform.eulerAngles.x < 310f && 
            OVRInput.Get(OVRInput.Button.One)) {
            isControlFront = !isControlFront;
            StopAllCoroutines();
            StartCoroutine(Moving());

        }

        /** 뒤로 제낀 이후 앞으로 제낄 경우 **/
        else if(isControlFront &&
            rightHandAnchor.transform.eulerAngles.x > 40f &&
            rightHandAnchor.transform.eulerAngles.x < 60f &&
            OVRInput.Get(OVRInput.Button.One)) {
            isControlFront = !isControlFront;
            StopAllCoroutines();
            StartCoroutine(Moving());
        }
    }

    private IEnumerator Moving() {
        for (int count = 0; count < 20; count++) {
            transform.Translate(focusPosition.transform.forward * movingSpeed * Time.deltaTime);
            yield return new WaitForSeconds(0.03f);
        }

        yield return null;
    }
}
