using UnityEngine;

/**
 * PotatoGrowing.cs (HarvestPalnt 상속 받음)
 * 
 * 식물 감자 전용 프리팹에 이 스크립트를 적용함.
**/
public class PotatoGrowing : HarvestPlant {

    /** 변수 **/
    public GameObject bugPrefab;


    /** 식물 성장 레벨 올리기 (오버라이드) **/
    public override void GrowLevelUp() {
        base.GrowLevelUp();

        if(CurLevel == 0) {
            this.transform.position += (Vector3.up * 0.15f);
        }

        else if(CurLevel == 2) {
            GetComponent<Collider>().enabled = true;
        }
    }


    /** 해충 생성(1레벨 전용) **/
    public void CreateBugs_LV1() {
        /** 생성 지점 초기화 **/
        Vector3[] bugPosition = new Vector3[3];
        Vector3[] bugRotation = new Vector3[3];

        bugPosition[0] =  new Vector3(-0.00486f, 0.0924f, -0.0023f);
        bugRotation[0] =  new Vector3(15f, 0f, 0f);
        bugPosition[1] =  new Vector3(-0.006f, 0.1061f, -0.0094f);
        bugRotation[1] =  new Vector3(15f, 90f, 0f);
        bugPosition[2] =  new Vector3(0.0119f, 0.0977f, -0.0036f);
        bugRotation[2] =  new Vector3(8f, 180f, 0f);

        int rand = Random.Range(1, 4);
        for(int count = 0; count < rand; count++) {
            GameObject obj = Instantiate(bugPrefab);
            obj.transform.parent = this.transform;
            obj.transform.localPosition = bugPosition[count];
            obj.transform.localEulerAngles = bugRotation[count];
        }
    }

}
