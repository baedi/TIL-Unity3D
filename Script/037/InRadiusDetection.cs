using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InRadiusDetection : MonoBehaviour {

    // Var.             
    public float radius = 5f;   // Radius (Distance)    
    public float power = 100f;  // Force Power          


    // Loop             
    private void Update() {

        // Press 'E' Key.       
        if (Input.GetKeyDown(KeyCode.E)) 
            StartCoroutine(RadiusInGameObjectForce());

    }


    // Coroutine        
    private IEnumerator RadiusInGameObjectForce() {
        Debug.Log("Call : RadiusInGameObjectForce()");

        Collider[] cols = Physics.OverlapSphere(transform.position, radius);

        for(int count = 0; count < cols.Length; count++) {
            Rigidbody temp = cols[count].GetComponent<Rigidbody>();
            if(temp != null && temp.gameObject != this.gameObject) {
                Debug.Log("number " + (count + 1) + " : " + temp.gameObject.name);
                temp.AddForce(Vector3.up * power * Time.deltaTime, ForceMode.Impulse);
            }
        }

        yield return null;
    }
}
