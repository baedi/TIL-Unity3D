using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRRotateControl : MonoBehaviour {

    // 변수        
    private Transform centerEyeAnchor;
    private Transform ovrCameraRig;
    //public float rotateSpeed = 6f;


    // 초기화      
    private void Awake() {
        centerEyeAnchor = 
            GameObject.Find("CenterEyeAnchor").GetComponent<Transform>();

        ovrCameraRig =
            GameObject.Find("OVRCameraRig").GetComponent<Transform>();
    }


    // 반복문      
    private void Update() {

        if(centerEyeAnchor.localRotation.x >= 0) {
            ovrCameraRig.localPosition = new Vector3(ovrCameraRig.localPosition.x, -(centerEyeAnchor.localRotation.x / 2f), ovrCameraRig.localPosition.z);
        }


        /*
        if(centerEyeAnchor.eulerAngles.x > 0 && centerEyeAnchor.eulerAngles.x <= 90) {
            transform.rotation = Quaternion.Lerp(transform.rotation, centerEyeAnchor.rotation, rotateSpeed * Time.deltaTime);
        }

        else {
            transform.rotation = Quaternion.Lerp(transform.rotation, new Quaternion(0, transform.rotation.y, transform.rotation.z, transform.rotation.w), rotateSpeed * Time.deltaTime);
        }
        */

        //transform.rotation = Quaternion.Lerp(transform.rotation, centerEyeAnchor.rotation, rotateSpeed * Time.deltaTime);

        //transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(centerEyeAnchor.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z), rotateSpeed * Time.deltaTime);
    }
}
