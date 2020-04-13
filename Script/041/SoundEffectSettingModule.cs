using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectSettingModule : SoundManageModule {

    // 변수               
    public bool triggerEnterON;     /** 트리거 진입 사운드 켜기 **/
    public bool triggerExitON;      /** 트리거 탈출 사운드 켜기 **/
    public bool collisionEnterON;   /** 충돌 진입 사운드 켜기 **/
    public bool collisionExitON;    /** 충돌 탈출 사운드 켜기 **/

    public bool naturalON;              /** 자연 사운드 켜기 (난수) **/
    public float minNaturalDelay = 5.0f;
    public float maxNaturalDelay = 10.0f;


    // 초기화              
    public override void Start2() {
        base.Start2();
        if (naturalON) 
            StartCoroutine(NaturalSound());
    }


    // 트리거 진입 사운드   
    private void OnTriggerEnter(Collider other) {
        if(triggerEnterON) AudioSourceComp.Play();
    }

    // 트리거 탈출 사운드   
    private void OnTriggerExit(Collider other){
        if(triggerExitON) AudioSourceComp.Play();
    }

    // 충돌 진입 사운드     
    private void OnCollisionEnter(Collision collision) {
        if (collisionEnterON) AudioSourceComp.Play();
    }


    // 충돌 탈출 사운드     
    private void OnCollisionExit(Collision collision) {
        if(collisionExitON) AudioSourceComp.Play();
    }

    // 자연 사운드          
    private IEnumerator NaturalSound() {

        while (true) {
            yield return new WaitForSeconds(Random.Range(minNaturalDelay, maxNaturalDelay));
            AudioSourceComp.Play();
            yield return null;
        }
    }


    // 외부 호출 사운드     
    public void PlaySound() { AudioSourceComp.Play(); }

}
