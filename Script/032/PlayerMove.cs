using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public float moveSpeed = 5f;
    public float rotateSpeed = 100f;


    // 초기화      
    private void Start() {
        gameObject.AddComponent<Rigidbody>().freezeRotation = true;
    }

    // 루프        
    private void Update() {
        transform.Translate(0, 0, Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime);
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime, 0);
    }
}
