### VR001. ControlScreen.cs


#### 스크립트 설명
- VR 컨트롤러의 동작을 확인하여 UI Text 형태로 출력해주는 스크립트. (Oculus Go 기반)


#### 사용 방법
1. (생략 가능) [여기](https://assetstore.unity.com/packages/3d/environments/landscapes/autumn-mountain-52251)를 눌러 배경 에셋을 다운로드받는다.
2. (생략 가능) Package Manager에서 Autumn Mountain을 선택하고 Download 버튼을 누른 뒤 Import한다.
3. (생략 가능) Window - Rendering - Lighting Setting을 누르고 Environment를 선택한다.
4. (생략 가능) Assets/FreeMountain/Skybox에 있는 Free_skybox/mat 파일을 Lighting 창의 Environment의 Skybox Material에 집어넣는다.
5. Hierarchy에서 Cube를 생성한다. 크기는(10, 1, 10), 좌표는(0, 0, 0), Box Collider 컴포넌트도 추가한다.
6. Hierarchy에서 Player를 생성한다. 좌표는 (0, 2, 0), Capsule Collider 컴포넌트를 추가한다. (Radius는 0.5, Height는 2로 설정한다)
7. Player오브젝트의 자식으로 OVRCameraRig를 추가한다. (Project 검색창에 치면 나옴)
8. OVRCameraRig에서 OVR Manager 스크립트의 Target Devices - Element 0 을 자신에게 맞는 VR로 설정한다.
9. OVRCameraRig - TrackingSpace - RightHandAnchor-RightControllerAnchor의 자식으로 OVRControllerPrefab를 추가한다.
10. Hierarchy에서 Cube를 추가하여 이름은 Panel, 좌표는 (0, 0, 15), 크기는 (20, 1, 1)로 설정한다.
11. Panel을 마우스 우클릭하여 UI - Canvas를 선택한다.
12. Canvas에서 크기는 (0.05, 1, 1)로 설정하고, Render Mode는 World Space로 설정한다.
13. Canvas을 마우스 우클릭하여 UI - Image를 선택한다. (이름은 "Background"로 설정)
14. Background(이미지 오브젝트)에서 컬러는 흰색, 투명도(A)를 128로 설정한다.
15. Background(이미지 오브젝트)에서 Width는 20, Height는 10으로 설정한다.
16. Background을 마우스 우클릭하여 UI - Text를 선택한다.
17. Text의 Width, Height를 각각 1000, 500으로 설정하고, Scale을 (0.02, 0.02, 0.02)로 설정한다.
18. Text의 Font Size를 30, Font를 Montserrat-Bold로 설정한다.
19. ControlScreen.cs 스크립트를 Text 오브젝트에 적용한다.



#### 배운 내용
- 배경 화면 적용 방법 (Skybox)
- VR 플레이어 및 컨트롤러 인식 방법
- 컨트롤러 버튼, 터치 동작 확인 방법


#### 참고 자료
- [Autumn Mountain 에셋](https://assetstore.unity.com/packages/3d/environments/landscapes/autumn-mountain-52251)
- [Skybox를 이용한 배경 적용 방법](https://you-rang.tistory.com/133)
- [OVRInput](https://developer.oculus.com/documentation/unity/latest/concepts/unity-ovrinput/)
