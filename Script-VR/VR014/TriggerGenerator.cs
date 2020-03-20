using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * 제너레이터의 각 꼭짓점(meshPoint)을 위한 스크립트
 * MeshGenerator 관련 스트립트에 의해서 
 **/
public class TriggerGenerator : MonoBehaviour {

    // 변수                
    private Vector3 meshPoint;
    private int triggerType;

    public enum GeneratorPointTypes {
        Normal, /** 일반 포인트 (아무 효과 없음) **/
        Soil,   /** 땅이 굽어지는 곳 (적용 시 수치에 따라 땅이 굽어짐, 그 후 Normal로 변경) **/
        Dig,    /** 일반 모종 삽으로 땅을 팔 수 있는 포인트 **/
        Lowdig, /** 호미로 땅을 팔 수 있는 포인트 **/
        Plant   /** 작물을 심을 수 있는 포인트 **/ 
    }


    // 
    public void GeneratorInitialize(Vector3 meshPoint, int triggerType){

        /** 매쉬 지점을 가져옴 **/
        this.meshPoint = meshPoint;

        /** 해당 지점의 타입을 설정함 **/
        this.triggerType = triggerType;

    }
}
