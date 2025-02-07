using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TextRPGTeam33
{
    public class Inventory
    {
        private List<Item> Items = new List<Item>();

        public void AddItem(List<Item> itemList)
        {
            if (itemList == null) return;
            foreach (Item item in itemList)
            {
                Items.Add(item);
            }
        }
        public void AddItem(Item item)
        {
            if (item == null) return;
            Items.Add(item);
        }

        public void RemoveItem(Item item)
        {
            Items.Remove(item);
        }

        public List<Item> GetItems()
        {
            
            return Items;
        }

        public void InventoryScreen()
        {
            Console.WriteLine("아이템목록"); // 문구 수정 예정


            for (int i = 0; i < Items.Count; i++)
            {
                string itemInfo = InventoryDisplay(Items[i]);
                Console.WriteLine("-{itemInfo}");
            }

            Console.WriteLine("");
            Console.WriteLine("1. 장착관리");
            Console.WriteLine("0. 나가기");
            Console.WriteLine("");
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");

            string input = Console.ReadLine();
            if (input == "0") { return; }
            else if (input == "1")
            {
                Console.WriteLine("인벤토리-장착 관리");
                Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");

                for (int i = 0; i < Items.Count; i++)
                {
                    string itemInfo = InventoryDisplay(Items[i]);
                    Console.WriteLine("-[i+1]{itemInfo}");
                }

                Console.WriteLine("");
                Console.WriteLine("0. 나가기");
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");

                if (input == "1") { } // 장착관리화면
                else { return; }

            }
            else { Console.WriteLine("잘못된 입력입니다."); }
        }
        
        public string InventoryDisplay(Item item)
        {
            
            string str = item.IsEquip ? "[E]" : "";
            if (item.Type == ItemType.Weapon)
            {
                str += $"{item.Name} | 공격력 +{item.Value} | {item.Descrip}";
                
            }
            else if (item.Type == ItemType.Amor)
            {
                str += $"{item.Name} | 방어력 +{item.Value} | {item.Descrip}";
               
            }
            else {
                str += $"{item.Name} | 방어력 +{item.Value} | {item.Descrip}";
                
            }

            return str;
                
        }
    }
}
