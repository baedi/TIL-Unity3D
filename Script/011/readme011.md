### 011. WallDetection.cs

#### 스크립트 설명 
	- 벽에 충돌할 경우 플레이어의 속도와 가속도 레벨을 감소시키는 스크립트


#### 사용 방법 
	1. Hierarchy에서 Cube를 생성하고 적절하게 크기와 위치를 조정한다.
	2. 생성한 Cube에게 "Wall" 태그를 적용하기 위해 "Wall" 태그를 만들고 적용한다.
	3. WallDetection.cs 스크립트를 움직이는 플레이어에게 추가한다.


#### 배운 내용 
	- 사용자가 만든 스크립트(컴포넌트)를 가져와서 해당 스크립트와 값을 교환하는 방법에 관한 이해
	- 무리한 벽 비비기를 방지하기 위한 방법 이해


#### 변경 사항 :: AccControl.cs
	- WallDetection 스크립트로부터 값을 교환하기 위한 get, set 메서드 추가
	

#### 변경 사항 :: CharacterAnimation.cs
	- Control -> AccControl 컴포넌트로 변경


기존에 사용하던 AccControl, CharacterAnimation 스크립트를 제거하고 새로 업데이트된 스크립트를 받아서 적용할 것을 권장함.
