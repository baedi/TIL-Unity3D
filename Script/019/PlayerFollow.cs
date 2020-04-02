using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour {

    //  변수              
    public GameObject target;
    private float lerpPoint = 0.4f;
    private float distPoint = 3f;
    private float distDLine = 0.2f;

    // 초기화             
    private void Start() {
        transform.position = target.transform.position + (target.transform.forward * distPoint);
    }

    // 반복문              
    private void Update() {
        float distance = Vector3.Distance(transform.position, target.transform.position);
        Debug.Log(distance);

        /** 일정 거리를 벗어날 경우 이동 **/
        if (distance < (distPoint - distDLine) || distance > (distPoint + distDLine)) {
            transform.position = Vector3.Lerp(transform.position, target.transform.position + (target.transform.forward * distPoint), lerpPoint * Time.deltaTime);
        }
    }
}
