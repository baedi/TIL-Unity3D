### VR008. VRControllerForward.cs

#### 스크립트 설명
	- (Oculus GO 전용) 트리거 버튼을 누르면 컨트롤러가 앞으로 부드럽게 이동하게 하는 스크립트


#### 사용 방법
	1. 빈 오브젝트를 만들어서 이름을 Player로 변경한다. 
	2. Player 오브젝트에 OVRCameraRig 프리팹을 넣는다.
	3. OVRCameraRig -> TrackingSpace -> RightHandAnchor -> RightControllerAnchor에 OVRControllerPrefab를 추가한다.
	4. Player 오브젝트에 VRControllerForward.cs 스크립트를 추가한다.


#### 배운 내용
	- Lerp 사용법 숙련
	- local position 원리 이해