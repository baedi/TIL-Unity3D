using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideContentBox {
    
    // 프로퍼티         
    public string TextBlock { get; private set; }
    public Texture ImageBlock { get; private set; }
    public ContentType BehaviourMode { get; private set; }

    public enum ContentType
    {
        Normal = 0, /** 일반 모드 **/
        Mission,    /** 미션 모드 **/
        Switching,  /** 검은 화면 전환 모드 **/
        Complete    /** 가이드 완료 모드 **/
    }


    // 생성자           
    /**
     * 인자1 : UI에 보일 텍스트
     * 인자2 : UI에 보일 이미지
     * 인자3 : 도구를 사용해야 하는 행동 모드인지 여부
     **/
    public GuideContentBox(string text, Texture image = null, ContentType behaviourType = ContentType.Normal) {
        TextBlock = text;
        ImageBlock = image;
        BehaviourMode = behaviourType;
    }
}
