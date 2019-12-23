using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpFloor_B : MonoBehaviour
{
    // 변수             
    private float jumpPlus = 0.3f;          // 점프 증가량   
    private const float MINUS_MUX = 2.0f;   

    // 물체 충돌 감지   
    private void OnCollisionEnter(Collision collision) {
        float imp = collision.impulse.y;    // y축 가변(충돌)값 가져옴.  
        Debug.Log("Impluse Y : " + imp);    // 충돌값 표시               

        // 스페이스 바를 누르면 콩콩이 점프력이 증가함.        
        if (Input.GetKey(KeyCode.Space))
            collision.rigidbody.AddForce((Vector3.up * (imp + jumpPlus)), ForceMode.Impulse);

        // 왼쪽 쉬프트 키를 누르면 콩콩이 점프력이 감소함.      
        else if (Input.GetKey(KeyCode.LeftShift))
            collision.rigidbody.AddForce((Vector3.up * (imp - (jumpPlus * MINUS_MUX))), ForceMode.Impulse);

        // 어느 것도 누르지 않았을 경우                         
        else
            collision.rigidbody.AddForce((Vector3.up * imp), ForceMode.Impulse);

    }
}
