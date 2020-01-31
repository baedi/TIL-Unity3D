using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalScene : MonoBehaviour {

    // 변수        
    public int portalNumber;    // 포탈 번호 설정 

    // 충돌 감지   
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Player")) {
            switch (portalNumber) {
                case 0: SceneManager.LoadScene("MainScene"); break; // 메인 씬 
                case 1: SceneManager.LoadScene("Scene1"); break;    // 1번 씬  
                case 2: SceneManager.LoadScene("Scene2"); break;    // 2번 씬  
                case 3: SceneManager.LoadScene("Scene3"); break;    // 3번 씬  
                default: Application.Quit(); break;
            }
        }
    }

}
