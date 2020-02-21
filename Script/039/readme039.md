### 039. 대화창 효과 테스트


#### 스크립트 설명 
	- StoryText.cs : 방향키를 눌러서 다음이나 이전 대화창 텍스트 내용을 읽을 수 있는 스크립트


#### 사용 방법 
	1. Canvas 오브젝트 생성
		- <Rect Transform> 컴포넌트에서 아래와 같이 설정
			- Pos : (0, 0, 5)
			- Width, Height : (1200, 800)
			- Scale : (0.01, 0.01, 0.01)
		- <StoryText> 스크립트 추가

	2. Canvas에 Panel 오브젝트 생성
	3. Canvas에 Text 오브젝트 생성
		- <Rect Transform> 컴포넌트에서 아래와 같이 설정
			- Width, Height : (900, 600)
		- <Text> 컴포넌트에서 Text의 내용을 모두 비운다.
	4. 실행 버튼을 누르고 방향키 '->'. '<-'를 이용하여 대화창이 잘 넘어가는지 확인한다.
