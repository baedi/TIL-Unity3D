using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyMove : MonoBehaviour {

    // 변수               
    public float moveSpeed = 2f;                    // 적 이동속도            
    public float rotateSpeed = 3f;                  // 적 회전속도            

    private GameObject[] checkPoint;                // 체크포인트             
    private int nextMovePoint = -1;                 // 다음 체크포인트 인덱스 
    private string triggerName = "MovePoint";       // 트리거 오브젝트 이름   

    private Vector3 targetVector;

    // 초기화              
    private void Awake() {
        checkPoint = new GameObject[5];

        for(int count = 0; count < checkPoint.Length; count++) {
            checkPoint[count] = GameObject.Find(triggerName + (count + 1));
        }

        // 초기 체크포인트 설정      
        nextCheckPointSet();
    }

    // 루프                 
    private void FixedUpdate() {
        
        // 부드럽게 회전하기            
        Vector3 lookVec = targetVector - transform.position;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(lookVec), rotateSpeed * Time.deltaTime);

        // 이동하기                     
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        //transform.position = Vector3.MoveTowards(transform.position, targetVector, moveSpeed * Time.deltaTime);

        // 체크포인트 근처에 도착했는지 여부       
        if (Vector3.Distance(transform.position, targetVector) < 1.0f) 
            nextCheckPointSet();
        
    }

    private void nextCheckPointSet() {
        nextMovePoint++;

        Vector3 triggerSize;
        try {
            triggerSize = checkPoint[nextMovePoint].GetComponent<BoxCollider>().size / 2.0f;
        }

        catch (IndexOutOfRangeException) { return; }


        float randX = UnityEngine.Random.Range(checkPoint[nextMovePoint].transform.position.x + (-triggerSize.x),
                                    checkPoint[nextMovePoint].transform.position.x + triggerSize.x);

        float randZ = UnityEngine.Random.Range(checkPoint[nextMovePoint].transform.position.z + (-triggerSize.z),
                                    checkPoint[nextMovePoint].transform.position.z + triggerSize.z);

        targetVector = new Vector3(randX, checkPoint[nextMovePoint].transform.position.y, randZ);

    }
}
