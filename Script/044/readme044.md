### 044. 유니티에서 C# 인터페이스 구현하기


#### 설명
인터페이스를 이용하여 해당 인터페이스를 구현하는 두 개의 클래스를 이용하여 Itest 인터페이스 인스턴스에 어떤 인스턴스를 생성하였느냐에 따라 나중에 인터페이스 함수 호출 시 어떤 결과가 발생하는지 확인할 수 있는 예제용 코드


#### 스크립트 소개 
	- Itest.cs : 인터페이스 클래스
	- test1.cs : Itest 인터페이스를 구현(Implements)하는 클래스 1
	- test2.cs : Itest 인터페이스를 구현(Implements)하는 클래스 2
	- Manager.cs : 인터페이스 객체를 이용하여 인터페이스 함수를 호출하는 클래스


#### 사용 방법
	1. 빈 오브젝트를 생성한다.
	2. 해당 오브젝트에 <Manager> 컴포넌트를 추가한다. (Manager.cs 추가)
	3. 실행 및 디버그 창을 확인하여 결과를 확인한다.