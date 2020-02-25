### VR012. 포톤 네트워크, 방 목록 만들기 테스트

 :bangbang: 본 문서는 포톤 네트워크를 이용한 구체적인 구현 방법은 다루지 않음. 따라서 스크립트 내용은 참고용으로만 사용하길 바람.
 :bangbang: 아직 미완성된 문서입니다.


![photon_lobby](./photon_lobby.PNG)
![photon_joinroom](./photon_joinroom.PNG)
![photon_objectsync](./photon_objectsync.PNG)


#### 스크립트 설명
	- PhotonManager.cs : 포톤 로비 생성, 방 생성, 방 검색, 방 접속 등 좀 더 복잡한 포톤 네트워크 관련 기능들을 수행하는 스크립트.
	- PhotonRoomInfo.cs : (방 버튼 전용) 방 이름, 패스워드, 플레이어 수 등 여러 프로퍼티가 정의되어있는 스크립트
	- PhotonInit2.cs : 이전 씬에서 생성된 오브젝트를 이용하여 호스트인지 아닌지 여부를 판단하고, 방 네트워크 기능을 수행하는 스크립트
	- PlayerMove.cs : (플레이어 전용) 네트워크 상에서 플레이어를 조작할 수 있고, 네트워크와 동기화되는 오브젝트를 생성할 수 있는 스크립트
	- PhotonCustomRoom.cs : (참고용) 포톤 방 생성 시 포톤 옵션을 이용하여 포톤 기본 옵션 이외에 사용자 정의를 추가하는 방법이 적힌 스크립트


#### 업데이트 기록
	- (2020-02-06) PhotonManager.cs 스크립트 수정
		- 방이 갱신될 경우 1개 이상의 방이 존재하면 해당 정보를 이용하여 방 버튼 텍스트에 표시 및 활성화함.
		- (GameObject 배열 변수를 추가하여 이 변수 안에 버튼 게임 오브젝트들을 넣어서 관리함.)

	- (2020-02-06) PhotonRoomInfo.cs 스크립트 추가
		- 버튼 게임 오브젝트 전용 스크립트로, 방 정보와 관련된 프로퍼티들이 정의되어 있음.



	- (2020-02-07) PhotonManager.cs 스크립트 수정(2)
		- 방 생성 시 or 방 접속 시 게임 씬으로 변경되는 기능 추가
		- 방(Room) 생성 창 UI 활성화/비활성화 기능 추가 (주의 : 임의로 만든 오브젝트이므로 참고 바람.) 
		- VR 키보드용 UI 활성화/비활성화 기능 추가 (주의 : 임의로 만든 오브젝트이므로 참고 바람.)

	- (2020-02-07) PhotonInit2.cs 스크립트 추가



	- (2020-02-08) PhotonInit2.cs 스크립트 수정
		- 방 생성 시 특정 플레이어가 나가도 해당 플레이어가 생성한 오브젝트가 자동으로 제거되지 않도록 구현
		- 방장이 방을 나갈 경우 접속 중인 모든 플레이어들도 방을 빠져나가도록 구현

	- (2020-02-08) PlayerMove.cs 스크립트 추가

	- (2020-02-24) PhotonCustomRoom.cs 스크립트 추가
		- 본 스크립트는 예시용으로 참고용으로만 사용 가능.
		- RoomOptions에서 CustomRoomProperties를 이용하여 방에 대한 사용자 정의 옵션을 만들 수 있음.
		- RoomOptions에서 CustomRoomPropertiesForLobby를 이용하여 로비에 해당 사용자 정의 옵션을 이용할 수 있음.
		- 이 예제에서는 비밀번호와 방장 정보를 담을 수 있는 커스텀 옵션이 있음. 이를 활용하여 로비에서 방장 정보를 나타내거나 비밀방을 만들 수 있음.

#### 사용 방법
	1. 포톤(Photon) 기본 세팅
		- VR011 문서 참조


	2. 로비 접속 방법
		- OnConnectedToMaster 오버라이드 함수 내에서 PhotonNetwork.JoinLobby( )를 호출.
		- 로비 접속이 성공적으로 완료되면 OnJoindLobby( ), OnRoomListUpdate( ) 오버라이드 함수가 호출됨.


	3. 방 갱신 방법
		- LeaveLobby( )를 이용하여 로비를 나갔다가 다시 JoinLobby( )를 호출. 


	4. 생성한 오브젝트 자동 사라짐 여부 설정 방법
		- CreateRoom( ) 내에서 RoomOptions 설정 시 CleanupCacheOnLeave 상태값을 true/false 중 설정하면 됨.


	5. 네트워크 환경에서 동기화 가능한 오브젝트 생성 방법
		- 네트워크 상에서 생성할 오브젝트는 Photon View 컴포넌트가 포함되어 있어야 함. ( + Photon Transform View)
		- MonoBehaviourPunCallbacks를 상속하는 클래스 내에서  PhotonNetwork.Instantiate( ) 메소드를 사용하면 됨.
		- (Instantiate( ) 사용 시 생성할 오브젝트(프리팹)은 Assets의 Resources 폴더에 반드시 있어야 함.)


	6. 방장 구별 방법 & 방장 나갈 시 모두 나가게 만드는 방법
		- OnJoindRoom( ) 메소드 내에서 PhotonNetwork.PlayerList 프로퍼티를 이용하여 Player 객체를 배열로 받아오는 명령어 작성.
		- 해당 객체들을 하나씩 확인하여 해당 객체의 IsMasterClient가 true인 객체를 찾는다.
		- 찾은 객체는 따로 변수에 저장해둔다. 나중에 누군가 나가서 OnPlayerLeftRoom( ) 콜백 메소드가 호출되면 해당 변수를 가지고 처리해준다.



#### 주의사항
	- 오버라이드로 선언된 함수들은 콜백(Callback) 방식으로 동작함.
	- 2개의 디바이스를 이용하여 실험을 진행하였음.
		- 디바이스 1(VR)은 방을 생성하고, 디바이스 2(Unity Debug)는 방을 생성하지 않고 콘솔 창을 통해 방 리스트를 확인하였음.



#### 배운 내용
	- 포톤(Photon) 방 검색 방법
	- 포톤(Photon) 일부 오버라이드(콜백) 함수의 용도 이해
	- (2020-02-07) 씬이 변경되어도 제거되지 않는 오브젝트 만드는 방법
	- (2020-02-07) System.Obsolve 네임스페이스 없이 게임오브젝트 활성화/비활성화 방법
	- (2020-02-07) 인덱서로 자식 오브젝트 찾는 방법
	- (2020-02-08) RoomOptions를 이용하여 오브젝트 자동 사라짐 여부 설정 방법
	- (2020-02-08) 네트워크 상에서 동기화 가능한 오브젝트 생성 방법
	- (2020-02-08) 플레이어 정보 가져오기 및 방장(MasterClient) 구별 방법
	- (2020-02-24) 커스텀 방 생성하는 방법 (비밀방 생성, 방장 유저 정보 가져오기 등)



#### 참고 자료
 - [포톤 로비 만들기](https://icechou.tistory.com/305)
 - [How to list rooms PUN2](https://answers.unity.com/questions/1562217/how-to-list-rooms-pun-2.html)
 - [인덱서로 자식 오브젝트 찾기](https://funfunhanblog.tistory.com/21)
 - [씬 변경되어도 유지되는 오브젝트 만드는 방법](https://bluemeta.tistory.com/19)
 - [PhotonView 문서](https://doc-api.photonengine.com/ko-kr/pun/current/class_photon_view.html#afcf78ab953a119454750b7e85242eae4)
 - [PUN2 마이그레이션 관련 문서](https://doc.photonengine.com/ko-kr/pun/v2/getting-started/migration-notes)