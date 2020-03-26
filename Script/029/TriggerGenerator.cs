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

    private int effectCount = 0;       /** 트리거 or 충돌 발생 시 하나씩 깎임. (0이 되면 Normal 상태로 변경 필요) **/
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

        /** 리지드바디 설정 **/
        this.gameObject.AddComponent<Rigidbody>().useGravity = false;
    }

    // 유형 변경                     
    public void ChangeType(GeneratorPointTypes changeType, int addCount, float addEffValueY) {
        /** 변경 유형에 따라 각각 다른 효과 부여 **/

        switch (changeType) {
            /** 일반 **/
            case GeneratorPointTypes.Normal:
                ChangeTypeSettingModule("trig_normal", 0, GeneratorPointTypes.Normal, normal_mat, true);
                effectCount = 0;
                effectValueY = 0.0f;
                break;

            /** 흙 (비료용) **/
            case GeneratorPointTypes.Soil:
                ChangeTypeSettingModule("trig_soil", 9, GeneratorPointTypes.Soil, soil_mat, false);
                effectCount = addCount;
                effectValueY = 0.0f;
                break;

            /** 삽질 가능 **/
            case GeneratorPointTypes.Dig:
                ChangeTypeSettingModule("trig_dig", 0, GeneratorPointTypes.Dig, dig_mat, true);
                effectCount = addCount;
                effectValueY = addEffValueY;
                break;

            /** 작은 삽질 가능 **/
            case GeneratorPointTypes.Lowdig:
                ChangeTypeSettingModule("trig_homiedig", 0, GeneratorPointTypes.Lowdig, lowdig_mat, true);
                effectCount = addCount;
                effectValueY = addEffValueY;
                break;

            /** 심기 가능 **/
            case GeneratorPointTypes.Plant:
                ChangeTypeSettingModule("col_plant", 0, GeneratorPointTypes.Plant, plant_mat, false);
                effectCount = addCount;
                effectValueY = 0.0f;
                break;
        }
    }

    // 유형 변경 전용 메소드     
    private void ChangeTypeSettingModule(string tagName, int colLayerNum, GeneratorPointTypes type, Material material, bool triggerOn) {
        gameObject.tag = tagName;                           /** 태그 이름 변경 **/
        gameObject.layer = colLayerNum;                     /** 레이어 유형 변경 **/
        triggerType = type;                                 /** 트리거 타입 변경 **/
        GetComponent<MeshRenderer>().material = material;   /** 머터리얼 변경 **/
        GetComponent<Collider>().isTrigger = triggerOn;     /** 트리거 활성화 여부 설정 **/
    }


    // 땅 높이 설정                  
    public void SetTransformY(float addValue, bool meshUpdate) {
        meshPoint[meshPointIndex].y += addValue;
        transform.localPosition = meshPoint[meshPointIndex];

        /** meshUpdate가 true이면 Mesh를 업데이트함. **/
        if(meshUpdate) GetComponentInParent<MeshGenerator>().UpdateMeshInfo();
    }


    // 트리거 감지 확인              
    private void OnTriggerEnter(Collider other) {

        switch (triggerType) {
            case GeneratorPointTypes.Normal: break;

            case GeneratorPointTypes.Soil:
                if (other.gameObject.CompareTag("eff_fertilizer") || other.gameObject.CompareTag("particle")) {
                    Debug.Log("!");
                    effectCount--;
                    if (effectCount <= 0) ChangeType(GeneratorPointTypes.Normal, 0, 0.0f);
                }
                break;

            case GeneratorPointTypes.Dig: break;

            case GeneratorPointTypes.Lowdig: break;

            case GeneratorPointTypes.Plant: break;

        }
    }


    // 트리거(or 콜백) 감지 확인 (수동)       
    public void CallbackEffect(GeneratorPointTypes type) {

        /** 파라미터로 가져온 타입이 실제 이 오브젝트의 타입과 다르면 리턴 **/
        if (type != triggerType) return;

        switch (type) {
            case GeneratorPointTypes.Normal : break;
            case GeneratorPointTypes.Soil: break;

            /** effectValueY 수치만큼 땅 파기 **/
            case GeneratorPointTypes.Dig:
                SetTransformY(effectValueY, true);
                effectCount--;
                if (effectCount <= 0)
                    ChangeType(GeneratorPointTypes.Normal, 0, 0.0f);
                break;
            case GeneratorPointTypes.Lowdig: break;
            case GeneratorPointTypes.Plant: break;
        }
    }


    // 파티클 충돌 감지                
    private void OnParticleCollision(GameObject other){
        if(triggerType == GeneratorPointTypes.Soil) {
            Debug.Log(gameObject.name + "-> Count : " + (effectCount - 1));
            effectCount--;
            if (effectCount <= 0) {
                ChangeType(GeneratorPointTypes.Normal, 0, 0.0f);
                Debug.Log(gameObject.name + "-> Change Type(Normal)");
            }
        }
    }
}
