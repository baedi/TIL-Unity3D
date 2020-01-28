### VR005. VRLookingControlMove.cs


#### 스크립트 설명
	- Oculus GO의 컨트롤러 트리거 버튼을 누르면 플레이어가 바라본 화면으로 전진하는 스크립트



#### 사용 방법
	1. 빈 오브젝트를 만들어서 이름을 Player로 변경한다. 
	2. Player 오브젝트에 OVRCameraRig 프리팹을 넣는다.
	3. Player 오브젝트에 다음과 같은 컴포넌트를 추가한다. (스크립트 포함)
		- VRLookingControlMove.cs
		- Rigidbody (Freeze Rotate 설정 필요)
		- Capsule Collider



#### 배운 내용
	- OVRCameraRig의 구성요소에 관한 이해 (CenterEyeAnchor의 용도)
