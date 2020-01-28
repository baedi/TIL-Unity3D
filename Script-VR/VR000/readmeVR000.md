### VR000. 유니티 VR 환경설정 (Oculus GO 기반)


#### 오큘러스 고 개발환경 설정 방법 (Unity 2020.1.0a15.1847 기준)
	1. File - Build Settings에서 Android를 선택하여 모듈을 다운로드한다. (다운로드 버튼이 있는 경우)
	2. 모듈 설치 후 유니티를 재시작한다.
	3. Edit - Preferences에서 External Tools탭을 선택한다.
	4. JDK, SDK에 대한 체크 항목을 해제하여 경로를 설정한다.
 		- JDK : C:\Program Files\Java\(JDK 버전 폴더)
 		- SDK : C:\Users\사용자\AppData\Local\Android\Sdk (Android Studio 설치 후 SDK 버전 설치 필요)
	5. [Oculus Integration for Unity](https://developer.oculus.com/downloads/package/unity-integration/)를 에셋에 추가한다.
	6. Package Manager에서 Oculus Integration을 선택하여 다운로드 및 임포트한다.
	7. Edit - Project Settings을 누르고, Player 탭에서 XR Settings를 선택한다.
	8. XR Settings에서 Virtual Reality Supported의 체크를 활성화하고, Virtual Reality SDKs에서 +버튼을 눌러 Oculus를 추가한다.
	9. Other Settings의 Graphics Apis에서 Vulkan이 존재한다면 제거한다.
	10. VR 기기의 개발자 모드를 활성화한다. (Oculus 앱을 이용하여 원격 설정 가능)
	11. Gear VR Device ID 앱을 설치하여 DEVICE ID를 알아낸다.
	12. [여기](https://dashboard.oculus.com/tools/osig-generator/)를 클릭하여 사이트 접속 후 DEVICE ID를 입력하고 다운로드 버튼을 누른다.
	13. 받은 파일을 현재 유니티 프로젝트의 Assets\Plugins\Android\assets 폴더에 집어넣는다 (없을 시 폴더를 생성한다)
	14. VR 기기를 컴퓨터와 연결하고, VR 기기 내에서 디버그 모드 허용 창이 나타나면 허용해준다.
	15. File - Build Settings의 Android에서 Run Device를 해당 VR 기기로 설정한다.


#### 참고내용
	 - Oculus GO는 트래킹 불가능 (유니티 내에서 조작 불가능. 반드시 빌드 후 VR 내에서만 조작 가능)


#### 배운 내용
	 - VR 개발환경 설정 방법

