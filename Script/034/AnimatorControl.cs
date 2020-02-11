using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorControl : MonoBehaviour {

    private GameObject character;
    private Animator animator;
    private bool isPlaying = true;

    // Initialize               
    private void Start() {
        character = GameObject.Find("Player");
        animator = character.GetComponentInChildren<Animator>();

        animator.speed = 0.1f;
    }

    // Loop                     
    private void Update() {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
            AnimationPlaySetting();
    }

    private void AnimationPlaySetting() {
        isPlaying = !isPlaying;
        animator.speed = isPlaying ? 0.1f : 0f;
    }
}
