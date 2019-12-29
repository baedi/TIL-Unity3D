### 015. CollisionMove.cs, CollisionMove2.cs

 * 스크립트 설명 : 물체와 충돌할 경우 충돌 방향으로 조금씩 밀려나게 만드는 스크립트


 * 사용 방법 : 
	1. Hierarchy에서 Cube와 Cylinder를 각각 생성한다. (이름은 각각 ColCube, ColCylinder)
	2. ColCube의 Scale을 (1, 1, 2)로 조절한다.
	3. ColCylinder의 Scale을 (1, 0.4, 1)로 조절한다.
	4. ColCylinder의 기존 Collider 컴포넌트를 제거하고 Add Component에서 Mesh Collider 선택 후 Convex를 체크한다. 
	5. ColCube에게 CollisionMove.cs 스크립트를 삽입한다.
	6. ColCylinder에게 CollisionMove2.cs 스크립트를 삽입한다.


 * 주의사항 : 
	- 본 스크립트는 이전에 완료하였던 실험과 연계되어 진행됨.
	- 캐릭터를 FPS 방식으로 조종할 수 있어야 함. 


 * 배운 내용 :
	- Impulse를 이용하여 충돌 방향 감지에 대한 응용 
	- Mesh Collider에 관한 이해