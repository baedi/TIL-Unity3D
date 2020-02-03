### VR010. SQLite 데이터베이스 테스트

 :bangbang: 본 문서는 SQLite를 이용한 구체적인 구현 방법은 다루지 않음. 


![sqliteunity](./sqliteUnity.gif)


#### 스크립트 설명
	- CreateDB : SQLite를 이용하여 로그인 정보(닉네임)과 관련된 데이터베이스를 다루는 스크립트



#### 사용 방법
	1. 유니티에서 SQLite와 연동하기 위해 다음 작업이 선행됨. (관련 자료는 아래 참고자료의 2번째 링크 참조)
		- Assets 폴더에 Plugins 폴더 만들기
		- Plugins 폴더에서 Android, SQL 폴더 만들기
		- Android/libs/armeabi-v7a 폴더 내에 libsqlite3.so 파일 필요
		- Androud/libs/x86 폴더 내에 libsqlite3.so 파일 필요
		- SQL 폴더 내에 아래 파일들이 필요
			- Mono.Data.dll
			- Mono.Data.Sqlite.dll
			- Mono.Data.SqliteClient.dll
			- sqlite3.dll
			- System.Data.dll

	2. CreateDB.cs의 코드들을 참고 (자세한 구현 설명은 생략함.) 다음과 같은 작업 수행 가능
		- 플랫폼별 경로 확인 방법 
		- DB 파일 없을 시 DB 생성 및 쿼리를 이용한 테이블 생성하기 (CreateDefaultNickname( ))
		- SqliteConnection을 이용한 DB 연결하기
		- 쿼리를 이용한 데이터 갱신하기 (UpdateNickname( ))
		- 쿼리를 이용한 데이터 검색하기 (CheckNickname( ))



#### 배운 내용
	- 유니티에 SQLite DB 연동 방법
	- 모바일 DB 파일 경로 접근 방법



#### 참고 자료
 - [Unity, SQLite 연동 관련 자료1](https://m.blog.naver.com/PostView.nhn?blogId=daum7766&logNo=221484452303&categoryNo=29&proxyReferer=https%3A%2F%2Fwww.google.com%2F)
 - [Unity, SQLite 연동 관련 자료2](https://202psj.tistory.com/1310)
 - [C# SQLite 코딩 기본](http://www.gisdeveloper.co.kr/?p=2290)