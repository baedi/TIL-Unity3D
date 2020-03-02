### 040. 특정 씬 로드 시 로딩 씬을 거쳐서 처리하기 테스트


#### 스크립트 설명 
	- NextSceneInfo.cs : 로딩 씬을 불러오면서 다음 불러올 씬을 관리할 수 있는 스크립트
	- SceneLoadManager.cs : SceneManager 오브젝트로부터 로드할 씬 이름을 가져와서 로딩을 수행하는 스크립트


#### 사용 방법 
	1. 아래와 같이 씬을 구성한다.
		- StartScene
		- LoadingScene
		- MainScene

	2. StartScene 씬을 불러온다.

	3. 빈 오브젝트를 생성하고 <NextSceneInfo> 스크립트를 적용한다.
		- 이름은 SceneManager로 변경

	4. LoadingScene 씬을 불러온다.

	5. 빈 오브젝트를 생성하고 <SceneLoadManager> 스크립트를 적용한다.
		- 이름은 SceneLoadManager로 변경 

	6. 로딩 UI를 위한 오브젝트들을 생성한다.
		- Canvas 생성 (이름 : Canvas_Loading)
		- Canvas에서 Panel, Text, Slider 생성

	7. Canvas_Loading 오브젝트를 다음과 같이 설정한다.
		- <Canvas> 컴포넌트의 Render Mode를 "World Space"로 변경.
		- <Rect Transform>에서 Pos Z를 6으로 설정
		- Width, Height를 각각 600, 200으로 설정
		- Scale x, y, z를 모두 0.01로 설정

	8. Slider 오브젝트를 다음과 같이 설정한다.
		- <Rect Transform>에서 Width, Height 값을 각각 500, 50으로 변경한다.
		- Background의 <Rect Transform>에서 아래와 같이 설정한다.
			- Left : -5.3, Right : 5.3
			- Scale : (0.98, 1, 1)
		- Fill Area의 Fill 오브젝트의 <Rect Transform>에서 아래와 같이 설정한다.
			- Width : 10
		- Fill 오브젝트의 <Image> 컴포넌트에서 Color를 파란색으로 변경한다.




