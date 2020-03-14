### VR015. 아이템(도구) 착용/해제하기


#### 스크립트 설명
	- VRHandController.cs : 컨트롤러가 가리키는 방향에 아이템이 존재하는지 여부를 감지하고 표시하며, 착용할 수 있게 해주는 스크립트
	- PlayerManager.cs : 컨트롤러의 상태(아이템 장착 여부) 등을 관리하는 스크립트


#### 변수/메소드 소개
	- [VRHandController.cs]
	- === 변수 ===
	- GameObject raycastUICanvas : 아이템이 Raycast에 의해 감지되면 표시할 UI 오브젝트 
	- float raycastDistance : Raycast 감지 거리 설정 (기본값 : 1.5)
	
	- === 메소드 ===
	- void Start( ) : UI 비활성화 및 OVRCameraRig 컴포넌트를 가진 오브젝트를 불러옴.
	- void Update( ) : Raycast를 이용하여 감지한 오브젝트가 아이템 태그를 가졌는지를 확인함.
		- Item 태그를 가진 오브젝트이면 해당 아이템 위에 UI이 표시되며, UI은 이 스크립트를 적용한 오브젝트를 계속 바라보게 됨.
		- Item 태그를 가진 오브젝트가 감지된 상태에서 버튼을 누르면 <PlayerManager>에 의하여 해당 오브젝트를 장착하게 되며, 이 스크립트는 비활성화됨.

	- [PlayerManager.cs]
	- === 변수/프로퍼티 ===
	- GameObject handSlot : 아이템 장착 여부를 확인하기 위한 빈 오브젝트
	- GameObject handModel : 맨 손 모델링 오브젝트
	- GameObject menuModel : 오큘러스 고 모델링 오브젝트
	- bool IsEquitItem : 아이템 장착 여부
	- bools IsPauseMenu : 메뉴 창 활성화 여부

	- === 메소드 ===
	- void Update( ) : <준비중>
	- void OnItemEquip(GameObject equip) : 외부를 통해 호출되는 스크립트로, 파라미터로 가져온 오브젝트를 장착하도록 만듬.
		- 빈 손 모델링을 비활성화시키고 파라미터로 가져온 equip 게임오브젝트를 장착하게 됨.
		- 장착하는 과정에서 해당 equip 오브젝트의 콜라이더는 트리거로 변경되며, 중력을 비활성화시킴.
		- 그 후 equip에 적용된 <ItemManager> 관련 컴포넌트를 활성화 상태로 만듬.

	- void OnItemRelease(GameObject equip) : 외부를 통해 호출되는 스크립트로, 파라미터로 가져온 오브젝트를 장착 해제하도록 만듬.
		- equip에 적용된 <ItemManager> 관련 컴포넌트를 비활성화 상태로 만듬.
		- 빈 손 모델링을 다시 활성화시키고, 파라미터로 가져온 equip 게임오브젝트를 해제하게 됨.
		- 해제하는 과정에서 해당 equip 오브젝트의 트리거는 콜라이더는 다시 변경되며, 중력이 활성화됨.
		

#### 배운 내용
	- 컴포넌트만 활성화/비활성화 방법
