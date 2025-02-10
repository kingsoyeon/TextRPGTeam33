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

        private class QuestData // 개별 퀘스트 정보를 담는 내부 클래스
        {
            public int Id { get; }  // 퀘스트 고유 ID
            public string Name { get; }  // 퀘스트 이름
            public string Description { get; }  // 퀘스트 설명
            public int TargetCount { get; }  // 목표 수량
            public int CurrentCount { get; set; }  // 현재 진행도
            public Item RewardItem { get; }  // 보상 아이템
            public int RewardExp { get; }  // 보상 경험치
            public bool IsCompleted => CurrentCount >= TargetCount;  // 퀘스트 완료 여부
            public bool IsAccepted { get; set; } = false;  // 퀘스트 수락 상태

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
        }

        public void DisplayQuests(Character player) // 퀘스트 출력
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Quest!!\n");
                for (int i = 0; i < quests.Count; i++) // 퀘스트 상표 표시
                {
                    string status = ""; // 퀘스트 상태 초기화
                    if (quests[i].IsCompleted) // 퀘스트를 완료하면 (완료)라 표현되고 색상을 회색을 변경
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        status = "(완료)";
                    }
                    else if (quests[i].IsAccepted) // 퀘스트가 진행중이면 (진행중)이라 표현되고 색상을 노란색으로 변경
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        status = "(진행중)";
                    }

                    Console.WriteLine($"{i + 1}. {quests[i].Name} {status}");
                    Console.ResetColor();  // 각 퀘스트 출력 직후 색상 초기화
                }

                Console.WriteLine("\n0. 나가기");
                Console.WriteLine("\n원하시는 퀘스트를 선택해주세요.");
                Console.Write(">>");

                string input = Console.ReadLine() ?? "";

                if (input == "0") return;

                if (int.TryParse(input, out int selected) && selected > 0 && selected <= quests.Count) //input값을 정수(int)로 변환 시켜 selected에 넣는다.
                {
                    
                    currentQuest = quests[selected - 1]; // 배열은 0부터 시작 하지만 플레이어는 1부터 입력함으로 1을 [0]으로 변경시키는 과정

                    Console.Clear();
                    Console.WriteLine("Quest!!\n");
                    Console.WriteLine($"{currentQuest.Name}\n");
                    Console.WriteLine($"{currentQuest.Description}\n");
                    Console.WriteLine($"- {currentQuest.Name} ({currentQuest.CurrentCount}/{currentQuest.TargetCount})");
                    Console.WriteLine("\n- 보상 -");
                    Console.WriteLine($"  {currentQuest.RewardItem.Name} x 1");
                    Console.WriteLine($"  경험치 {currentQuest.RewardExp}\n");

                    if (currentQuest.IsCompleted) // 퀘스트 완료
                    {
                        Console.WriteLine("1. 보상 받기");
                        Console.WriteLine("0. 돌아 가기");
                    }
                    else if (!currentQuest.IsAccepted) // 퀘스트 수락 전
                    {
                        Console.WriteLine("1. 수락");
                        Console.WriteLine("0. 거절");
                    }
                    else // 퀘스트 수락 이후
                    {
                        Console.WriteLine("2. 취소하기");
                        Console.WriteLine("0. 돌아가기");
                    }

                    Console.Write("\n원하시는 행동을 입력해주세요.\n>>");
                    string action = Console.ReadLine() ?? "";

                    if (action == "1") 
                    {
                        if (currentQuest.IsCompleted) // 퀘스트 완료 후 1을 누르면...
                        {
                            CompleteQuest(player); // 퀘스트 성공 후 보상 수령
                        }
                        else if (!currentQuest.IsAccepted) // 퀘스트 수락
                        {
                            currentQuest.IsAccepted = true;
                            Console.WriteLine("\n퀘스트를 수락했습니다!");
                        }
                        else 
                        {
                            Console.WriteLine("잘못된 입력입니다.");
                            Thread.Sleep(1000);
                        }
                        Console.WriteLine("\n계속하려면 아무 키나 누르세요...");
                        Console.ReadKey();
                    }
                    else if (action == "2" && currentQuest.IsAccepted && !currentQuest.IsCompleted) // 퀘스트 수락 상태에 2를 누르면...
                    {
                        currentQuest.IsAccepted = false;
                        currentQuest.CurrentCount = 0;  // 진행상황 초기화
                        Console.WriteLine("\n퀘스트를 취소했습니다.");
                        Console.WriteLine("\n계속하려면 아무 키나 누르세요...");
                        Console.ReadKey();
                    }
                    else if (action == "0")
                    {
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                        Thread.Sleep(1000);
                    }
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    Thread.Sleep(1000);
                }
            }
        }

        public void SelectQuest(int index) // 퀘스트 선택 
        {
            if (index <= 0 || index > quests.Count) return; // 퀘스트 목록 출력

            currentQuest = quests[index - 1]; // 배열은 0부터 시작 하지만 플레이어는 1부터 입력함으로 1을 [0]으로 변경시키는 과정
            DisplayQuestDetail();
        }

        public void DisplayQuestDetail() // 퀘스트 목록을 표시하고 상호작용
        {
            Console.Clear();

            if (currentQuest == null) return; // 지금 퀘스트가 없다면 돌아가다.
            
            Console.WriteLine("Quest!!\n");
            Console.WriteLine($"{currentQuest.Name}\n");
            Console.WriteLine($"{currentQuest.Description}\n");
            Console.WriteLine($"- {currentQuest.Name} ({currentQuest.CurrentCount}/{currentQuest.TargetCount})");
            Console.WriteLine($"- 보상 - {currentQuest.RewardItem.Name}, 경험치 {currentQuest.RewardExp}\n");

            if (currentQuest.IsCompleted) // 퀘스트 완료 후
            {
                Console.WriteLine("1. 보상 받기");
                Console.WriteLine("0. 돌아 가기");
            }
            else // 오류날시 (코드 작동 안됨)
            {
                Console.WriteLine("\"오류발생\" 1. 수락");

                Console.WriteLine("\"오류발생\" 2. 거절");
            }
            Console.Write("\n원하시는 행동을 입력해주세요.\n>>");
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
    }
}