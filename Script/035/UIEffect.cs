using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEffect : MonoBehaviour {

    // Var.             
    private GameObject statusUI;
    private new AudioSource audio;
    private float appearSpeed = 5f;
    private bool isChanging = false;

    public AudioClip menuSound;
    public AudioClip clickSound;


    // Instructor       
    private void Start() {
        statusUI = GameObject.Find("Canvas");
        audio = GetComponent<AudioSource>();

        statusUI.transform.localScale = new Vector3(0, 0, 0);
        statusUI.SetActive(false);
    }


    // Loop             
    private void Update() {

        // Input "ESC" Button.      
        if (Input.GetKeyDown(KeyCode.Escape) && !isChanging) {

            audio.clip = clickSound;
            audio.Play();

            isChanging = true;
            if (statusUI.activeInHierarchy) StartCoroutine(DisappearUI());
            else if (!statusUI.activeInHierarchy) StartCoroutine(AppearUI());
        }
    }


    // Button click event.      
    public void OnDoneButtonClick() {

        if (isChanging) return;

        audio.clip = menuSound;
        audio.Play();

        isChanging = true;
        StartCoroutine(DisappearUI());
    }


    // UI ON                    
    private IEnumerator AppearUI() {

        while (true) {

            statusUI.SetActive(true);

            if (statusUI.transform.localScale == new Vector3(0.01f, 0.01f, 0f)) break;
            statusUI.transform.localScale = Vector3.Lerp(statusUI.transform.localScale, new Vector3(0.01f, 0.01f, 0), appearSpeed * Time.deltaTime);

            yield return null;
        }

        isChanging = false;
        yield return null;
    }


    // UI OFF                   
    private IEnumerator DisappearUI() {

        while (true) {
            if (statusUI.transform.localScale == new Vector3(0, 0, 0)) break;
            statusUI.transform.localScale = Vector3.Lerp(statusUI.transform.localScale, new Vector3(0, 0, 0), appearSpeed * 1.5f * Time.deltaTime);

            yield return null;
        }

        statusUI.SetActive(false);

        isChanging = false;
        yield return null;

    }
}
