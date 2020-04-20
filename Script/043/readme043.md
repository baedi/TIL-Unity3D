### 043. 씬 내에서 특정 스크립트를 가진 오브젝트 불러오기 


#### 설명

현재 실행중인 씬 내부에서 특정한 오브젝트들을 모두 가져와서 처리하고자 할 경우 이 스크립트의 예제들을 통하여 해결할 수 있다.
FindObjectsOfTypes를 이용하여 특정 컴포넌트나 스크립트를 템플릿으로 부여하면 해당 컴포넌트나 스크립트를 가진 모든 오브젝트들을 가져올 수 있다.
이 점을 이용하여 해당 오브젝트들을 원하는 대로 다룰 수 있다.



#### 스크립트 소개 
	- CreateObjectInstance.cs : 입력한 수만큼 빈 오브젝트를 생성 및 초기화한 뒤 특정 스크립트를 가진 오브젝트를 가져와서 출력하는 스크립트
	- TestParent.cs : 부모 클래스
	- TestChild1.cs : TestParent.cs를 상속받는 자식 클래스 1
	- TestChild2.cs : TestParent.cs를 상속받는 자식 클래스 2
	- TestChild3.cs : TestParent.cs를 상속받는 자식 클래스 3


#### 사용 방법
	1. 빈 오브젝트를 생성한다.
	2. 이름을 CreateManager로 변경한다.
	3. CreateManager에게 CreateObjectInstance 컴포넌트를 추가한다.
	4. 해당 컴포넌트에서 오브젝트를 생성할 개수를 입력한다.
	5. 실행 버튼을 눌러 Debug 창을 확인해본다.