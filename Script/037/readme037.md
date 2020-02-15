### 037. 반경 내에 존재하는 게임 오브젝트 감지 테스트


#### 스크립트 설명 
	- InRadiusDetection.cs : 'E'키를 누를 경우 일정 반경 내에 있는 게임오브젝트들을 점프시키는 스크립트


#### 사용 방법 
	1. Cylinder 오브젝트를 생성한다. (Position : (0, 0, 0), Scale : (20, 0.1, 20)
	2. Capsule 오브젝트를 생성한다. (Position : (0, 2, 0))
	3. Cube 오브젝트를 3개 생성하고 Capsule 오브젝트 주변에 각각 위치시키도록 한다.
	4. Capsule, Cube 3개 오브젝트에 대하여 Rigidbody 컴포넌트를 추가한다.
	5. Capsule 오브젝트에 대하여 InRadiusDetection 컴포넌트(스크립트)를 추가한다.
	6. 플레이 버튼을 누르고 실행 시 'E'키를 눌러 주변 물체가 공중에 뜨는지 확인한다.


#### 배운 내용 
	- 반경 내에 있는 오브젝트 감지하는 방법


#### 참고 자료
 - [OverlapSphere 메소드 사용법](https://sharkmino.tistory.com/1437)