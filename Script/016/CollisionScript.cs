using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour {

    // 변수                   
    private float collisionLowPower = 0.3f;


    // 충돌 발생 시          
    private void OnCollisionEnter(Collision collision) {

        // 충돌한 오브젝트의 Bullet 컴포넌트를 가져옴   
        Bullet temp = collision.gameObject.GetComponent<Bullet>();

        // 발사 원점 위치를 가져옴                      
        Vector3 startPos = temp.getStartPos();

        /*
        // 입사각의 반대 백터를 구함 (발사 지점 - 충돌 지점)       
        Vector3 relativePosition = startPos - collision.transform.position;
        */

        // 입사각 구하기 (충돌 지점 - 발사 지점)      
        Vector3 incomingVector = collision.transform.position - startPos;

        // 입사각의 반대각 구하기                     
        Vector3 inverseVector = -incomingVector;

        // 법선벡터 구하기                            
        Vector3 normalVector = collision.contacts[0].normal;

        // 반사각 구하기                              
        Vector3 reflectVector = Vector3.Reflect(incomingVector, normalVector);

        // 반사각을 이용하여 발사체가 반사되어 튕겨나가도록 함.    
        collision.rigidbody.AddForce(reflectVector * collisionLowPower, ForceMode.Impulse);
    }
}
