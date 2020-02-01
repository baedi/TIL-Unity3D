using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRController : MonoBehaviour {

    // Var          
    private LineRenderer lineRendererComp;
    private RaycastHit raycastHit;
    private GameObject currentButtonRay;

    public float raycastDistance = 50f;


    // Initialize   
    private void Awake() {

        lineRendererComp = this.gameObject.AddComponent<LineRenderer>();

        // Line settings.
        Material mat = new Material(Shader.Find("Standard"));
        mat.color = new Color(0, 251, 255, 0.5f);

        lineRendererComp.material = mat;
        lineRendererComp.positionCount = 2;
        lineRendererComp.startWidth = 0.01f;
        lineRendererComp.endWidth = 0.01f;
    }

    // Loop         
    private void Update() {

        // First position   
        lineRendererComp.SetPosition(0, transform.position);

        Debug.DrawRay(transform.position, transform.forward * raycastDistance, Color.green, 0.5f);


        // Collision Check. 
        if(Physics.Raycast(transform.position, transform.forward, out raycastHit, raycastDistance)) {
            lineRendererComp.SetPosition(1, raycastHit.point);

            if (raycastHit.collider.gameObject.CompareTag("Button"))
                ButtonRayProcess();
        }

        else {
            lineRendererComp.SetPosition(1, transform.position + (transform.forward * raycastDistance));

            if(currentButtonRay != null) {
                currentButtonRay.GetComponent<Button>().OnPointerExit(null);
                currentButtonRay = null;
            }
        }
    }
    


    // Button ray           
    private void ButtonRayProcess() {
        // Click  (down)    
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
            raycastHit.collider.gameObject.GetComponent<Button>().OnPointerClick(null);

        // Click (up)       
        else if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
            raycastHit.collider.gameObject.GetComponent<Button>().onClick.Invoke();

        else 
            raycastHit.collider.gameObject.GetComponent<Button>().OnPointerEnter(null);


        currentButtonRay = raycastHit.collider.gameObject;
    }
}
