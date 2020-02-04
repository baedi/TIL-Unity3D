using Photon.Pun;
using Photon.Realtime;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMove : MonoBehaviourPunCallbacks {

    // Var.             
    public float moveSpeed = 1.5f;
    public float rotateSpeed = 80f;

    private Animator animator;


    // Initialize       
    private void Awake() {
        animator = GetComponent<Animator>();


    }

    // Loop             
    private void Update() {

        // Multiplayer operating overlap prevention (control)
        if (!photonView.IsMine) return;

        Vector2 touchVector = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad, OVRInput.Controller.RTrackedRemote);

        // Forward      
        if (Input.GetKey(KeyCode.W) || touchVector.y >= 0.1f) {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            animator.SetBool("isWalking", true);
            animator.SetBool("isForward", true);
            animator.SetBool("isBack", false);
        }

        // Back         
        else if (Input.GetKey(KeyCode.S) || touchVector.y <= -0.1f) {
            transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
            animator.SetBool("isWalking", true);
            animator.SetBool("isForward", false);
            animator.SetBool("isBack", true);
        }

        else 
            animator.SetBool("isWalking", false);
        


        // Left         
        if (Input.GetKey(KeyCode.A) || touchVector.x <= -0.1f)
            transform.Rotate(Vector3.down * rotateSpeed * Time.deltaTime);

        // Right        
        else if (Input.GetKey(KeyCode.D) || touchVector.x >= 0.1f)
            transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
    }
}
