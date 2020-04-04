using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Mesh 지형 변경 및 관리 스크립트
 * MeshGenerator 컴포넌트가 포함된 오브젝트에 적용함.
 **/
public class MT_Potato : MeshType {

    // 변수                    
    private MeshGenerator meshGenerator;    /** 메쉬 제네레이터 **/
    private Vector3[] meshPoint;            /** 메쉬 포인트 **/
    private GameObject[] triggerObj;        /** 메쉬 포인트용 트리거 **/

    public GameObject triggerObjectModel;   /** 트리거 프리팹 모델 **/ 


    // 초기화                  
    private void Start() {

        /** MeshGenerator 컴포넌트 가져오기 **/
        meshGenerator = GetComponent<MeshGenerator>();
        meshPoint = meshGenerator.GetMeshPoint();

        /** meshPoint 크기만큼 triggerObj 공간 할당 **/
        triggerObj = new GameObject[meshPoint.Length];

        /** 메쉬 포인트 초기화 **/
        for(int index = 0; index < meshPoint.Length; index++) {
            triggerObj[index] = Instantiate(triggerObjectModel);
            triggerObj[index].name = "TriggerObject" + index;
            triggerObj[index].GetComponent<TriggerGenerator>().GeneratorInitialize(meshPoint, index);
        }


        /** 두둑 초기화 **/
        int xEA = meshGenerator.xScale + 1;     /** MeshGenerator 스크립트에서 X축 크기 가져와서 + 1 **/
        int[] lines = new int[] { 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };

        for (int lineCount = 0; lineCount < lines.Length; lineCount++)
            for (int index = 2; index < meshGenerator.xScale - 1; index++)
                triggerObj[xEA * lines[lineCount] + index].GetComponent<TriggerGenerator>().SetTransformY(0.5f, false);

        /** 땅 파기 가능 범위 초기화 **/
        lines = new int[] { 6, 10 };

        for (int lineCount = 0; lineCount < lines.Length; lineCount++)
            for (int index = 2; index < meshGenerator.xScale - 1; index++)
                triggerObj[xEA * lines[lineCount] + index].GetComponent<TriggerGenerator>();

        
        /** 모든 포인트를 soil 로 재 초기화 **/
        for(int index = 0; index <meshPoint.Length; index++) {
            triggerObj[index].GetComponent<TriggerGenerator>().ChangeType(TriggerGenerator.GeneratorPointTypes.Soil, 30, 0.0f);
        }

        // Test
        triggerObj[53].GetComponent<TriggerGenerator>().ChangeType(TriggerGenerator.GeneratorPointTypes.Dig, 10, -0.1f);
        triggerObj[89].GetComponent<TriggerGenerator>().ChangeType(TriggerGenerator.GeneratorPointTypes.Dig, 10, -0.1f);
        triggerObj[91].GetComponent<TriggerGenerator>().ChangeType(TriggerGenerator.GeneratorPointTypes.Water, 5, 0.0f);
        triggerObj[92].GetComponent<TriggerGenerator>().ChangeType(TriggerGenerator.GeneratorPointTypes.Water, 5, 0.0f);
        triggerObj[93].GetComponent<TriggerGenerator>().ChangeType(TriggerGenerator.GeneratorPointTypes.Water, 5, 0.0f);
        triggerObj[94].GetComponent<TriggerGenerator>().ChangeType(TriggerGenerator.GeneratorPointTypes.Water, 5, 0.0f);
        triggerObj[95].GetComponent<TriggerGenerator>().ChangeType(TriggerGenerator.GeneratorPointTypes.Water, 5, 0.0f);
        triggerObj[96].GetComponent<TriggerGenerator>().ChangeType(TriggerGenerator.GeneratorPointTypes.Plant, 1, 0);
        triggerObj[123].GetComponent<TriggerGenerator>().ChangeType(TriggerGenerator.GeneratorPointTypes.Lowdig, 20, -0.05f);
        triggerObj[124].GetComponent<TriggerGenerator>().ChangeType(TriggerGenerator.GeneratorPointTypes.Lowstack, 20, 0.05f);

        meshGenerator.UpdateMeshInfo();
    }


    // 가이드 전용 :: 
    public void GuideSettings(int level){
        switch (level) {
            case 1: break;
            case 2: break;
        }
    }
}
