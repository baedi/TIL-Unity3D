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