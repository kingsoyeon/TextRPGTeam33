# 부산역 텍스트 RPG

좀비 아포칼립스 상황에서 부산역을 배경으로 하는 텍스트 기반 RPG 게임입니다.

## 게임 특징

- 다양한 직업 선택
  - 탈영병 - 군사 훈련을 받은 전투 전문가
  - 개 조련사 - 개와 함께 싸우며 특별한 아이템을 얻을 수 있음
  - 폭발물 산업기사 - 강력한 범위 공격 가능
  - 소방관 - 높은 생존력과 다중 타겟 공격
  - 이성언 튜터 - 파괴광선과 볼트태클 스킬 보유
  - 히든 직업 - 특별한 조건 달성 시 해금

- 생존형 게임플레이
  - 일일 탐험 시스템
  - 체력/마나 관리
  - 장비 수집과 강화
  - 퀘스트 시스템
  - 업적 시스템

- 턴제 전투 시스템
  - 다양한 적 타입
  - 전략적 스킬 사용
  - 보스 전투

## 주요 시스템

### 세이브 시스템
- 3개의 세이브 슬롯 제공
- 자동 저장 기능
- 글로벌 데이터 저장 (업적, 히든 요소 등)

### 상점 시스템
- 무기, 방어구, 포션 구매/판매
- 아이템 강화

### 퀘스트 시스템
- 스토리 퀘스트
- 일일 퀘스트
- 히든 퀘스트

### 인벤토리 시스템
- 아이템 관리
- 장비 장착/해제
- 포션 사용

## 파일 구조

```
TextRPGTeam33/
├── Program.cs           - 메인 게임 루프
├── GameSave.cs         - 세이브 시스템
├── Character.cs        - 캐릭터 클래스
├── CharacterCreator.cs - 캐릭터 생성
├── Battle.cs           - 전투 시스템
├── Monster.cs          - 몬스터 클래스
├── Quest.cs            - 퀘스트 시스템
├── Shop.cs             - 상점 시스템
├── Inventory.cs        - 인벤토리 관리
├── Item.cs             - 아이템 클래스
├── Potion.cs           - 포션 시스템
├── Skill.cs            - 스킬 정의
├── SkillManager.cs     - 스킬 관리
├── Stage.cs            - 스테이지 관리
└── Achievement.cs      - 업적 시스템
```

## 시작하기

1. 게임 실행
2. 캐릭터 생성
   - 이름 입력
   - 직업 선택
3. 메인 메뉴
   - 상태보기
   - 탐험
   - 휴식
   - 포션 사용
   - 일기 쓰기
   - 퀘스트 보기
   - 저장

## 개발 정보

- 개발 언어: C#
- 개발 환경: .NET Core
