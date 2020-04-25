using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** 사운드 관리 모듈
 *  - 유형 : 부모 클래스
 *  - 설명 : 원하는 사운드를 넣고 외부 스크립트를 이용하여 조절하기 위한 스크립트
 **/
public class SoundManageModule : MonoBehaviour {

    // 변수                
    public GameObject mainManager;          /** 메인 매니저 오브젝트 **/
    public AudioClip[] sound;               /** 사운드 파일 **/
    public AudioSource AudioSourceComp{
        get; private set; }
    public bool is2DSound;


    // 초기화              
    private void Start() {

        /** 오디오소스 컴포넌트 생성 **/
        if (GetComponent<AudioSource>() == null)
            this.gameObject.AddComponent<AudioSource>();

        /** 사운드 볼륨 설정 **/
        if(mainManager == null) { mainManager = GameObject.Find("MainManager"); }
        float[] volumes = mainManager.GetComponent<DatabaseManager>().GetVolumeSettings();
        if (volumes[1] == -0.1f) volumes[1] = 0.8f;

        /** 사운드 설정 **/
        AudioSourceComp = GetComponent<AudioSource>();
        AudioSourceComp.playOnAwake = false;
        AudioSourceComp.spatialBlend = is2DSound ? 0.0f : 1.0f;
        AudioSourceComp.volume = volumes[1];

        Start2();
    }

    public virtual void Start2() { }


    // 볼륨 값 변경          
    public void ChangeVolume(float volume) {
        AudioSourceComp.volume = volume;
    }

}
