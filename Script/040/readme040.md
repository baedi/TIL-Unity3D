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

	5. 빈 오브젝트를 생성하고 <SceneManager> 스크립트를 적용한다.




