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

        public void InventoryScreen(Character player)
        {
            Console.Clear();
            Console.WriteLine("인벤토리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine("");
            Console.WriteLine("[아이템 목록]");


            for (int i = 0; i < Items.Count; i++)
            {
                string itemInfo = InventoryDisplay(Items[i]);
                Console.WriteLine($"-{itemInfo}");
            }
            Console.WriteLine("");
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
                Console.Clear();
                Console.WriteLine("인벤토리-장착 관리");
                Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");

                for (int i = 0; i < Items.Count; i++)
                {
                    string itemInfo = InventoryDisplay(Items[i]);
                    Console.WriteLine($"-[{i+1}]{itemInfo}");
                }

                Console.WriteLine("");
                Console.WriteLine("0. 나가기");
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");

                input = Console.ReadLine();

                if (input == "0")
                {
                    return;
                }
                // 장착할 아이템 선택
                else if ((int.TryParse(input, out int selected) && selected >= 1 && int.Parse(input) <= Items.Count))
                {
                    Item selectedItem = Items[selected - 1];

                    // 장착한 아이템 장착해제
                    if (selectedItem.IsEquip)
                    {
                        player.UnEquipItem(selectedItem);
                        selectedItem.IsEquip = false;
                        Console.WriteLine("선택한 아이템을 장착 해제했습니다.");
                    }
                    else
                    {
                        // 장착하지 않은 아이템 장착
                        player.EquipItem(selectedItem);
                        selectedItem.IsEquip = true;
                        Console.WriteLine("선택한 아이템을 장착했습니다.");
                    }
                }

                else { Console.WriteLine("잘못된 입력"); }
              
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
                str += $"{item.Name} | 체력 +{item.Value} | {item.Descrip}";
                
            }

            return str;
                
        }
    }
}
