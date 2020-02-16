using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetChangeControl : MonoBehaviour {

    private Color red = new Color(255, 0, 0);
    private Color blue = new Color(0, 0, 255);

    // Update is called once per frame
    private void Update() {
        if (Input.GetKeyDown(KeyCode.E)) {
            MagnetCube tempComponent = GetComponent<MagnetCube>();

            if (tempComponent.MagColor == red)
                tempComponent.MagColor = blue;

            else tempComponent.MagColor = red;
        }
    }
}
