### 041. 사운드, 음악 관리 및 조절 테스트


#### 스크립트 설명 
	- SoundSettings.cs :  
	- SoundManager.cs : 
	- MusicManager.cs : 


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



