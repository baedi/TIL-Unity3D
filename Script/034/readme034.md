### 034. 애니메이터 설정 테스트


#### 스크립트 설명 
	- AnimatorControl.cs : 현재 재생 중인 애니메이션을 재생하거나 정지할 수 있는 스크립트


#### 사용 방법 
	1. 아래 참고 자료의 링크를 클릭하여 해당 에셋을 다운로드 후 임포트한다.
	2. Animations 폴더를 만든 뒤 마우스 우크릭 - Create - Animator Controller를 선택한다.
	3. 임포트한 에셋의 Animations 폴더에서 common_people@wave의 화살표 버튼을 눌러서 "wave" 애니메이션 파일을 Animator에 드래그 앤 드롭한다.
	4. Hierarchy에서 빈 오브젝트 생성 후 Player로 이름을 변경한다.
	5. Player 오브젝트에 임포트한 에셋의 Models에 있는 프리팹을 가져온다.
	6. 해당 모델 프리팹에 Animator 컴포넌트를 추가하고, Controller와 Avartar를 설정한다.
	7. Player에게 AnimatorController.cs 스크립트를 추가한다.
	8. 실행 버튼을 눌러서 "키패드의 Enter 키"를 눌러 애니메이션이 재생/정지되는지 확인한다. 


#### 배운 내용 
	- Animator 컴포넌트를 이용하여 애니메이션 속도 조절 방법


#### 참고 자료
 - [Character Pack: Free Sample](https://assetstore.unity.com/packages/3d/characters/humanoids/character-pack-free-sample-79870)