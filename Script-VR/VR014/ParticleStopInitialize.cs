using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * 파티클이 적용된 오브젝트 전용 스크립트.
 * 처음 시작 시 파티클이 재생되기 싫을 경우 사용됨.
 **/
public class ParticleStopInitialize : MonoBehaviour {

    // 초기화                  
    private void Start() {
        GetComponentInChildren<ParticleSystem>().Stop();
    }
}
