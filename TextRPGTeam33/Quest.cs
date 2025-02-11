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
            }
        }

        private List<QuestData> quests; // 퀘스트 전체 목록
        private List<QuestData> acceptedQuests; // 수락한 퀘스트 스택
        private QuestData currentQuest; // 현재 선택된 퀘스트

        private Quest() // 생성자에서 퀘스트 목록 초기화
        {
            quests = new List<QuestData> // 퀘스트 목록
            {
                new QuestData(1, "잃어버린 보급품을 찾아서",
                    "이봐! 며칠 전에 보급팀이 물자를 운반하다가 연락이 끊겼다네.\n그 물자들이 우리에겐 매우 중요하다고! 자네가 찾아와 줄 수 있겠나?",
                    1,
                    new Item("군용 방어구", ItemType.Amor, 15, 100, "튼튼한 군용 방어구입니다.", 2000, 1),
                    300),

                new QuestData(2, "의문의 구조신호",
                    "주둔지 근처에서 누군가가 보내는 구조 신호를 포착했네.\n위험할 수도 있지만, 우리 동료일 수도 있어. 확인해줄 수 있나?",
                    1,
                    new Item("군용 소총", ItemType.Weapon, 20, 100, "위력이 강한 군용 소총입니다.", 3000, 1),
                    500),

                new QuestData(3, "긴급 의료품 확보",
                    "의료품이 거의 바닥났다네. 병원에 물자가 남아있을 거야.\n위험하지만 누군가는 가야해. 자네가 가주겠나?",
                    1,
                    new Item("고급 회복 포션", ItemType.Potion, 50, 100, "매우 강력한 회복 효과를 가진 포션입니다.", 1000, 3),
                    400)
            };
            acceptedQuests = new List<QuestData>(); // 수락한 퀘스트 목록 초기화
        }
        
        public void DisplayQuests(Character player)
        {
            if (quests.All(q => acceptedQuests.Contains(q)))
            {
                Console.WriteLine("현재 수락 가능한 퀘스트가 없습니다.");
                Thread.Sleep(1500);
                return;
            }

            var availableQuests = quests.Where(q => !q.IsAccepted && !q.IsCompleted).ToList(); // 수락되지 않은 퀘스트 중에서 랜덤으로 1개 선택
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
                acceptedQuests.Add(currentQuest);
                currentQuest.IsAccepted = true;
                Console.WriteLine("\n퀘스트를 수락했습니다!");
                Thread.Sleep(1500);
            }
            else
            {
                Console.WriteLine("\n퀘스트를 거절했습니다.");
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
            }
        }

        private void DisplayQuestDetail(Character player, QuestData quest)
        {
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
                    CompleteQuest(player);
                    quest.RewardClaimed = true;
                    break;
                }
                else if (action == "2" && !quest.IsCompleted)
                {
                    acceptedQuests.Remove(quest);
                    break;
                }
            }
        }

        public void UpdateQuestProgress(int questId) // 퀘스트 진행도 업데이트
        {
            var quest = quests.Find(q => q.Id == questId);
            if (quest != null)
            {
                quest.CurrentCount++;
            }
        }

        public bool CompleteQuest(Character player) // 퀘스트 완료 처리 및 보상 지급
        {
            if (currentQuest != null && currentQuest.IsCompleted)
            {
                player.Exp += currentQuest.RewardExp; // 경험치 보상

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

                currentQuest.CurrentCount = 0;  // 진행도 초기화 추가
                currentQuest.IsAccepted = false;  // 수락 상태 초기화

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
        }
    }
}