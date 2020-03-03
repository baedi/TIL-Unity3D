using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour {

    // 변수            
    private new AudioSource audio;

    public GameObject soundScrollbarObj;
    public AudioClip click;
    public AudioClip appear;
    public AudioClip disappear;
    public AudioClip error;


    // 초기화 1        
    private void Awake() {
        if(GetComponent<AudioSource>() == null) 
            this.gameObject.AddComponent<AudioSource>();
        
    }

    // 초기화 2        
    private void Start() {

        /** 컴포넌트 가져오기 **/
        audio = GetComponent<AudioSource>();

        /** 사운드 값 가져오기 **/
        float[] volumes = GetComponent<DatabaseManager>().GetVolumeSettings();
        if (volumes[1] == -0.1f) volumes[1] = 0.8f;

        /** 사운드 설정 **/
        if(soundScrollbarObj != null) {
            soundScrollbarObj.GetComponent<Scrollbar>().value = volumes[1];
            audio.volume = volumes[1];
        }

        else 
            audio.volume = volumes[1]; 
    }


    // 사운드 볼륨 조절          
    public void SetSoundVolume(float volume) {
        Debug.Log("Sound Vol : " + volume);
        audio.volume = volume;
    }

    // 이벤트용 사운드 볼륨 조절 
    public void SetSoundVolume(GameObject scrollObj) {
        audio.volume = scrollObj.GetComponent<Scrollbar>().value;
    }


    // 클릭 사운드           
    public void Sound_click() {
        try {
            audio.clip = click;
            audio.Play();
        }
        catch (NullReferenceException) { }
    }

    // 나타내기 사운드       
    public void Sound_appear() {
        audio.clip = appear;
        audio.Play();
    }

    // 숨기기 사운드         
    public void Sound_disappear() {
        audio.clip = disappear;
        audio.Play();
    }

    // 에러 사운드           
    public void Sound_error() {
        audio.clip = error;
        audio.Play();
    }

}
