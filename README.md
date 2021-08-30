# Shambles

## overview

### 로그라이크 덱 빌딩 카드 게임
![enter image description here](https://user-images.githubusercontent.com/7011030/131308860-15c6c1e0-7aa7-4f52-b84c-a5e7c551b5ec.png)

#### 제작 기간 
-  2021.03 ~ (진행중)

#### 팀원

- 팀장 : ***이재복***
- 프로그래머 : **최다함(메인)**, 양지훈, 양우현
- 그래픽 : **정동현(메인)**, 고부강, 박경필, 차규빈 
- 기획 : **이재복(메인)**, 정준협, 김연완

#### 기술 스택
- unity
- c#
- sqlite

#### 수상 내역
- GIGDC 대학생 기획 부문 은상

## Programing Concept

> 저희 게임의 출시 목표는 지속적인 서비스가 가능한 상용화 모델이기 때문에 유지보수 및 코드수정의 용이성을 위해 기존의 범용적인 인디게임의 개발방식에서 벗어나 새로운 프로그래밍적 시도를 했습니다.

---

### 옵저버를 활용한 매니저 의존성 제거 (MVVM 모방)

![enter image description here](https://user-images.githubusercontent.com/7011030/131313877-bb818237-bb8a-4e4d-8ac2-f4f8bb22027c.png)

> 안드로이드 네이티브 어플리케이션에서 사용되는 MVVM 패턴에서 아이디어를 얻어 Observer시스템을 활용한 매니저 의존성 제거 디자인 패턴을 구성하였습니다.

저희 게임은 어플리케이션과 유사한 시스템을 가지고 있다고 판단하였습니다. 저희 게임의 작동방식은 사용자의 인풋과 그것에 해당하는 이벤트를 통해 보여지는 화면이 변화하는 시스템입니다. 그래서 이를 GameState라 불리우는 데이터 클래스를 메인으로 해서 그 데이터를 옵저빙하는 여러 컨트롤러들의 변화과정으로 게임의 구성을 요약시켰습니다.

#### EX. SomeManager.cs

    public class SomeManager : IObserver<SomeState> {	
		[SerialField] SomeStateHandler someStateHandler;

		public void OnCompleted() {
			throw new NotImplementedException();
		}

		public void OnError(Exception error) {
			throw new NotImplementedException();
		}

		public void OnNext(SomeState value) {
			if(value.isSomeDataUse()) {
				someFunction();
			}
		}

		public void SomeInput() {
			SomeStateHandler.OnSomeInputEvent();
		} 

		private void Start() {
			someStateHandler.Subscribe(this);
		}

	}

---

### Sqlite (DAO, DTO)

---

### Scene Manager (Game State Machine)

---

### Factory Manager

---

### Action Manager (cocos2d-x Action 모방)

---

### 전투 시스템 스크립트 제작 (진행중)

#### 언어 규약

#### 작동 원리

## Database ERD



## Graphics Reference




## 기획 자료 모음


