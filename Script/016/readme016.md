### 015. CollisionScript.cs

 * 스크립트 설명 : 물체와 충돌할 경우 해당 물체를 반사시키는 스크립트


 * 사용 방법 : 
	1. Hierarchy에서 Cube를 생성한다. (이름은 MirrorWall로 설정)
	2. MirrorWall의 Scale을 두껍게 조절한다. (오브젝트와 충돌 시 충돌 처리 전에 통과되는걸 방지하기 위함)
	3. 이 스크립트를 MirrorWall에 적용한다.


 * 주의사항 : 
	- 본 스크립트는 이전에 완료하였던 실험과 연계되어 진행됨.
	- 캐릭터를 FPS 방식으로 조종할 수 있어야 함. 


 * 배운 내용 :
	- 입사각, 반사각에 관한 대략적인 이해
	- 코루틴 함수를 이용한 타이머 응용 (오브젝트 파괴)


 * 수정 사항 : 

 #### Bullet.cs
	- 코루틴 함수를 이용한 타이머 추가 (오브젝트 파괴 용도)
	- 발사 지점 (오브젝트 생성 지점)을 반환시키는 메소드 추가 (반사각을 구하기 위함)


 * 참고 자료 : 
	- https://hyunity3d.tistory.com/574
	- https://gall.dcinside.com/board/view/?id=programming&no=773249