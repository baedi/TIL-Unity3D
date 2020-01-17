### VR003. VRControlMove.cs


#### 스크립트 설명
	- Oculus GO의 컨트롤러 원형 버튼을 터치하면 터치한 부위 방향으로 이동하고, 버튼을 누르면 점프하는 스크립트



#### 사용 방법
	1. 빈 오브젝트를 만들어서 이름을 Player로 변경한다. 
	2. Player 오브젝트에 OVRCameraRig 프리팹을 넣는다.
	3. Player 오브젝트에 다음과 같은 컴포넌트를 추가한다. (스크립트 포함)
		- VRControlMove.cs
		- Rigidbody (Freeze Rotate 설정 필요)
		- Capsule Collider



#### 배운 내용
	- 원형 버튼을 이용한 플레이어 이동 구현 방법
