using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * 제너레이터의 각 꼭짓점(meshPoint)을 위한 스크립트
 * TriggerCube 오브젝트를 만들어서 BoxCollider를 만들고 트리거는 활성화시킴.
 * MeshGenerator 관련 스크립트에 의해서 TriggerCube가 생성될 때 이 스크립트가 작동함.
 **/
public class TriggerGenerator : MonoBehaviour {

    // 열거형              
    public enum GeneratorPointTypes {
        Normal, /** 일반 포인트 (아무 효과 없음) ...trig_normal **/
        Soil,   /** 비료 감지용  ...trig_soil **/
        Dig,    /** 일반 모종 삽으로 땅을 팔 수 있는 포인트 ...trig_dig **/
        Lowdig, /** 호미로 땅을 팔 수 있는 포인트 ...trig_homiedig **/
        Plant   /** 작물을 심을 수 있는 포인트 ...col_plant **/ 
    }

    // 변수                
    private int meshPointIndex;
    private Vector3[] meshPoint;                /** 메쉬 포인트 주소 **/
    private GeneratorPointTypes triggerType;    /** 트리거 유형 **/
    private GameObject meshGeneratorObj;        /** 메쉬 제네레이터 전용 오브젝트 **/

    private int effcectCount = 0;       /** 트리거 or 충돌 발생 시 하나씩 깎임. (0이 되면 Normal 상태로 변경 필요) **/
    private float effectValueY = 0.0f;  /** 트리거 or 충돌 발생 시 해당 수치만큼의 y축(높이)에 값 변화 발생 **/

    public Material normal_mat;         /** Material 전용 변수 **/
    public Material soil_mat;
    public Material dig_mat;
    public Material lowdig_mat;
    public Material plant_mat;


    // 트리거 설정 초기화  (무조건 노말 형태로 초기화됨)
    public void GeneratorInitialize(Vector3[] meshPointPointer, int index){

        /** 참고 : 오브젝트 생성은 외부에서 이루어져야 됨 **/
        /** 이 트리거 오브젝트는 메쉬 제너레이터 오브젝트의 자식이 됨 **/
        meshGeneratorObj = GameObject.Find("Soil");
        transform.parent = meshGeneratorObj.transform;

        /** 매쉬 지점을 가져오고 위치 및 크기를 설정함 **/
        this.meshPoint = meshPointPointer;
        this.meshPointIndex = index;
        transform.localPosition = meshPoint[index];
        transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

        /** 태그 설정 **/
        triggerType = GeneratorPointTypes.Normal;
        GetComponent<MeshRenderer>().material = normal_mat;
        this.gameObject.tag = "trig_normal";
    }

    // 유형 변경                     
    public void ChangeType(GeneratorPointTypes changeType, int addCount, float addEffValueY) {
        /** 변경 유형에 따라 각각 다른 효과 부여 **/

        switch (changeType) {
            /** 일반 **/
            case GeneratorPointTypes.Normal:
                gameObject.tag = "trig_normal";
                effcectCount = 0;
                effectValueY = 0.0f;
                break;

            /** 흙 **/
            case GeneratorPointTypes.Soil:
                break;

            /** 삽질 가능 **/
            case GeneratorPointTypes.Dig:
                break;

            /** 작은 삽질 가능 **/
            case GeneratorPointTypes.Lowdig:
                break;

            /** 심기 가능 **/
            case GeneratorPointTypes.Plant:
                break;
        }
    }


    // 땅 높이 설정                  
    public void SetTransformY(float addValue) {
        meshPoint[meshPointIndex].y += addValue;
        transform.localPosition = meshPoint[meshPointIndex];
    }
}
