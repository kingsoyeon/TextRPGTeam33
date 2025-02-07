using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPGTeam33
{
    public class Potion
    {
        private Item item;
        private Character character;

        public Potion(Character player) 
        {
            item = player.Inventory.GetItems().Find(x => x.Type == ItemType.Potion);
            this.character = player;
        }
        public void DisplayPotion()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("회복");
                if (item == null)
                {
                    Console.WriteLine("포션이 없습니다.\n");
                }
                else
                {
                    Console.WriteLine($"포션을 사용하면 체력을 {item.Value} 회복 할 수 있습니다. (남은 포션 : {item.Count})\n");
                }

                Console.WriteLine("1. 사용하기");
                Console.WriteLine("0. 나가기");

                Console.Write("\n원하는 행동을 입력해주세요.\n>>");
                string input = Console.ReadLine();
                if (input == "0") return;
                else if (input == "1")
                {
                    UsePotion();
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    Thread.Sleep(1000);
                }
            }

        }

        public void UsePotion()
        {
            if (item.Count > 0)
            {
                character.UsePotion(item);
            }
            else
            {
                Console.WriteLine("포션이 부족합니다!");
                Thread.Sleep(1000);
            }
        }
    }
}
