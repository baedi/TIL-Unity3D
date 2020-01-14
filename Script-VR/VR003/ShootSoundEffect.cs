using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSoundEffect : MonoBehaviour {

    // 변수        
    public float liveTime = 3.0f;

    // 초기화      
    private void Awake() {
        StartCoroutine(liveCoroutine());
    }

    // 코루틴      
    private IEnumerator liveCoroutine() {
        yield return new WaitForSeconds(liveTime);
        Destroy(this.gameObject);
    }
}
