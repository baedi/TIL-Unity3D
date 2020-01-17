using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRControlMove : MonoBehaviour {

    // 변수       
    public float moveSpeed = 2f;        // 이동속도     
    public float jumpPower = 600f;        // 점프         
    public bool isMove = false;

    private new Rigidbody rigidbody;

    // 초기화     
    private void Awake() {
        rigidbody = GetComponent<Rigidbody>();
    }

    // 루프       
    private void Update() {
        Vector2 touchVector = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad, OVRInput.Controller.RTrackedRemote);

        // 왼쪽 이동        
        if (touchVector.x <= -0.1f) transform.Translate(Vector3.left * (moveSpeed * Mathf.Abs(touchVector.x) * Time.deltaTime));

        // 오른쪽 이동      
        if (touchVector.x >= 0.1f) transform.Translate(Vector3.right * (moveSpeed * Mathf.Abs(touchVector.x) * Time.deltaTime));

        // 위쪽 이동        
        if (touchVector.y >= 0.1f) transform.Translate(Vector3.forward * (moveSpeed * Mathf.Abs(touchVector.y) * Time.deltaTime));

        // 오른쪽 이동      
        if (touchVector.y <= -0.1) transform.Translate(Vector3.back * (moveSpeed * Mathf.Abs(touchVector.y) * Time.deltaTime));

        // 점프             
        if (OVRInput.GetDown(OVRInput.Button.One) || Input.GetKeyDown(KeyCode.Space))
            rigidbody.AddForce(Vector3.up * jumpPower * Time.deltaTime, ForceMode.Impulse);
            
    }
}
