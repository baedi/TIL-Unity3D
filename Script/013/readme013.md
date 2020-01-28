### 013. RaycastCam.cs

#### 스크립트 설명
	- 특정 물체를 바라볼 경우 그 물체(오브젝트)의 이름을 콘솔 창에서 확인할 수 있는 스크립트


#### 사용 방법 
	- 카메라에게 이 스크립트를 적용한다. 여기서는 FPS 방식으로 물체를 감지하므로 1인칭이어야 함.


#### 권장 작업 
	1. Hierarchy에서 마우스 우클릭 -> UI -> Panel 을 클릭하여 패널 생성하기
	2. Rect Transform에서 너비(Width)와 높이(Height)를 10으로 변경한다.
	3. Rect Transform에서 UI 위치를 middle center로 맞춘다.
	4. Image의 Source Image옆에 원형 버튼을 눌러 적절한 이미지를 선택한다. (Knob 이미지 추천)


#### 배운 내용
	- RayCast 클래스에 관한 기본 이해
	- 패널을 이용하여 레티클을 만드는 방법에 관한 이해


#### 참고자료
 - [Raycast 충돌](https://chameleonstudio.tistory.com/63)