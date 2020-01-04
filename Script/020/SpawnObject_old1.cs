using UnityEngine;
using System.Collections;


public class SpawnObject_old1 : MonoBehaviour {

    // 변수               
    private float trigScaleX;
    private float trigScaleZ;

    private float randomR;
    private float randomG;
    private float randomB;

    // 초기화              
    private void Start() {
        trigScaleX = transform.localScale.x;    // 트리거의 X축 크기를 가져옴  
        trigScaleZ = transform.localScale.z;    // 트리거의 Z축 크기를 가져옴  

        StartCoroutine(spawnManager());         // 코루틴 함수 동작    
    }

    // 오브젝트 생성 관리 코루틴 함수    
    private IEnumerator spawnManager() {

        while (true) {
            // 오브젝트 생성                                    
            createBall();

            // 1 ~ 5초 간격으로 대기함.                         
            yield return new WaitForSeconds(Random.Range(1, 6));
        }
    }


    // 공 생성 메서드                    
    private void createBall() {

        // 난수를 이용하여 위치 지정                 
        float randPositionX = Random.Range(-(trigScaleX / 2) + transform.position.x, (trigScaleX / 2) + transform.position.x);
        float randPositionZ = Random.Range(-(trigScaleZ / 2) + transform.position.z, (trigScaleZ / 2) + transform.position.z);

        // 오브젝트(구)를 생성함                     
        GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Sphere);

        // 생성할 위치를 지정함 (트리거 범위 내에서) 
        obj.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        obj.transform.position = new Vector3(randPositionX, transform.position.y, randPositionZ);

        // 생성한 오브젝트에서 리지드바디 컴포넌트를 추가함.            
        obj.AddComponent<Rigidbody>();


        // Mesh Renderer 컴포넌트 가져옴 (Material 조작을 위함)         
        MeshRenderer tempMr = obj.GetComponent<MeshRenderer>();

        // 오브젝트 색깔을 랜덤으로 변경함.                             
        randomR = Random.Range(0, 101) / 100f;
        randomG = Random.Range(0, 101) / 100f;
        randomB = Random.Range(0, 101) / 100f;
        tempMr.material.color = new Color(randomR, randomG, randomB, 0.5f);

        // Transparent(투명) 모드로 변경하기 위한 코드                   
        tempMr.material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
        tempMr.material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        tempMr.material.DisableKeyword("_ALPHATEST_ON");
        tempMr.material.DisableKeyword("_ALPHABLEND_ON");
        tempMr.material.EnableKeyword("_ALPHAPREMULTIPLY_ON");
        tempMr.material.renderQueue = 3000;
    }
}
