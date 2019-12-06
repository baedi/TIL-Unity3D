# TIL-Unity3D
 Unity3D Study with C#
-----------------------------------------
## 001. CoroutineTest.cs
 * 스크립트 설명 : 코루틴 함수를 이용하여 물체의 좌우 움직임을 지속적으로 제어한 스크립트
 * 사용 방법 : 하이러시에서 큐브를 생성하여 "TestCube" 라는 이름을 입력한 뒤 해당 스크립트를 TestCube에 드래그
 * 배운 내용 :
	- GameObject 클래스에 대한 기본 이해
	- GameObject 객체가 private인 상태에서 특정 오브젝트를 가져오는 방법에 대한 이해
	- 코루틴 함수의 기본 동작 이해 (스레드 대신 사용하면 좋음)
	- 오브젝트 기본 이동 방법에 대한 이해

-----------------------------------------
## 002. Control.cs
 * 스크립트 설명 : FPS 조작키를 이용하여 물체의 움직임, 점프를 제어할 수 있는 스크립트
 * 사용 방법 : 
	1. 오브젝트 2개를 생성한다. (예시 오브젝트 이름 : CubeGround, CubeControl)
	2. CubeControl에서 Rigidbody 컴포넌트를 추가한다. (물리, 중력 적용을 위함)
	3. CubeControl에게 이 스크립트를 드래그 앤 드롭한다.
	4. CubeGround의 태그를 Ground 혹은 MoveGround로 변경한다. (없으면 태그를 추가해야 함)

 * 배운 내용 :
	- 키 코드와 키를 입력받는 방법에 대한 이해
	- 물체 충돌을 감지하는 관련 함수들에 대한 이해
	- 직접 컴포넌트를 이용하지 않고도 옵션을 변경할 수 있는 방법에 대한 이해
	- 태그를 이용한 충돌 함수 응용

 * 참고 자료 : https://solution94.tistory.com/27

-----------------------------------------
### 003. ParentMove.cs
 * 스크립트 설명 : 플레이어가 움직이는 바닥에 닿을 시 바닥의 움직임에 따라 탈 수 있는 스크립트
 * 사용 방법 : 
	1. 조작키로 움직일 수 있는 플레이어 오브젝트를 만든다. (이름 예시 : PlayerCube, 조작 스크립트는 별도로 하기 바람) 
	2. 움직이는 바닥 오브젝트를 만들고 그룹을 "MoveGround"로 한다. (이름 예시 : TestCube, 조작 스크립트는 별도로 하기 바람)
	3. 이 스크립트를 PlayerCube에게 드래그 앤 드롭한다.

 * 배운 내용 : 
	- 오브젝트끼리 부모/자식을 코드로 설정하는 방법에 대한 이해

 * 참고 자료 : http://devkorea.co.kr/bbs/board.php?bo_table=m03_qna&wr_id=25896

-----------------------------------------

