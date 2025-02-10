using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPGTeam33
{
    public class Potion
    {
        private List<Item> potions;
        private Character character;
        private Inventory inventory;

        public Potion(Character character, Inventory inventory)
        {
            this.inventory = inventory;
            this.character = character;
            RefreshPotions();
        }
        private void RefreshPotions() // 포션 목록 새로고침
        {
            potions = inventory.GetItems()
            .Where(x => x.Type == ItemType.Potion && x.Count > 0)
            .ToList();
        }
        public void DisplayPotion() // 표션정보 출력
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("회복");

                RefreshPotions();  

                if (potions.Count == 0) // 포션이 없을 경우
                {
                    Console.WriteLine("사용 가능한 포션이 없습니다.\n");
                }
                else
                {
                    Console.WriteLine("[보유 포션 목록]");
                    for (int i = 0; i < potions.Count; i++) // 포션 수에 따라 1,2... 작성 // 포션이 1개일경우 1만 출력
                    {
                        Console.WriteLine($"{i + 1}. {potions[i].Name} | 회복량: +{potions[i].Value} | 남은 수량: {potions[i].Count}개");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine($"현재 체력: {character.Hp}/{character.MaxHP}\n");

                Console.WriteLine("1. 포션 선택");
                Console.WriteLine("0. 나가기");

                Console.Write("\n원하는 행동을 입력해주세요.\n>>");
                string input = Console.ReadLine();

                if (input == "0") return; // 나가기(메인화면)
                else if (input == "1") // 1. 포션 선택
                {
                    if (potions.Count > 0)
                    {
                        Console.Clear();
                        SelectPotion(); //포션 선택
                    }
                    else
                    {
                        Console.WriteLine("사용할 수 있는 포션이 없습니다!");
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
        private void SelectPotion() // 포션 선택
        {
            while (true)
            {
                Console.WriteLine("[포션 선택]");

                for (int i = 0; i < potions.Count; i++) // 포션의 종류와 개수를 출력
                {
                    Console.WriteLine($"{i + 1}. {potions[i].Name} | 회복량: +{potions[i].Value} | 남은 수량: {potions[i].Count}개");
                }
                Console.WriteLine("0. 취소");

                Console.Write("\n사용할 포션을 선택해주세요.\n>>");

                if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= potions.Count) // TryParse: 입력받은 값을 정수로 변환후 index에 대입 
                {
                    UsePotion(potions[index - 1]);
                    break;  // 포션 사용후 종료
                }
                else if (index == 0)
                {
                    return;  //  0. 취소 클릭시 이전 화면으로 나가기
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    Thread.Sleep(1000);
                }
            }
        }

        private void UsePotion(Item potion) // 포션 사용 코드
        {         
            if (character.Hp < character.MaxHP) // MaxHP에 도달하지 않았을 때만 포션 사용 가능
            {
                if (potion.Count > 0)
                {
                    character.Hp += potion.Value; // 체력 회복

                    if (character.Hp > character.MaxHP) 
                    {
                        character.Hp = character.MaxHP; // 회복후 회복량이 MaxHP보다 많을 경우 HP를 MaxHP로 설정
                    }
 
                    potion.Count--; // 포션 개수 1개 감소

                    Console.WriteLine($"{potion.Name}을(를) 사용했습니다.");
                    Console.WriteLine($"{potion.Value}HP가 회복 되었습니다.");
                    Thread.Sleep(1000);
                }
                else
                {
                    Console.WriteLine("포션이 부족합니다!");
                    Thread.Sleep(1000);
                }
            }
            else
            {
                Console.WriteLine("이미 체력이 최대입니다!");
                Thread.Sleep(1000);
            }

        }
    }
}
