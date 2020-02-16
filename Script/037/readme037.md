### 037. 반경 내에 존재하는 게임 오브젝트 감지 테스트


[magnet_test](./magnetTest.gif)

#### 스크립트 설명 
	- InRadiusDetection.cs : 'E'키를 누를 경우 일정 반경 내에 있는 게임오브젝트들을 점프시키는 스크립트
	- MagnetCube.cs : 자석의 성질을 적용한 스크립트
	- MagnetChangeControl.cs : MagnetCube.cs와 연계하여 사용, 'E'키를 누를 경우 자석 색깔을 바꿀 수 있는 스크립트


#### 업데이트
	- (2020-02-15) MagnetCube.cs, MagnetChangeControl.cs 스크립트 추가


#### 사용 방법 
	-> 게임 오브젝트 감지
	1. Cylinder 오브젝트를 생성한다. (Position : (0, 0, 0), Scale : (20, 0.1, 20)
	2. Capsule 오브젝트를 생성한다. (Position : (0, 2, 0))
	3. Cube 오브젝트를 3개 생성하고 Capsule 오브젝트 주변에 각각 위치시키도록 한다.
	4. Capsule, Cube 3개 오브젝트에 대하여 Rigidbody 컴포넌트를 추가한다.
	5. Capsule 오브젝트에 대하여 InRadiusDetection 컴포넌트(스크립트)를 추가한다.
	6. 플레이 버튼을 누르고 실행 시 'E'키를 눌러 주변 물체가 공중에 뜨는지 확인한다.

	-> 게임 오브젝트 감지를 활용한 자석 성질 만들기
	1. Cube 오브젝트 2개를 생성 후 그 중 하나는 "MagCubeFloor"로 이름 변경
	2. MagCubeFloor를 아래와 같이 추가/변경한다.
		- Position : 0, 0, 0
		- 추가할 컴포넌트(스크립트) : MagnetCube, MagnetChangeControl
	3. 그 외 Cube 오브젝트에 대해서는 아래와 같이 추가/변경한다.
		- Position : 0, 30, 0
		- 추가할 컴포넌트(스크립트) :MagnetCube
	4. 실행 버튼을 누르고 'E'키를 이용하여 자석의 성질을 바꿔가면서 확인해본다.


#### 배운 내용 
	- 반경 내에 있는 오브젝트 감지하는 방법
	+ (2020-02-15) 프로퍼티 활용 향상
	+ (2020-02-15) Rigidbody의 Freeze Position을 스크립트에서 적용하는 방법


#### 참고 자료
 - [OverlapSphere 메소드 사용법](https://sharkmino.tistory.com/1437)
 - [프로퍼티 사용법](https://exynoa.tistory.com/153)
 - [Freeze rigidbody position in script](https://answers.unity.com/questions/747872/freeze-rigidbody-position-in-script.html)
