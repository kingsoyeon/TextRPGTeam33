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

        public Potion(Character player) 
        {
            this.character = player;
        RefreshPotions();
        }
        private void RefreshPotions()
        {
            potions = character.Inventory.GetItems().Where(x => x.Type == ItemType.Potion && x.Count > 0).ToList();
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

                Console.WriteLine("1. 사용하기");
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
            if (potions.Count == 1)
            {
                UsePotion(potions[0]);
                return;
            }

            Console.WriteLine("\n사용할 포션을 선택해주세요. (0: 취소)");
            Console.Write(">>");

            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= potions.Count)
            {
                UsePotion(potions[index - 1]);
            }
            else if (index != 0)
            {
                Console.WriteLine("잘못된 입력입니다.");
                Thread.Sleep(1000);
            }
        }

        private void UsePotion(Item potion)
        {
            if (potion.Count > 0)
            {
                if (character.Hp == character.MaxHP)
                {
                    Console.WriteLine("이미 체력이 최대입니다!");
                    Thread.Sleep(1000);
                    return;
                }

                character.UsePotion(potion);
                Thread.Sleep(1000);
            }
            else
            {
                Console.WriteLine("포션이 부족합니다!");
                Thread.Sleep(1000);
            }
        }

    }
}
