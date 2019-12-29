using UnityEngine;

public class CollisionMove2 : MonoBehaviour {

    // 변수                                     
    private Vector3 colValue;           // 충돌 좌표    
    private new Rigidbody rigidbody;    // 리지드바디   

    // 물체와 충돌 시 호출                      
    private void OnCollisionEnter(Collision collision) {
        colValue = collision.impulse;
        rigidbody = GetComponent<Rigidbody>();
    }

    // 충돌 이후 물체와 계속 붙어있는 경우      
    private void OnCollisionStay(Collision collision) {

        // 충돌 대상이 플레이어 태그를 가진 오브젝트인 경우      
        if (collision.gameObject.CompareTag("Player")) {
            rigidbody.AddForce(-colValue * 4, ForceMode.Impulse);
        }
    }
}
