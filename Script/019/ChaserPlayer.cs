using UnityEngine;

public class ChaserPlayer : MonoBehaviour {

    // 변수                               
    private float moveSpeed = 2.0f;
    private float maxDistance = 3.0f;
    private float rotateSpeed = 10f;

    // 대상이 트리거에 계속 머무를 경우   
    private void OnTriggerStay(Collider other) {

        // 트리거에 감지된 대상이 플레이어일 경우        
        if (other.gameObject.CompareTag("Player")) {

            // 플레이어를 바라보게 하기 위한 연산                
            Vector3 dir = other.transform.position - transform.position;

            // 플레이어를 바라보게 할 때 부드럽게 전환하도록 함. 
            transform.rotation = 
                Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), rotateSpeed * Time.deltaTime);


            // 플레이어를 계속 바라보게 함.             
            //transform.LookAt(other.transform);

            // 플레이어와의 거리가 가깝지 않을 경우     
            Debug.Log(Vector3.Distance(transform.position, other.transform.position));
            if (Vector3.Distance(transform.position, other.transform.position) >= maxDistance)
                transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }

    }
}
