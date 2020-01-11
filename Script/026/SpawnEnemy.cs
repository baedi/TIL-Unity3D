using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour {

    // 변수            
    public GameObject enemyPrefab;      // 적 프리팹    

    private float trigSizeX;
    private float trigSizeZ;

    private float randX;
    private float randZ;


    // 초기화          
    void Start() {
        BoxCollider tempBoxCol = GetComponent<BoxCollider>();
        trigSizeX = tempBoxCol.size.x / 2f;
        trigSizeZ = tempBoxCol.size.z / 2f;

        StartCoroutine(instantEnemy());
    }


    // 코루틴 함수     
    // 2~5초 간격으로 랜덤한 위치에 적 생성       
    private IEnumerator instantEnemy() {

        // 무한루프         
        while (true) {

            // 생성 위치 X,Z축 난수 생성 
            randX = Random.Range(transform.position.x - trigSizeX, transform.position.x + trigSizeX);
            randZ = Random.Range(transform.position.z - trigSizeZ, transform.position.z + trigSizeZ);

            // 프리팹 복제               
            Instantiate(enemyPrefab, new Vector3(randX, transform.position.y, randZ), Quaternion.identity);

            // 2~5초 뒤 리턴             
            yield return new WaitForSeconds(Random.Range(2, 5));
        }

    }
}
