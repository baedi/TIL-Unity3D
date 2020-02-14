### VR013. 검은 화면 연출하기


#### 스크립트 설명
	- SphereInvert.cs : 화면을 서서히 어둡게 하거나 다시 밝아지게 하는 스크립트



#### 사용 방법
	- 카메라 오브젝트에 Sphere 오브젝트를 생성. (이름을 VRScreenEffect로 변경)
	- Project 폴더에서 Material을 생성 후 아래와 같이 설정
		- Shader : Standard
		- Rendering Mode : Transparent
		- Albedo : (0, 0, 0, 0.0)
		- Metallic, Smoothness : 모두 0으로 설정
	- VRScreenEffect에 Sphere Invert 컴포넌트 추가 (스크립트)



#### 배운 내용
	- VR 360 화면 만드는 방법



#### 참고 자료
 - [VR 영상처리](https://you-rang.tistory.com/119)
 - [Inverting Normals](https://www.youtube.com/watch?v=HEHn4EUUyBk)