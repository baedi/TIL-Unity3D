using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryText : MonoBehaviour {

    // 변수           
    private Text textUi;
    private string[] storyText;
    private bool isWriting;
    private int currentIndex = -1;

    // 초기화         
    private void Start() {

        // 대사 설정        
        storyText = new string[3];
        storyText[0] = "Clean and polish neat and tidy.\nPillow Pillow Pillow!\nSopa Sopa Sopa...";
        storyText[1] = "Please to meet you Johnson.\n Oh Elena!\nHow are you doing?";
        storyText[2] = "You must be tired after long journey.\nSorry.. my english is very not good. ";

        // 컴포넌트 가져오기    
        textUi = GetComponentInChildren<Text>();
    }

    // 루프           
    private void Update() {
        
        // 방향키 -> 를 누를 경우 발생    
        if(Input.GetKeyDown(KeyCode.RightArrow) && !isWriting && currentIndex < storyText.Length - 1) {
            isWriting = true;
            currentIndex++;
            StartCoroutine(textDelay());
        }

        // 방향키 <- 를 누를 경우 발생    
        if(Input.GetKeyDown(KeyCode.LeftArrow) && !isWriting && currentIndex > 0) {
            isWriting = true;
            currentIndex--;
            StartCoroutine(textDelay());
        }

    }


    // 대사 코루틴    
    private IEnumerator textDelay() {

        textUi.text = "";

        for(int count = 0; count < storyText[currentIndex].Length; count++) {
            textUi.text += storyText[currentIndex][count];

            if (storyText[currentIndex][count].Equals(' ') || storyText[currentIndex][count].Equals('\n'))
                yield return new WaitForSeconds(0.15f);

            else
                yield return new WaitForSeconds(0.05f);
        }


        isWriting = false;
        yield return null;
    }
}
