### 015. Fire.cs , Bullet.cs

#### 스크립트 설명 
- 마우스를 누르면 오브젝트를 발사시키는 스크립트


#### 사용 방법 : 
1. Hierarchy에서 Cube를 생성한다. (이름은 Bullet로 설정)
2. Bullet의 Scale을 모두 0.5로 조절한다.
3. 프로젝트 폴더에서 마우스 우클릭 -> Create -> Material을 생성한다. (이름은 BulletColor로 설정)
4. BulletColor를 선택하고 Inspector에서 MainMaps의 Albedo에서 원하는 색상을 설정한다.
5. Bullet에게 BulletColor를 적용시키고, Bullet.cs 스크립트도 적용시킨다.
6. Hierarchy에 있는 Bullet을 프로젝트 폴더로 드래그 앤 드롭한다. (프리팹 생성)
7. MainCamera에게 Fire.cs 스크립트를 적용한다.
8. Fire.cs의 Bullet 변수에다가 Bullet 프리팹을 드래그 앤 드롭한다.

#### 주의사항 : 
- 본 스크립트는 이전에 완료하였던 실험과 연계되어 진행됨.
- 캐릭터를 FPS 방식으로 조종할 수 있어야 함. 


#### 배운 내용 :
- 오브젝트를 복사하는 방법에 관한 이해


 * 수정사항 : 
 - (20.01.07) 오브젝트 발사 시 오브젝트가 정확한 위치에 발사되지 않는 문제 수정