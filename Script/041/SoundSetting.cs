using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SoundSetting : MonoBehaviour {

    // 변수               
    public GameObject musicManager;
    public GameObject musicBar;
    public GameObject musicPercent;
    public GameObject soundManager;
    public GameObject soundBar;
    public GameObject soundPercent;

    private AudioSource musicSource;
    private Scrollbar musicScrollbar;
    private Text musicPercentText;
    private AudioSource soundSource;
    private Scrollbar soundScrollbar;
    private Text soundPercentText;


    // 초기화              
    private void Awake() {

        // 컴포넌트 가져옴     
        musicSource = musicManager.GetComponent<AudioSource>();
        soundSource = soundManager.GetComponent<AudioSource>();

        musicScrollbar = musicBar.GetComponent<Scrollbar>();
        musicPercentText = musicPercent.GetComponent<Text>();
        soundScrollbar = soundBar.GetComponent<Scrollbar>();
        soundPercentText = soundPercent.GetComponent<Text>();

        // 리스너 설정(스크롤바의 값이 변경되면 아래 메서드들이 호출됨)   
        musicScrollbar.onValueChanged.AddListener(delegate { MusicValueChanged(); });
        soundScrollbar.onValueChanged.AddListener(delegate { SoundValueChanged(); });
    }


    // 상태값 변경 시 호출  
    public void MusicValueChanged() {
        musicPercentText.text = ((int)(musicScrollbar.value * 100)).ToString() + "%";
        musicSource.volume = musicScrollbar.value;
    }

    public void SoundValueChanged() {
        soundPercentText.text = ((int)(soundScrollbar.value * 100)).ToString() + "%";
        soundSource.volume = soundScrollbar.value;
    }
}
