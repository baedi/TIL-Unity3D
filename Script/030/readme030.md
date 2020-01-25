### 030. EnemyDieEffect.cs


#### 스크립트 설명 
	- 적의 사망 연출을 보여주느 스크립트



#### 사용 방법 
	1. Hierarchy에서 빈 오브젝트 생성
	2. 빈 오브젝트에 Capsule 오브젝트를 생성
	3. 빈 오브젝트에게 EnemyDieEffect 스크립트 적용



#### 연출 과정
	- liveLifeTime(생존 시간)이 지날 경우
		-> 대상의 회전 프리즈를 해제하여 기울어지게 만듬.

	- dieLifeTime(사망 시간)이 지날 경우
		-> 중력의 영향을 줄이고, 트리거 상태로 만듬.

	- destroyLifeTime(파괴 시간)이 지날 경우
		-> 대상이 파괴됨



#### 배운 내용 
	- Rigidbody mass의 역할 이해
	

