using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDieEffect : MonoBehaviour {

    // 변수        
    private new Rigidbody rigidbody;

    public float liveLifeTime = 10f;        // 생존 시간             
    public float dieLifeTime = 10f;         // 시체 유지 시간        
    public float destroyLifeTime = 5f;       // 오브젝트 파괴 전 시간 

    // 초기화      
    private void Start() {

        // 컴포넌트 추가      
        rigidbody = gameObject.AddComponent<Rigidbody>();
        rigidbody.freezeRotation = true;

        // 코루틴 동작        
        StartCoroutine(LifeManager());
    }


    // 코루틴 함수 
    private IEnumerator LifeManager() {

        // 생존 지속시간                  
        for (int times = 0; times < liveLifeTime; times++)
            yield return new WaitForSeconds(1f);

        // 생존 시간 지나면 사망 처리     
        rigidbody.freezeRotation = false;
        transform.eulerAngles = new Vector3(1f, 0, 0);

        // 시체 지속시간                  
        for(int times = 0; times < dieLifeTime; times++)
            yield return new WaitForSeconds(1f);

        // 시체 지속시간 지나면 처리      
        rigidbody.drag = 20f;
        gameObject.GetComponentInChildren<Collider>().isTrigger = true;

        // 오브젝트 파괴 전 지속시간      
        for (int times = 0; times < destroyLifeTime; times++)
            yield return new WaitForSeconds(1f);

        // 지속시간 지나면 파괴           
        Destroy(this.gameObject);
        yield return null;
    }
}
