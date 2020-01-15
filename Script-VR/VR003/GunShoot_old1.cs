using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunShoot_old1 : MonoBehaviour {

    // 변수           
    private LineRenderer lineComponent;
    private const int MAX_BULLET = 12;
    private int currentBullet;
    private bool isReloading;

    private new AudioSource audio;

    public float lineDistance = 1;
    public GameObject bullet;
    public GameObject shootSoundObject;
    public AudioClip noAmmoSound;
    public AudioClip reloadSound;    


    // 초기화          
    [System.Obsolete]
    private void Awake() {
        
        // 머터리얼 생성/초기화           
        Material mat = new Material(Shader.Find("UI/Default"));
        mat.color = new Color(255, 0, 0, 0.5f);

        // LineComponent 생성/가져오기    
        lineComponent = gameObject.AddComponent<LineRenderer>().GetComponent<LineRenderer>();
        lineComponent.material = mat;
        lineComponent.SetWidth(0.005f, 0.005f);

        // 장전 수, 리로드 관련 설정            
        currentBullet = MAX_BULLET;
        isReloading = false;

        // 오디오 컴포넌트 추가/초기화          
        audio = this.gameObject.AddComponent<AudioSource>();
        audio.playOnAwake = false;
        audio.clip = reloadSound;
    }


    // 루프 1         
    private void FixedUpdate() {

        // 선 그리기                        
        lineComponent.SetPosition(0, transform.position);
        lineComponent.SetPosition(1, transform.position + transform.forward * lineDistance);

    }


    // 루프 2         
    private void Update() {

        // 장전 중이면 리턴         
        if (isReloading) return;


        // 트리거 버튼 누를 시 (총알 발사)  
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) || Input.GetMouseButtonDown(0)) {

            // 총알이 존재할 경우       
            if(currentBullet != 0) {

                // 총알 발사                         
                Instantiate(bullet, transform.position, transform.rotation);

                // 발사 사운드 관련 오브젝트 생성    
                Instantiate(shootSoundObject);

                // 총알 수 줄이기                    
                currentBullet--;

            }

            // 총알이 없는 경우         
            else {
                // 총알 부족 사운드 추가     
                audio.clip = noAmmoSound;
                audio.Play();
            }

        }

        // 원형 버튼 누를 시 (장전)          
        else if(OVRInput.GetDown(OVRInput.Button.One) || Input.GetMouseButtonDown(1)) {

            // 남은 탄환이 최대치이면 리턴  
            if (currentBullet == MAX_BULLET) return;

            // 장전 관련 프로그레스 효과    
            StartCoroutine(reloading());
        }
    }


    private IEnumerator reloading() {

        // 장전 중 활성화                                   
        isReloading = true;

        // 장전 사운드                                      
        audio.clip = reloadSound;
        audio.Play();

        // 장탄 수를 최대치로 돌려놓음  
        currentBullet = MAX_BULLET;

        // 장전 중 비활성화                                 
        isReloading = false;

        yield return null;
    }

}
