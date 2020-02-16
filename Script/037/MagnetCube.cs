using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetCube : MonoBehaviour {

    // Var              
    public bool freezePosition = false;
    public bool isMagnetMode = true;
    public float radiusDistance = 5f;
    public float magnetPower = 15f;
    private Color magColor;

    // Property         
    public Color MagColor {
        set {
            magColor = value;
            GetComponent<MeshRenderer>().material.color = magColor;
        }
        get { return magColor; }
    }


    // Initialize       
    private void Start() {
        this.gameObject.AddComponent<Rigidbody>();

        // "freezePosition" is true -> FREEZING POSITION    
        if (freezePosition) {
            Rigidbody temp = GetComponent<Rigidbody>();
            temp.constraints = RigidbodyConstraints.FreezePosition;
        }

        // "isMagnetMode" is true -> Add Tag : Magnet       
        if (isMagnetMode) {
            gameObject.tag = "Magnet";
            magColor = new Color(255, 0, 0);
            gameObject.GetComponent<MeshRenderer>().material.color = magColor;
        }
    }

    // Loop             
    private void Update() {
        
        if(Physics.OverlapSphere(transform.position, radiusDistance).Length != 0) {
            StartCoroutine(MagnetDetect());
        }

    }


    // Coroutine        
    private IEnumerator MagnetDetect(){

        Collider[] cols = Physics.OverlapSphere(transform.position, radiusDistance);

        for(int count = 0; count < cols.Length; count++) {
            if (cols[count].gameObject.CompareTag("Magnet") && cols[count].gameObject != gameObject) {

                Color myColor = magColor;
                Color colColor = cols[count].GetComponent<MeshRenderer>().material.color;

                // Different Magnet Color      
                if (myColor != colColor) {
                    if (!freezePosition){
                        transform.position = Vector3.Lerp(transform.position, cols[count].transform.position, magnetPower * Time.deltaTime);
                    }

                    if(!cols[count].GetComponent<MagnetCube>().IsFreezePosition())
                        cols[count].transform.position = Vector3.Lerp(cols[count].transform.position, transform.position, magnetPower * Time.deltaTime);
                }

                // Same Magnet Color (Incomplete)
                else if(myColor == colColor) {
                    Rigidbody myRigid = GetComponent<Rigidbody>();
                    Rigidbody colRigid = cols[count].GetComponent<Rigidbody>();

                    if (!freezePosition) { 
                        // Incomplete...    
                    }

                    if (!cols[count].GetComponent<MagnetCube>().IsFreezePosition()) {
                        colRigid.AddForce(Vector3.up * Time.deltaTime * (magnetPower * 2), ForceMode.Impulse);
                    }
                }


            }
        }

        yield return null;
    }


    public bool IsFreezePosition() {
        return freezePosition;
    }
}
