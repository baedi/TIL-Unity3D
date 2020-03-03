using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour {

    // 변수            
    private new AudioSource audio;

    public GameObject mainManager;
    public GameObject musicScrollbarObj;
    public AudioClip bgm;


    // 초기화 1        
    private void Awake() {
        if (GetComponent<AudioSource>() == null)
            this.gameObject.AddComponent<AudioSource>();
    }

    // 초기화 2        
    private void Start() {

        /** 컴포넌트 가져오기 **/
        audio = GetComponent<AudioSource>();

        /** BGM 값 가져오기 **/
        float[] volumes = mainManager.GetComponent<DatabaseManager>().GetVolumeSettings();
        if (volumes[0] == -0.1f) volumes[0] = 0.8f;

        /** 음악 설정 **/
        if(musicScrollbarObj != null) {
            musicScrollbarObj.GetComponent<Scrollbar>().value = volumes[0];
            audio.volume = volumes[0];
        }

        else 
            audio.volume = volumes[0];

        /** BGM 삽입, 반복 설정 및 플레이 **/
        audio.clip = bgm;
        audio.loop = true;
        audio.Play();
    }


    // BGM 볼륨 조절            
    public void SetMusicVolume(float volume) {
        Debug.Log("Music Vol : " + volume);
        audio.volume = volume;
    }

    // 이벤트용 BGM 볼륨 조절   
    public void SetMusicVolume(GameObject scrollObj) {
        audio.volume = scrollObj.GetComponent<Scrollbar>().value;
    }
}
