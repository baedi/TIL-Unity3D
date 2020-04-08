using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/** 가이드 매니저
 *  이 클래스는 부모 클래스임. 가이드용 UI에 사용(해당 작물 가이드에 맞는 자식 클래스 이용)
 **/
public class GuideManager : MonoBehaviour {

    //  변수                   
    public GuideContentBox[] content;   /** 콘텐츠 박스 **/ 
    private int page;                   /** 페이지 **/
    private bool nextPageEnable;

    // 가이드 시작 전용 메소드    
    public void GuideStart() {

        /** 페이지 초기화 및 코루틴 동작 **/
        page = 0;
        nextPageEnable = false;
        StartCoroutine(GuideStartCoroutine());

    }

    public void NextGuidePage(){

    }





    // 가이드 시작 전용 코루틴    
    private IEnumerator GuideStartCoroutine() {
        yield return new WaitForSeconds(2f);

        this.gameObject.SetActive(true);
        StartCoroutine(ReadText());
    }

    // 텍스트 읽기 코루틴         
    private IEnumerator ReadText() {

        Text guideTextInput = GetComponentInChildren<Text>();
        guideTextInput.text = " ";

        /** 반복문 **/
        for(int count = 0; count < content[page].TextBlock.Length; count++) {
            guideTextInput.text += content[page].TextBlock[count];

            /** 텍스트 딜레이 **/
            if (content[page].TextBlock[count].Equals(' ') || content[page].TextBlock[count].Equals('\n'))
                yield return new WaitForSeconds(0.15f);

            else yield return new WaitForSeconds(0.05f);
        }

        /** 반복문 끝나면 다음 페이지 넘어가기 허용하도록 함. **/
        nextPageEnable = true;
    }
}
