using UnityEngine;

/**
 * HarvestPlants.cs
 * 
 * 모든 재배 식물 프리팹을 위한 부모 클래스.
 * 재배 식물 프리팹이 가진 기본적인 요소(식물 성장, 성장 설정)을 구성함.
 * 
 * 실제 작물 프리팹에서 이 기능 적용하려고 할 경우 이 클래스를 상속받는 자식 클래스(컴포넌트)를 넣어주어야 함.
**/
public class HarvestPlant : MonoBehaviour {

    /** 프로퍼티 **/
    public int MaxLevel { get; protected set; }         // 최대 성장 레벨     
    public int CurLevel { get; set; } = 0;              // 현재 성장 레벨     
    public bool IsSavingEnable { get; set; } = false;   // DB 저장가능 여부   


    /** 초기화 **/
    [System.Obsolete]
    private void Start() {
        
        MaxLevel        = transform.GetChildCount();   // 해당 스크립트를 적용한 식물 프리팹의 자식 오브젝트 개수에 따라 최대 레벨 결정.

        SetLevel(CurLevel);
    }


    /** 식물 성장 레벨 올리기 **/
    public virtual void GrowLevelUp() {

        // 최대 레벨 -1 보다 현재레벨이 낮아야 성장 가능.  
        if (CurLevel < MaxLevel - 1) {
            CurLevel++;
            SetLevel(CurLevel);
        }
    }


    /** 식물 성장 레벨 임의 설정하기 **/
    public virtual void SetLevel(int input_level) {

        // 현재 레벨이 최대 레벨보다 작을 경우 첫번째 인자의 인덱스 값에 해당하는 식물 오브젝트만 보여준다.
        if (CurLevel < MaxLevel) {
            for (int index = 0; index < MaxLevel; index++) {

                if (input_level == index)
                    transform.GetChild(index).gameObject.SetActive(true);

                else transform.GetChild(index).gameObject.SetActive(false);

            }
        }
    }
    
}
