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
        private void RefreshPotions()
        {
            potions = inventory.GetItems()
            .Where(x => x.Type == ItemType.Potion && x.Count > 0)
            .ToList();
        }
        public void DisplayPotion()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("회복");

                RefreshPotions();  // 포션 목록 새로고침

                if (potions.Count == 0)
                {
                    Console.WriteLine("사용 가능한 포션이 없습니다.\n");
                }
                else
                {
                    Console.WriteLine("[보유 포션 목록]");
                    for (int i = 0; i < potions.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {potions[i].Name} | 회복량: +{potions[i].Value} | 남은 수량: {potions[i].Count}개");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine($"현재 체력: {character.Hp}/{character.MaxHP}\n");

                for (int i = 0; i < potions.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {potions[i].Name} 사용");
                }

                Console.WriteLine("0. 나가기");

                Console.Write("\n원하는 행동을 입력해주세요.\n>>");
                string input = Console.ReadLine();

                if (input == "0") return;
                else if (input == "1")
                {
                    if (potions.Count > 0)
                    {
                        SelectPotion();
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
        private void SelectPotion()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("[포션 선택]");

                // 포션의 종류와 개수를 보여줌
                for (int i = 0; i < potions.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {potions[i].Name} | 회복량: +{potions[i].Value} | 남은 수량: {potions[i].Count}개");
                }
                Console.WriteLine("0. 취소");

                Console.Write("\n사용할 포션을 선택해주세요.\n>>");

                if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= potions.Count)
                {
                    UsePotion(potions[index - 1]);
                    break;  // 포션 사용 후 선택 화면 종료
                }
                else if (index == 0)
                {
                    return;  // 취소 선택 시 메서드 종료
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    Thread.Sleep(1000);
                }
            }
        }

        private void UsePotion(Item potion)
        {
            // MaxHP에 도달하지 않았을 때만 포션 사용 가능
            if (character.Hp < character.MaxHP)
            {
                if (potion.Count > 0)
                {
                    // 체력 회복
                    character.Hp += potion.Value;

                    // MaxHP를 초과하지 않도록 제한
                    if (character.Hp > character.MaxHP)
                    {
                        character.Hp = character.MaxHP;
                    }

                    // 포션 개수 감소
                    potion.Count--;

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
