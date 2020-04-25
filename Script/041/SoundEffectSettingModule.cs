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
        if (triggerEnterON) {
            PrepareAudioPlay();
            AudioSourceComp.Play();
        }
    }

    // 트리거 탈출 사운드   
    private void OnTriggerExit(Collider other){
        if(triggerExitON) {
            PrepareAudioPlay();
            AudioSourceComp.Play();
        }
    }

    // 충돌 진입 사운드     
    private void OnCollisionEnter(Collision collision) {
        if (collisionEnterON) {
            PrepareAudioPlay();
            AudioSourceComp.Play();
        }
    }


    // 충돌 탈출 사운드     
    private void OnCollisionExit(Collision collision) {
        if(collisionExitON) {
            PrepareAudioPlay();
            AudioSourceComp.Play();
        }
    }

    // 자연 사운드          
    private IEnumerator NaturalSound() {

        while (true) {
            yield return new WaitForSeconds(Random.Range(minNaturalDelay, maxNaturalDelay));
            PrepareAudioPlay();
            AudioSourceComp.Play();
            yield return null;
        }
    }


    // 외부 호출 사운드     
    public void PlaySound() {
        PrepareAudioPlay();
        AudioSourceComp.Play();
    }

    // 외부 호출 사운드 (선택 가능)    
    public void PlaySoundSelect(int index) {
        AudioSourceComp.clip = sound[index];
        AudioSourceComp.Play();
    }


    // 사운드 파일 수에 따라 난수를 이용하여 재생할 사운드 결정하기   
    public void PrepareAudioPlay() {

        int index = Random.Range(0, sound.Length); Debug.Log("Sound index : " + index);
        AudioSourceComp.clip = sound[index];
    }
}
