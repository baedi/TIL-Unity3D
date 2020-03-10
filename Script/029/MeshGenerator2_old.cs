using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class MeshGenerator2_old : MonoBehaviour {

    // 변수                       
    private MeshFilter meshFilter;      // 컴포넌트              
    private new MeshCollider collider;

    public Mesh mesh;                   // 매쉬 객체             
    public Vector3[] meshPoint;         // 매쉬 꼭짓점           
    public int[] triangles;             // 삼각형 형태 변형 관련 

    public int xScale = 5;              // x 크기     
    public int zScale = 5;              // z 크기     


    // 초기화                      
    void Start() {
        // Mesh 객체 생성                                  
        mesh = new Mesh();

        // 컴포넌트 생성 / 불러오기                        
        meshFilter = GetComponent<MeshFilter>();
        collider = gameObject.AddComponent<MeshCollider>();

        // MeshFilter의 mesh에 방금 생성한 mesh 집어넣기   
        meshFilter.mesh = mesh;

        // 형태 생성                                       
        CreateShape();
        UpdateMesh();
    }


    // 메쉬 생성                    
    private void CreateShape() {

        // 배열 초기화        
        meshPoint = new Vector3[(xScale + 1) * (zScale + 1)];

        // 지점 생성          
        for(int count = 0, z = 0; z <= zScale; z++)
            for(int x = 0; x <= xScale; x++) 
                meshPoint[count++] = new Vector3(x, 0, z);

        // 정수 배열 초기화   
        triangles = new int[xScale * zScale * 6];
        
        int vPoint = 0;
        int point = 0;

        // 삼각형 Mesh 만들기     
        for (int z = 0; z < zScale; z++) {
            for (int x = 0; x < xScale; x++) {
                triangles[point + 0] = vPoint + 0;
                triangles[point + 1] = vPoint + xScale + 1;
                triangles[point + 2] = vPoint + 1;
                triangles[point + 3] = vPoint + 1;
                triangles[point + 4] = vPoint + xScale + 1;
                triangles[point + 5] = vPoint + xScale + 2;

                vPoint++;
                point += 6;
            }
            vPoint++;
        }

    }


    // 갱신                       
    private void Update() {
        meshPoint[14].y -= 0.001f;
        meshPoint[15].y -= 0.001f;
        meshPoint[20].y -= 0.001f;
        meshPoint[21].y -= 0.001f;

        collider.sharedMesh = mesh;

        UpdateMesh();
    }


    // 메쉬 갱신 메소드            
    private void UpdateMesh() {
        mesh.Clear();

        mesh.vertices = meshPoint;
        mesh.triangles = triangles;
        //mesh.RecalculateNormals();
    }


    /*
    private void OnDrawGizmos() {
        if (vertices == null) return;

        for (int count = 0; count < vertices.Length; count++)
            Gizmos.DrawSphere(vertices[count], .1f);
    }
    */
    
}
