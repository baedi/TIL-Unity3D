using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallObjectScript : MonoBehaviour {

    private AccControl accControl;
    private float speedSave;

    // Start is called before the first frame update
    void Start() {
        accControl = GetComponent<AccControl>();
        //speedSave = accControl.getRunSpeed();
        speedSave = 0.1f;
        Debug.Log("save : " + speedSave);
    }


    // 충돌 감지            
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Player")) {
            accControl.setRunSpeed(0.05f);

        }
    }

    private void OnCollisionStay(Collision collision) {
        if (collision.gameObject.CompareTag("Player")) {
            accControl.setRunSpeed(0.05f);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) {
            accControl.setRunSpeed(speedSave);
        }
    }
}
