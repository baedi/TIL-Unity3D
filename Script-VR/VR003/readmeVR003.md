### VR003. GunShoot.cs, ShootSoundEffect.cs


#### 스크립트 설명
	- GunShoot.cs : (기존 스크립트) + 총알 사운드 효과를 추가함.
	- ShootSoundEffect.cs : 총알 발사로 인한 전용 오브젝트가 생성될 경우 총알 발사 사운드 효과를 발생시키는 스크립트.



#### 추가 구현
	- GunShoot.cs : UI 구현 추가



#### 사용 방법
	1. 기존 적용한 GunShoot.cs 스크립트를 제거하고, 새로운 GunShoot.cs 스크립트를 적용한다. (VR002 참고)
	2. 아래 참고사항의 링크를 통하여 총 관련 사운드 파일을 받은 뒤 유니티에 임포트한다.
	3. 장탄 부족 사운드 파일을 noAmmoSound에, 장전 사운드 파일을 reloadSound에 집어넣는다.
	4. Hierarchy 뷰에서 빈 게임오브젝트를 생성한다. (이름은 shootSoundObject라 가정함.)
	5. shootSoundObject 에 ShootSoundEffect.cs 스크립트를 적용한다. 
	6. shootSoundObject를 프리팹화한 뒤 기존 Hierarchy에 생성한 shootSoundObject를 없앤다.
	7. 프리팹화한 shootSoundObject를 GunShoot 스크립트의 shootSoundObject에 넣는다.
	+8. Player - OVRCameraRig - TrackingSpace - RightHandAnchor에서 UI - Canvas를 생성한다. (이름 : StatusUI)
	+9. StatusUI의 너비, 높이를 각각 0.1, 0.07로 조절하고, Canvas 컴포넌트에서 Render Mode를 World Space로 변경한다.
	+10. StatusUI에 Panel을 추가한다. (Panel이름을 Background_panel로 변경한다.)
	+11. StatusUI에 Text를 추가한다. (Text이름을 BulletCount로 변경한다.)
	+12. BulletCount에서 너비, 높이는 각각 200, 140으로 변경. Scale을 모두 0.0005로 변경한다.
	+13. 폰트 크기는 50, Paragraph의 Alignment를 모두 중앙으로 둔다.
	+14. StatusUI에 Panel을 2개 추가한다. (이름은 각각 ProgressBarEmpty, ProgressBarFill)
	+15. 방금 생성한 2개의 패널의 너비 높이를 각각 0.08, 0.01로 조절한다.
	+16. ProgressBarEmpty의 색상을 반투명 회색으로 설정한다.
	+17. ProgressBaeFill의 색상을 불투명한 파란색으로 설정한다.



#### 배운 내용
	- 사운드 적용 및 재생 방법
	- 오브젝트 생성을 활용하여 사운드가 중간에 끊어지지 않고 중첩 재생하는 방법
	+ 코루틴 함수를 활용한 UI 시각 효과 구현 방법



#### 참고사항 (사운드)
- [발사 사운드](https://freesound.org/people/schots/sounds/382735/)
- [장전 사운드](https://freesound.org/people/MaximBomba/sounds/432139/)
- [장탄 부족 사운드](https://freesound.org/people/scaevola/sounds/333260/)
	
