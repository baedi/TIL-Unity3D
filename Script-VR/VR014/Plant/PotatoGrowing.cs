using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotatoGrowing : MonoBehaviour {

    //  변수                  
    public GameObject[] potatoPrefab;

    private int level;


    //  초기화                 
    private void Start() {
        level = 0;
        SetLevel(level);
    }


    // 레벨 상승               
    public void GrowLevelUp() {

        if(level < potatoPrefab.Length - 1) {
            level++;
            SetLevel(level);
        }

    }


    // 레벨 설정               
    private void SetLevel(int input_level) {

        if(level < potatoPrefab.Length) {
            for(int index = 0; index < potatoPrefab.Length; index++) {
                if (input_level == index)
                    potatoPrefab[index].SetActive(true);

                else potatoPrefab[index].SetActive(false);
            }
        }

    }

}
