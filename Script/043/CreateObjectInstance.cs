using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObjectInstance : MonoBehaviour {

    /** 변수 **/
    public int createCount = 100;

    /** 초기화 **/
    private void Start() {

        // 빈 오브젝트 생성 및 초기화  
        for(int count = 0; count < createCount; count++) {
            GameObject obj = new GameObject();
            obj.name = (count + 1).ToString();

            switch (Random.Range(0, 3)) {
                case 0: obj.AddComponent<TestChild1>(); break;
                case 1: obj.AddComponent<TestChild2>(); break;
                default: obj.AddComponent<TestChild3>(); break;
            }
        }

        Debug.Log("Create GameObject...");


        // TestChild1,2,3, TestParent 컴포넌트를 가진 모든 Obj 찾아보기
        TestChild1[] temp1 = GameObject.FindObjectsOfType<TestChild1>();
        TestChild2[] temp2 = GameObject.FindObjectsOfType<TestChild2>();
        TestChild3[] temp3 = GameObject.FindObjectsOfType<TestChild3>();
        TestParent[] tempP = GameObject.FindObjectsOfType<TestParent>();

        string tempStr1 = "";
        string tempStr2 = "";
        string tempStr3 = "";
        string tempStrP = "";

        Debug.Log("[temp1] EA : " + temp1.Length); foreach (TestChild1 obj in temp1) { tempStr1 += (obj.name + " "); }
        Debug.Log(tempStr1);

        Debug.Log("[temp2] EA : " + temp2.Length); foreach (TestChild2 obj in temp2) { tempStr2 += (obj.name + " "); }
        Debug.Log(tempStr2);

        Debug.Log("[temp3] EA : " + temp3.Length); foreach (TestChild3 obj in temp3) { tempStr3 += (obj.name + " "); }
        Debug.Log(tempStr3);

        Debug.Log("[tempP] EA : " + tempP.Length); foreach (TestParent obj in tempP) { tempStrP += (obj.name + " "); ; }
        Debug.Log(tempStrP);
    }

}
