using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRControllerForward : MonoBehaviour {

    // 변수                
    private GameObject leftHandController;
    private Vector3 originalPosition;

    public float speed = 5f;
    public float length = 0.5f;

    // 초기화              
    void Start() {
        leftHandController = GameObject.Find("OVRControllerPrefab");
        originalPosition = new Vector3(0, 0, 0);
    }

    // 루프                
    void Update() {
        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger)) {

            leftHandController.transform.localPosition =
                Vector3.Lerp(leftHandController.transform.localPosition,
                             originalPosition + (Vector3.forward * length),
                             speed * Time.deltaTime);
        }

        else {
            if(originalPosition != leftHandController.transform.localPosition) {
                leftHandController.transform.localPosition =
                    Vector3.Lerp(leftHandController.transform.localPosition,
                                 originalPosition,
                                 speed * Time.deltaTime);
            }
        }
    }
}
