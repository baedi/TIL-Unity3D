### 041. 사운드, 음악 관리 및 조절 테스트


#### 스크립트 설명 
	- SoundSettings.cs : 사운드, 배경음악 관련 스크롤바, 텍스트 연출, 음량 조절 이벤트 관리 스크립트
	- SoundManager.cs : 사운드 설정 및 볼륨, 스크롤바 볼륨 조절 관리 스크립트
	- MusicManager.cs : 배경음악 설정 및 볼륨, 스크롤바 볼륨 조절 관리 스크립트
	- VolumeScrollbarPointerEvent.cs : 볼륨 조절 스크롤바 전용, 스크롤바에서 뗄 경우  OnPointerUp 이벤트를 발생시키는 스크립트
	- SoundManageModule.cs : 원하는 사운드를 넣고 외부 스크립트를 이용하여 조절하기 위한 (부모) 스크립트
	- SoundEffectSettingModule.cs : 특정 이벤트에 따라 선택적으로 효과음을 낼 수 있게 하는 (자식) 스크립트 (SoundManageModule.cs)

#### 변수 및 메소드 소개
	- [SoundSettings.cs]
	- *** 변수
	- GameObject musicManager : <MusicManager> 컴포넌트를 가진 오브젝트에 해당
	- GameObject musicBar : 음악 음량 조절을 위한 Scrollbar UI 오브젝트
	- GameObject musicPercent : 음악 음량 수치를 표시하는 Text UI 오브젝트
	- GameObject soundManager : <SoundManager> 컴포넌트를 가진 오브젝트에 해당
	- GameObject soundBar : 사운드 음량 조절을 위한 Scrollbar UI 오브젝트
	- GameObject soundPercent : 사운드 음량 수치를 표현하는 Text UI 오브젝트
	
	- AudioSource musicSource : 음악의 실제 음량을 조절하기 위한 용도
	- Scrollbar musicScrollbar : musicBar로부터 가져온 Scrollbar 컴포넌트를 통하여 실제 스크롤의 value 값을 음악 음량에 조절하기 위한 용도
	- Text musicPercentText : musicPercent로부터 가져온 Text 컴포넌트를 통하여 musicScrollbar의 value값을 이용하여 text에 표현하기 위한 용도
	- AudioSource soundSource : 사운드의 실제 음량을 조절하기 위한 용도
	- Scrollbar soundScrollbar : soundBar로부터 가져온 Scrollbar 컴포넌트를 통하여 실제 스크롤의 value 값을 사운드 음량에 조절하기 위한 용도
	- Text soundPercentText : soundPercent로부터 가져온 Text 컴포넌트를 통하여 soundScrollbar의 value값을 이용하여 text에 표현하기 위한 용도

	- *** 메소드
	- void Awake( ) : 플레이 시 호출되는 메소드
		- 퍼블릭 게임오브젝트로부터 특정 컴포넌트를 가져와 초기화함.
		- 음악/사운드의 스크롤바 value 값이 변경될 경우 호출할 메소드에 대하여 리스너 설정함.
	- void MusicValueChanged( ) : musicScrollbar의 value 값이 변경될 경우 호출되어 텍스트 최신화 및 음악 음량 조절이 이루어짐.
	- void SoundValueChanged( ) : soundScrollbar의 value 값이 변경될 경우 호출되어 텍스트 최신화 및 사운드 음량 조절이 이루어짐.


	- [SoundManager.cs]
	- *** 변수
	- GameObject soundScrollbarObj : 음악 음량 조절을 위한 Scrollbar UI 오브젝트
	- AudioClip click : 버튼 클릭 사운드
	- AudioClip appear : 대화 창 나타나기 사운드
	- AudioClip disappear : 대화 창 사라지기 사운드
	- AudioClip error : 에러 대화 창 사운드

	- *** 메소드
	- void Awake( ) : 플레이 시 호출되는 메소드
		- 이 스크립트를 적용한 오브젝트에게서 <AudioSource> 컴포넌트가 있는지 확인. 없으면 생성함.
	- void Start( ) : Awake 작업 이후 호출되는 초기화 메소드
		- DB로부터 볼륨 값을 가져옴. 만약 실패 시 음량이 80%로 고정됨.
		- soundScrollbarObj의 스크롤바 값을 설정 및 오디오 볼륨을 설정함. 만약 해당 오브젝트가 없다면 오디오 볼륨만 설정함.
	- void SetSoundVolume(float volume) : 파라미터 값을 이용하여 오디오 볼륨을 설정함.
	- void SetSoundVolume(GameObject scrollObj) : 파라미터 값의 <Scrollbar> 컴포넌트를 가져와서 해당 스크롤바의 값으로 오디오 볼륨을 설정함.
	- void Sound_click( ) : click 변수에 저장된 사운드를 재생시킴
	- void Sound_appear( ) : appear 변수에 저장된 사운드를 재생시킴
	- void Sound_disappear( ) : disappear 변수에 저장된 사운드를 재생시킴
	- void Sound_error( ) : error 변수에 저장된 사운드를 재생시킴



	- [MusicManager.cs]
	- *** 변수
	- GameObject mainManager : 메인 매니저 오브젝트 전용
	- GameObject musicScrollbarObj : 음악 음량 조절을 위한 Scrollbar UI 오브젝트
	- AudioClip bgm : 음악 파일 전용
	
	- *** 메소드
	- void Awake( ) : 플레이 시 호출되는 메소드
	- void Start( ) : Awake 작업 이후 호출되는 초기화 메소드
		- DB로부터 볼륨 값을 가져옴. 만약 실패 시 음량이 80%로 고정됨.
		- musicScrollbarObj의 스크롤바 값을 설정 및 오디오 볼륨을 설정함. 만약 해당 오브젝트가 없다면 볼륨만 설정함.
	- void SetMusicVolume(float volume) : 파라미터 값을 이용하여 오디오 볼륨을 설정함.
	- void SetMusicVolume(GameObject scrollObj) : 파라미터 값의 <Scrollbar> 컴포넌트를 가져와서 해당 스크롤바의 값으로 오디오 볼륨을 설정함.



	- [VolumeScrollbarPointerEvent.cs] (참고용)
	- *** 메소드
	- void OnPointerUp(PointerEventData eventData) : 스크롤바 클릭 중 뗄 경우 호출. 볼륨 저장 및 코루틴 함수 동작시킴.
	- IEnumerator FlashingEffect( ) : OnPointerUp이 제대로 수행되어 저장되었는지 확인을 위한 용도. (텍스트가 초록색으로 일정 시간 점멸 발생)


	- [SoundManageModule.cs]
	- *** 변수, 프로퍼티
	- GameObject mainManager : 메인 매니저 오브젝트 (DatabaseManager 컴포넌트를 가져오기 위함)
	- AudioClip sound : 사운드 파일
	- AudioSource AudioSourceComp : AudioSource 컴포넌트 넣는곳

	- *** 메소드
	- void Start( ) : AudioSource 컴포넌트 생성 및 사운드 설정 초기화 작업을 수행함
	- void Start2( ) : Start( ) 이후 호출되는 메소드. (오버라이드용 메소드)
	- void ChangeVolume(float) : 볼륨 값을 조절해 주는 메소드 (외부 호출용)



	- [SoundEffectSettingModule.cs]
	- ** 변수
	- bool triggerEnterON : 트리거에 진입할 시 사운드 재생 여부
	- bool triggerExitON : 트리거에 나갈 시 사운드 재생 여부
	- bool collisionEnterON : 충돌 진입 시 사운드 재생 여부
	- bool collisionExitON : 충돌 탈출 시 사운드 재생 여부
	- bool naturalON : 일정 시간마다 자동으로 사운드 재생 여부
	- float minNaturalDelay : (naturalON 전용) 사운드 재생 전 최소 딜레이
	- fllat maxNaturalDelay : (naturalON 전용) 사운드 재생 전 최대 딜레이

	- void Start2( ) : naturalON이 true일 경우 NaturalSound( ) 코루틴 동작
	- void OnTriggerEnter(Collider) : 트리거 진입 이벤트. triggerEnterON이 true이면 사운드를 재생
	- void OnTriggerExit(Collider) : 트리거 탈출 이벤트. triggerExitON이 true이면 사운드를 재생
	- void OnCollisionEnter(Collision) : 충돌 진입 이벤트. collisionEnterON이 true이면 사운드를 재생
	- void OnCollisionExit(Collision) : 충돌 탈출 이벤트. collisionExitON이 true이면 사운드를 재생
	- IEnumerator NaturalSound( ) : 무한 반복되며, minNaturalDelay ~ maxNaturalDelay 사이에 난수를 발생시켜서 난수에 따라 딜레이 후 사운드를 재생함.
	- void PlaySound( ) : 사운드를 재생시킴. (외부 호출용)
 	- void PrepareAudioPlay( ) : 사운드 파일 수에 따라 난수를 발생시켜 난수를 인덱스로 활용하여 랜덤으로 재생할 사운드를 결정해줌.