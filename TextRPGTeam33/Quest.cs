// Quest.cs
using System;
using System.Collections.Generic;
using System.Numerics;

namespace TextRPGTeam33
{
    public class Quest
    {
        private static Quest instance = null;
        public static Quest Instance // 싱글톤 패턴 구현
        {
            get
            {
                if (instance == null)
                    instance = new Quest();
                return instance;
            }
        }

        public class QuestData // 개별 퀘스트 정보를 담는 내부 클래스
        {
            public int Id { get; set; }  // 퀘스트 고유 ID
            public string Name { get; set; }  // 퀘스트 이름
            public string Description { get; set; }  // 퀘스트 설명
            public int TargetCount { get; set; }  // 목표 수량
            public int CurrentCount { get; set; }  // 현재 진행도
            public Item RewardItem { get; set; }  // 보상 아이템
            public int RewardExp { get; set; }  // 보상 경험치
            public bool IsCompleted => CurrentCount >= TargetCount;  // 퀘스트 완료 여부
            public bool IsAccepted { get; set; } = false;  // 퀘스트 수락 상태
            public bool RewardClaimed { get; set; } = false; // 보상 수령 여부

            public QuestData() { } // 기본 생성자 추가

            public QuestData(int id, string name, string description, int targetCount, Item rewardItem, int rewardExp) // QuestDate 생성자 - 데이터 초기화
            {
                Id = id;
                Name = name;
                Description = description;
                TargetCount = targetCount;
                CurrentCount = 0;
                RewardItem = rewardItem;
                RewardExp = rewardExp;
                IsAccepted = false;
                RewardClaimed = false;  // 명시적으로 false로 설정
            }
        }

        private List<QuestData> quests; // 퀘스트 전체 목록
        private List<QuestData> acceptedQuests; // 수락한 퀘스트 스택
        private QuestData currentQuest; // 현재 선택된 퀘스트

        private Quest() // 생성자에서 퀘스트 목록 초기화
        {
            quests = new List<QuestData> // Id, 이름, 설명, 아이템 보상, 경험치 보상
            {
                new QuestData(1, "좀비 사냥꾼",
                    "좀비들이 점점 더 늘어나고 있어... \n이대로 가다간 우리 거점이 위험해질 거야. 좀비 사냥을 도와주겠나?",
                    5,  // 5마리 처치
                    new Item("구급상자", ItemType.Potion, 30, 7, "기본적인 응급처치가 가능한 구급상자입니다.", 500, 2),
                    300), // 300 경험치

                new QuestData(2, "위험한 돌연변이",
                    "최근 돌연변이 좀비들이 자주 목격된다는 보고가 있었네.\n좀 더 깊숙한 곳을 수색해볼 수 있겠나?",
                    3,  // 3마리 처치 (높은 레벨 몬스터 타겟)
                    new Item("방탄 조끼", ItemType.Amor, 9, 3, "경찰용 방탄 조끼입니다. 총알을 어느정도 막아줄 것 같습니다.", 2000, 1),
                    500), // 500 경험치

                new QuestData(3, "네크로맨서의 그림자",
                    "던전 깊은 곳에서 강력한 기운이 느껴진다...\n아마도 좀비들을 조종하는 존재가 있는 것 같아.",
                    2,  // 보스 2회 처치
                    new Item("파피루스의 뼈조각", ItemType.Weapon, 0, 50, "???", 0, 1),
                    800) // 800 경험치
        };
            // 명시적으로 모든 퀘스트의 진행도 초기화
            foreach (var quest in quests)
            {
                quest.CurrentCount = 0;
                quest.IsAccepted = false;
                quest.RewardClaimed = false;
            }

            acceptedQuests = new List<QuestData>(); // 수락한 퀘스트 목록 초기화
        }
        
        public void DisplayQuests(Character player)
        {
            // 이미 수락한 퀘스트의 ID들을 체크
            var acceptedQuestIds = acceptedQuests.Select(q => q.Id).ToList();

            // 수락되지 않은 퀘스트만 필터링 (ID로 체크)
            var availableQuests = quests.Where(q => !acceptedQuestIds.Contains(q.Id)).ToList();

            if (availableQuests.Count == 0)
            {
                Console.WriteLine("현재 수락 가능한 퀘스트가 없습니다.");
                Thread.Sleep(1500);
                return;
            }

            // 던전 클리어 횟수에 따라 적절한 퀘스트 표시
            if (player.DungeonClearCount < 20)  // 초반에는 기본 좀비 퀘스트만
            {
                availableQuests = availableQuests.Where(q => q.Id == 1).ToList();
            }
            else if (player.DungeonClearCount < 45)  // 20~44층에서는 좀비+돌연변이 퀘스트
            {
                availableQuests = availableQuests.Where(q => q.Id <= 2).ToList();
            }
            if (availableQuests.Count > 0)
            {
                Random rand = new Random();
                currentQuest = availableQuests[rand.Next(availableQuests.Count)];

                Console.Clear();
                Console.WriteLine("Quest!!\n");
                Console.WriteLine($"{currentQuest.Name}\n");
                Console.WriteLine($"{currentQuest.Description}\n");
                Console.WriteLine($"- {currentQuest.Name} ({currentQuest.CurrentCount}/{currentQuest.TargetCount})");
                Console.WriteLine("\n- 보상 -");
                Console.WriteLine($"  {currentQuest.RewardItem.Name} x {currentQuest.RewardItem.Count}");
                Console.WriteLine($"  경험치 {currentQuest.RewardExp}\n");

                Console.WriteLine("1. 수락");
                Console.WriteLine("0. 거절");

                Console.Write("\n원하시는 행동을 입력해주세요.\n>>");
                string input = Console.ReadLine();

                if (input == "1")
                {
                    var questToAdd = new QuestData(
                        currentQuest.Id,
                        currentQuest.Name,
                        currentQuest.Description,
                        currentQuest.TargetCount,
                        currentQuest.RewardItem,
                        currentQuest.RewardExp
                    );
                    acceptedQuests.Add(questToAdd);
                    questToAdd.IsAccepted = true;
                    Console.WriteLine("\n퀘스트를 수락했습니다!");
                    Thread.Sleep(1500);
                }
                else
                {
                    Console.WriteLine("\n퀘스트를 거절했습니다.");
                    Thread.Sleep(1500);
                }
            }
            else
            {
                Console.WriteLine("현재 수락 가능한 퀘스트가 없습니다.");
                Thread.Sleep(1500);
            }
        }

        public void DisplayQuestList(Character player)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Quest!!\n");

                // 퀘스트 목록 표시
                for (int i = 0; i < acceptedQuests.Count; i++)
                {
                    if (acceptedQuests[i].IsCompleted && !acceptedQuests[i].RewardClaimed)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    else if (acceptedQuests[i].RewardClaimed)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                    }
                    Console.WriteLine($"{i + 1}. {acceptedQuests[i].Name}");
                    Console.ResetColor();
                }

                Console.WriteLine("\n0. 나가기");
                Console.WriteLine("\n원하시는 퀘스트를 선택해주세요.");
                Console.Write(">>");

                string input = Console.ReadLine();

                if (input == "0")
                {
                    // 보상 수령이 완료된 퀘스트 제거
                    acceptedQuests.RemoveAll(q => q.RewardClaimed);
                    break;
                }

                if (int.TryParse(input, out int selected) && selected > 0 && selected <= acceptedQuests.Count)
                {
                    DisplayQuestDetail(player, acceptedQuests[selected - 1]);
                }

                else  // 잘못된 입력 처리 추가
                {
                    Console.Clear();
                    Console.WriteLine("잘못된 입력입니다");
                    Thread.Sleep(1000);
                    Console.Clear();
                }
            }
        }

        private void DisplayQuestDetail(Character player, QuestData quest)
        {
            currentQuest = quest; // 현재 선택된 퀘스트로 업데이트
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Quest!!\n");
                Console.WriteLine($"{quest.Name}\n");
                Console.WriteLine($"{quest.Description}\n");
                Console.WriteLine($"- {quest.Name} ({quest.CurrentCount}/{quest.TargetCount})");
                Console.WriteLine("\n- 보상 -");
                Console.WriteLine($"  {quest.RewardItem.Name} x {quest.RewardItem.Count}");
                Console.WriteLine($"  경험치 {quest.RewardExp}\n");

                if (quest.IsCompleted && !quest.RewardClaimed)
                {
                    Console.WriteLine("1. 보상 수령");
                    Console.WriteLine("0. 돌아가기");
                }
                else if (!quest.RewardClaimed)
                {
                    Console.WriteLine("2. 퀘스트 포기");
                    Console.WriteLine("0. 돌아가기");
                }

                Console.Write("\n원하시는 행동을 입력해주세요.\n>>");
                string action = Console.ReadLine();

                if (action == "0") break;
                else if (action == "1" && quest.IsCompleted && !quest.RewardClaimed)
                {
                    bool completed = CompleteQuest(player);
                    if (completed)
                    {
                        break;
                    }
                }
                else if (action == "2" && !quest.IsCompleted)
                {
                    // 원본 퀘스트도 초기화
                    var originalQuest = quests.Find(q => q.Id == quest.Id);
                    if (originalQuest != null)
                    {
                        originalQuest.CurrentCount = 0;
                        originalQuest.IsAccepted = false;
                        originalQuest.RewardClaimed = false;
                    }

                    // 진행도 초기화
                    quest.CurrentCount = 0;
                    quest.IsAccepted = false;

                    acceptedQuests.Remove(quest);
                    break;
                }
                else  // 잘못된 입력 처리 추가
                {
                    Console.Clear();
                    Console.WriteLine("잘못된 입력입니다");
                    Thread.Sleep(1000);
                    Console.Clear();
                }
            }
        }

        public void UpdateQuestProgress(int questId) // 퀘스트 진행도 업데이트
        {
            var acceptedQuest = acceptedQuests.Find(q => q.Id == questId && q.IsAccepted);
            if (acceptedQuest != null)
            {
                acceptedQuest.CurrentCount++;
            }
        }

        public bool CompleteQuest(Character player) // 퀘스트 완료 처리 및 보상 지급
        {
            if (currentQuest != null && currentQuest.IsCompleted)
            {
                bool isLevelUp = player.LevelUp(currentQuest.RewardExp);

                if (currentQuest.RewardItem.Type == ItemType.Potion) // 아이템 보상
                {
                    for (int i = 0; i < currentQuest.RewardItem.Count; i++) // 포션의 경우 Count만큼 추가
                    {
                        Item newPotion = Item.CreateNewItem(currentQuest.RewardItem); // Item.cs에서 CreateNewItem()에 아이템 복제(새로운 ID 발급)
                        player.Inventory.AddItem(newPotion);
                    }
                }
                else // 무기나 방어구는 한 번만 추가
                {
                    Item newEquipment = Item.CreateNewItem(currentQuest.RewardItem); // Item.cs에서 CreateNewItem()에 아이템 복제(새로운 ID 발급)
                    player.Inventory.AddItem(newEquipment);
                }


                // 원본 퀘스트 초기화
                var originalQuest = quests.Find(q => q.Id == currentQuest.Id);
                if (originalQuest != null)
                {
                    originalQuest.CurrentCount = 0; // 진행도 초기화
                    originalQuest.IsAccepted = false; // 수락 상태 초기화
                    originalQuest.RewardClaimed = false; // 보상 수령 초기화
                }

                //진행중인 퀘스트 초기화
                currentQuest.CurrentCount = 0;  // 진행도 초기화 추가
                currentQuest.IsAccepted = false;  // 수락 상태 초기화
                currentQuest.RewardClaimed = false; // 보상 수령 초기화

                acceptedQuests.Remove(currentQuest);

                Console.Clear();
                Console.WriteLine("퀘스트 보상을 받았습니다!");
                Console.WriteLine($"경험치 {currentQuest.RewardExp}를 획득했습니다.");
                Console.WriteLine($"{currentQuest.RewardItem.Name}을(를) 획득했습니다.");

                return true;
            }
            return false;
        }
        public List<QuestData> GetQuestList()
        {
            return acceptedQuests;  // 현재 진행 중인 퀘스트 리스트 반환
        }

        public void LoadQuestList(List<QuestData> questList)
        {
            acceptedQuests = questList;  // 저장된 퀘스트 리스트 복원
            foreach (var quest in questList)
            {
                var originalQuest = quests.Find(q => q.Id == quest.Id);
                if (originalQuest != null)
                {
                    originalQuest.CurrentCount = quest.CurrentCount;
                    originalQuest.IsAccepted = quest.IsAccepted;
                    originalQuest.RewardClaimed = quest.RewardClaimed;
                }
            }
        }
    }
}