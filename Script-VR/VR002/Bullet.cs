using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // 변수           
    private new Rigidbody rigidbody;
    private float power = 30000;

    public int lifeTime = 5;

    // Start is called before the first frame update
    void Start() {
        rigidbody = GetComponent<Rigidbody>();

        rigidbody.AddForce(transform.forward * power * Time.deltaTime, ForceMode.Impulse);
        StartCoroutine(bulletLifeTime());
    }

    // 일정 시간이 지나면 오브젝트를 파괴하는 코루틴 함수 
    private IEnumerator bulletLifeTime() {
        yield return new WaitForSeconds(lifeTime);
        Destroy(this.gameObject);
    }

    // 총알이 적의 충돌을 감지할 경우                     
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) {
            collision.gameObject.GetComponent<EnemyMove>().hitEnemy();
        }

        Destroy(this.gameObject);
    }

}
