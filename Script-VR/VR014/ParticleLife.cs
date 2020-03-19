using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleLife : MonoBehaviour {

    // 변수                    
    private new ParticleSystem particleSystem;

    // 초기화                  
    private void Start() {
        particleSystem = GetComponentInChildren<ParticleSystem>();
    }

    // 반복문                  
    private void Update() {
        if (particleSystem.isStopped) Destroy(this);
    }
}
