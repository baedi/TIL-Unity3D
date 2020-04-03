using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotatoGrowing : MonoBehaviour {

    //  변수                  
    private int maxLevel;
    private int level;


    //  초기화                 
    [System.Obsolete]
    private void Start() {
        maxLevel = transform.GetChildCount();
        level = 0;

        SetLevel(level);
        StartCoroutine(TestGrow());
    }


    // 레벨 상승               
    public void GrowLevelUp() {

        if(level < maxLevel - 1) {
            level++;
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


    /** 테스트용 **/
    private IEnumerator TestGrow() {
        for(int index = 0; index < 4; index++) {
            yield return new WaitForSeconds(5);
            GrowLevelUp();
            yield return null;
        }

        yield return null;
    }
}
