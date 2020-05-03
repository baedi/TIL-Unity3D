using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

    // Var          
    private Itest i_test;


    // Initialize   
    private void Start() {
        i_test = new test1();

        StartCoroutine(ChangeInterface());
        StartCoroutine(Printing());
    }

    private IEnumerator ChangeInterface() {
        while (true) {
            yield return new WaitForSeconds(1);
            i_test = new test1();

            yield return new WaitForSeconds(1);
            i_test = new test2();
        }
    }

    private IEnumerator Printing() {
        while (true) {
            i_test.Effect();
            yield return new WaitForSeconds(1);
        }
    }
}
