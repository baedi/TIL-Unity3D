using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieZone : MonoBehaviour {

    // 변수        
    public GameObject spawnPoint;   // 스폰 오브젝트를 넣는 변수    
    private int dieCount;           // 죽은 횟수                    

    // 초기화      
    void Start() {
        dieCount = 0;               // 죽은 횟수 초기화             

        // 스폰 오브젝트가 아무것도 없는 경우 SpawnPoint라는 이름의 오브젝트를 찾음.   
        if (spawnPoint == null) spawnPoint = GameObject.Find("SpawnPoint");
    }

    // 트리거 감지될 경우 해당 오브젝트를 spawnPoint 위치에 보냄. 
    private void OnTriggerEnter(Collider other) {

        dieCount++;     // 죽은 횟수 1 증가   

        // 스폰 포인터로 이동시킨다.                   
        other.gameObject.transform.SetPositionAndRotation(
            new Vector3(spawnPoint.transform.position.x,
                        spawnPoint.transform.position.y,
                        spawnPoint.transform.position.z),
            new Quaternion());

        Debug.Log("Die count : " + dieCount);
    }
}
