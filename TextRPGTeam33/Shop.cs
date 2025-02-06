using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TextRPGTeam33
{
    public class Shop
    {
        private Character player;
        private Inventory inventory;
        private List<Item> itemList;

        public Shop(Character player, Inventory inventory)
        {
            this.player = player;
            this.inventory = inventory;
            this.itemList = Item.itemList();
        }

        public void DisplayShop()
        {
            bool isShopOpen = true;
            while (isShopOpen)
            {
                Console.Clear();
                Console.WriteLine("상점");
                Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");

                Console.WriteLine("\n[보유 골드]");
                Console.WriteLine($"{player.Gold}G");

                Console.WriteLine("\n[아이템 목록]");

               for (int i = 0; i < itemList.Count; i++)
                {
                    string price;
                    if (itemList[i].IsPurchase)
                    {
                        price = "구매 완료";
                    }
                    else
                    {
                        int actualPrice = (int)(itemList[i].Cost);
                        price = $"{actualPrice} G";
                    }

                    string stat;
                    if (itemList[i].Type == ItemType.Amor) { stat = $"방어력 +{itemList[i].Value}"; }
                    else if (itemList[i].Type == ItemType.Weapon) {  stat = $"공격력 +{itemList[i].Value}"; }
                    else {  stat = $"회복량 +{itemList[i].Value}"; }

                    Console.WriteLine($"- {i + 1} {itemList[i].Name,-8} | {stat,-6} | {itemList[i].Descrip,-30} | {price}");
                }

                Console.WriteLine("\n1. 아이템 구매");
                Console.WriteLine("2. 아이템 판매");
                Console.WriteLine("0. 나가기\n");

                Console.Write("원하시는 행동을 입력해주세요.\n ");
                string input = Console.ReadLine();

                if( input == "1")
                {
                    // 구매
                    BuyScreen();
                }
                else if( input == "2")
                {
                    // 판매
                    Console.Clear();
                    Console.WriteLine("판매는 준비중 입니다.");
                    Console.Write("아무 버튼을 눌러주세요.\n");
                    Console.ReadLine(); // 사용자 입력 대기
                    //SellScreen();
                }
                else if (input == "0")
                {
                    isShopOpen = false;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("잘못된 입력입니다.");
                    Thread.Sleep(1000);
                    Console.Clear();
                }

            }
            
        }

        private void BuyScreen()
        {
            Console.Clear();
            Console.WriteLine("상점 - 아이템 구매");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine("\n[보유 골드]");
            Console.WriteLine($"{player.Gold} G");

            Console.WriteLine("\n[아이템 목록]");

            for (int i = 0; i < itemList.Count; i++)
            {
                string price;
                if (itemList[i].IsPurchase)
                {
                    price = "구매 완료";
                }
                else
                {
                    int actualPrice = (int)(itemList[i].Cost);
                    price = $"{actualPrice} G";
                }

                string stat;
                if (itemList[i].Type == ItemType.Amor) { stat = $"방어력 +{itemList[i].Value}"; }
                else if (itemList[i].Type == ItemType.Weapon) { stat = $"공격력 +{itemList[i].Value}"; }
                else { stat = $"회력량 +{itemList[i].Value}"; }

                Console.WriteLine($"- {i + 1} {itemList[i].Name,-8} | {stat,-6} | {itemList[i].Descrip,-30} | {price}");
            }

            Console.WriteLine("\n0. 나가기");
            Console.Write("\n구매할 아이템 번호를 입력해주세요. \n");

            string input = Console.ReadLine();
            if (input == "0") return;

            if (int.TryParse(input, out int index) && index > 0 && index <= itemList.Count)
            {
                var item = itemList[index - 1];
                int price = item.Cost;

                if (item.IsPurchase)
                {
                    Console.WriteLine("이미 구매한 아이템입니다.");
                    Thread.Sleep(1000);
                }
                else if (player.Gold >= price)
                {
                    player.Gold -= price;
                    item.IsPurchase = true;

                    var newItem = new Item(item.Name, item.Type, item.Value, item.Descrip, item.Cost);
                    //inventory.AddItem(newItem); // 아이템을 인벤토리로 옮기는 코드 => inventory.cs에 AddItem(Item item) 함수 필요

                    Console.WriteLine("구매를 완료했습니다.");
                    Thread.Sleep(1000);
                }
                else
                {
                    Console.WriteLine("Gold가 부족합니다.");
                    Thread.Sleep(1000);
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("잘못된 입력입니다.");
                Thread.Sleep(1000);
                Console.Clear();
            }
        }
    }
    //private void SellScreen()
}
