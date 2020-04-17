using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mono.Data.Sqlite;
using System.IO;

/**
 * 현재 진행상황을 저장하거나 불러오게 해주는 스크립트
 * 저장 대상 : 
 *  - 플레이어 및 도구 오브젝트 (위치값만 저장해두면 됨.)
 *  - 작물 오브젝트 (위치값, 성장 상태를 저장해둬야 되며, 인스턴스 생성 필요)
 *  - 제네레이터 (제너레이터에 심어진 트리거의 정보들)
 *  - 가이드 진행 상황 (페이지 저장해둬야 됨.)
 **/
public class SaveManager : MonoBehaviour {

    // 변수                
    private string db_path;
    private string db_name;
    private SqliteConnection connection;
    private SqliteCommand command;

    private string table_ObjectData = "object_data";
    private string table_PlantData = "plant_data";
    private string table_GeneratorData = "generator_data";
    private string table_GuideData = "guide_data";



    // 초기화              
    private void Awake() {

        // 이 스크립트가 실행중인 Scene으로 db_name 설정  
        db_name = @"\Databases\" + $"{SceneManager.GetActiveScene().name}.db";


        // 안드로이드 전용         
        if(Application.platform == RuntimePlatform.Android) { db_path = Application.persistentDataPath + db_name; }

        // 기타 (PC 전용)          
        else { db_path = Application.dataPath + db_name; }
    }


    // 테이블 생성           
    private void CreateDBTable(){
        if (!File.Exists(db_path)) {
            SqliteConnection.CreateFile(db_path);
            connection = new SqliteConnection("Data Source=" + db_path + ";Version=3;");
            connection.Open();

        }
    }

}
