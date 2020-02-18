using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SoundSetting : MonoBehaviour {

    // 변수               
    public GameObject musicBar;
    public GameObject musicPercent;
    public GameObject soundBar;
    public GameObject soundPercent;

    private Scrollbar musicScrollbar;
    private Text musicPercentText;
    private Scrollbar soundScrollbar;
    private Text soundPercentText;


    // 초기화              
    private void Start() {
        musicScrollbar = musicBar.GetComponent<Scrollbar>();
        musicPercentText = musicPercent.GetComponent<Text>();
        soundScrollbar = soundBar.GetComponent<Scrollbar>();
        soundPercentText = soundPercent.GetComponent<Text>();

        musicScrollbar.onValueChanged.AddListener(delegate { MusicValueChanged(); });
        soundScrollbar.onValueChanged.AddListener(delegate { SoundValueChanged(); });
    }


    // 상태값 변경 시 호출  
    private void MusicValueChanged() {
        musicPercentText.text = ((int)(musicScrollbar.value * 100)).ToString() + "%";
    }

    private void SoundValueChanged() {
        soundPercentText.text = ((int)(soundScrollbar.value * 100)).ToString() + "%";
    }
}
