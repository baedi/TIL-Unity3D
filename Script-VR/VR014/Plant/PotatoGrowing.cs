using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotatoGrowing : MonoBehaviour {

    //  변수                  
    private int maxLevel;
    private int level;
    private float yPosUp = 0.15f;


    //  초기화                 
    [System.Obsolete]
    private void Start() {
        maxLevel = transform.GetChildCount();
        level = 0;

        SetLevel(level);
    }


    // 레벨 상승               
    public void GrowLevelUp() {

        if(level == 0) {
            this.transform.position += (Vector3.up * yPosUp);
        }

        if(level < maxLevel - 1) {
            level++;
            SetLevel(level);
        }

    }


    // 레벨 하락                
    public void GrowLevelDown() {
        if(level == 1) {
            this.transform.position -= (Vector3.up * yPosUp);
        }

        if(level < maxLevel - 1) {
            level--;
            SetLevel(level);
        }
    }


    // 레벨 설정               
    private void SetLevel(int input_level) {

        if(level < maxLevel) {
            for(int index = 0; index < maxLevel; index++) {

                if (input_level == index)
                    transform.GetChild(index).gameObject.SetActive(true);

                else transform.GetChild(index).gameObject.SetActive(false);

            }
        }

    }

}
