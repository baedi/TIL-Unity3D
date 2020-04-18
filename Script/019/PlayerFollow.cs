using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour {

    //  변수              
    public GameObject target;                   /** 대상 오브젝트 **/

    private Vector3 targetPosition;
    private Quaternion targetQuaternion;
    private float mov_lerpPoint = 2f;
    private float rot_lerpPoint = 2f;
    private float distPoint = 1.5f;
    private float distDLine = 0.2f;


    // 초기화             
    private void Start() {

    }

    // 반복문              
    private void Update() {

        /** 타깃이 앞으로 보는 방향의 y축을 저장 **/
        float tempY = target.transform.forward.y;
        float divide;

        /** 타깃의 위치, 회전값을 이용하여 설정 **/
        targetPosition = target.transform.position + (new Vector3(target.transform.forward.x, 0, target.transform.forward.z) * distPoint);
        targetQuaternion = new Quaternion(0, target.transform.rotation.y, 0, target.transform.rotation.w);

        /** 타깃이 앞으로 보는 방향의 y축을 벗어날 경우 움직이지 않음 **/
        if (!(tempY < 0.3f && tempY >= -0.3f)) return;


        /** 플레이어가 바라보는 곳과 오브젝트의 거리차가 일정 미만인 경우 **/
        if (Vector3.Distance(transform.position, targetPosition) < 0.15f) divide = 12f;
        else if (Vector3.Distance(transform.position, targetPosition) < 0.5f) divide = 6f;
        else if (Vector3.Distance(transform.position, targetPosition) < 1f) divide = 3f;

        /** 플레이어가 바라보는 곳과 오브젝트의 거리차가 일정 이상인 경우 **/
        else divide = 1f;


        transform.position = Vector3.Lerp(transform.position, targetPosition, (mov_lerpPoint / divide) * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetQuaternion, rot_lerpPoint * Time.deltaTime);
    }
}
