using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowTree : MonoBehaviour {

    // 변수            
    public float upScale = 0.0002f;
    public GameObject tree1;
    public GameObject tree2;

    private int growLevel;
    private int nextLevel;
    private GameObject curTree;

    // 초기화          
    void Start(){
        transform.localScale = new Vector3(0, 0, 0);
        growLevel = 1;
        nextLevel = 2;

        curTree = Instantiate(tree1);
        curTree.transform.parent = transform;
        curTree.transform.localScale = new Vector3(1, 1, 1);

    }

    // 루프              
    void Update() {
        if(transform.localScale.x <= 1.0f) {
            transform.localScale += new Vector3(upScale, upScale, upScale);

            if (transform.localScale.x > 0.5f && growLevel == 1) {
                growLevel = nextLevel;
                nextLevel++;

                Destroy(curTree);
                curTree = Instantiate(tree2);
                curTree.transform.parent = transform;
                curTree.transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }
}
