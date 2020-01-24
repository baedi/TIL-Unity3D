using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRButtonEvent : MonoBehaviour {

    public void CubeEvent() {
        GameObject temp = GameObject.CreatePrimitive(PrimitiveType.Cube);
        temp.transform.position = new Vector3(0, 10, 0);
        temp.AddComponent<Rigidbody>();
    }

    public void ExitEvent() {
        Application.Quit();
    }

}
