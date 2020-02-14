using System.Collections;
using UnityEngine;

public class SphereInvert : MonoBehaviour {

    // Var              
    private Mesh mesh;
    private MeshRenderer screen;
    private bool isProcessing = false;


    // Initialize.      
    private void Start() {

        /** Sphere Object Inverting... **/
        mesh = GetComponent<MeshFilter>().mesh;

        Vector3[] normals = mesh.normals;

        for (int index = 0; index < normals.Length; index++)
            normals[index] = -normals[index];

        mesh.normals = normals;


        for(int index = 0; index < mesh.subMeshCount; index++) {
            int[] triangles = mesh.GetTriangles(index);
            
            for(int index2 = 0; index2 < triangles.Length; index2 += 3){
                int temp = triangles[index2];
                triangles[index2] = triangles[index2 + 1];
                triangles[index2 + 1] = temp;
            }

            mesh.SetTriangles(triangles, index);
        }


        /** Screen Settings... **/
        screen = GetComponent<MeshRenderer>();
        screen.material.color = new Color(0, 0, 0, 0.0f);
        screen.enabled = false;
    }


    // Loop                 
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape) && !isProcessing) {
            Debug.Log("Screen Effect!");
            isProcessing = true;
            StartCoroutine(ScreenEffect(screen.enabled));
        }
    }


    // Coroutine            
    private IEnumerator ScreenEffect(bool isEnable){

        // Dark OFF     
        if (isEnable) {

            while (true) {
                if (screen.material.color.a > 0.0f) {
                    screen.material.color = new Color(0, 0, 0, screen.material.color.a - 0.02f);
                    yield return new WaitForSeconds(0.01f);
                }

                else break;
            }

            screen.enabled = false;
        }

        // Dark ON      
        else {
            screen.enabled = true;

            while (true) {
                if (screen.material.color.a < 1.0f) {
                    screen.material.color = new Color(0, 0, 0, screen.material.color.a + 0.02f);
                    yield return new WaitForSeconds(0.01f);
                }

                else break;
            }

        }

        isProcessing = false;
        yield return null;
    }
}
