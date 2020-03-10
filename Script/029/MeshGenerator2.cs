using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 *  Mesh 지형 생성 스크립트
 *  농사용 Mesh를 제작함. (빈 오브젝트)
 **/
 [RequireComponent(typeof(MeshFilter))]
public class MeshGenerator2 : MonoBehaviour {

    // 변수                 
    private Mesh mesh;
    private MeshFilter mesh_filter;
    private MeshCollider mesh_col;
    private MeshType meshType;
    private int[] triangles;

    public int xScale = 16;          /** X축 칸 개수 **/
    public int zScale = 15;          /** Z축 칸 개수 **/
    private Vector3[] meshPoint;     /** 꼭짓점 Vector **/


    // 초기화1              
    private void Awake() {
        /** MeshType 와 관련된 컴포넌트 비활성화 **/
        meshType = GetComponent<MeshType>();
        meshType.enabled = false;
    }


    // 초기화2              
    private void Start() {
        /** 컴포넌트 생성 및 불러오기 **/
        mesh_filter = GetComponent<MeshFilter>();
        mesh_col = gameObject.AddComponent<MeshCollider>();

        /** 생성한 Mesh 객체를 filter에 넣음. **/
        mesh = new Mesh();
        mesh.name = "generator";
        mesh_filter.mesh = mesh;

        /** 지형 생성 및 업데이트 **/
        CreateShape();
        UpdateMeshInfo();

        /** MeshType 관련 컴포넌트 활성화 **/
        meshType.enabled = true;
    }


    // Mesh 생성 메소드          
    private void CreateShape() {

        /** 배열 초기화 **/
        meshPoint = new Vector3[(xScale + 1) * (zScale + 1)];

        /** 지점 생성 **/
        for (int index = 0, z = 0; z <= zScale; z++)
            for (int x = 0; x <= xScale; x++)
                meshPoint[index++] = new Vector3(x, 0, z);

        /** 정수 배열 초기화 **/
        triangles = new int[xScale * zScale * 6];

        int vPoint = 0;
        int point = 0;

        /** 삼각형 매쉬 만들기 **/
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


    // 매쉬 갱신 메소드            
    private void UpdateMesh() {
        mesh.Clear();
        mesh.vertices = meshPoint;
        mesh.triangles = triangles;

        /** 텍스쳐 관련 변경 **/
        mesh.RecalculateNormals();

        Vector2[] uvs = new Vector2[mesh.vertices.Length];
        for (int count = 0; count < uvs.Length; count++)
            uvs[count] = new Vector2(mesh.vertices[count].x,  mesh.vertices[count].z);
        mesh.uv = uvs;
    }


    // 메쉬 갱신 메소드 (공유)     
    public void UpdateMeshInfo() {
        UpdateMesh();
        mesh_col.sharedMesh = mesh;
    }

    // 메쉬 포인트 반환 메소드     
    public Vector3[] GetMeshPoint() { return meshPoint; }
}
