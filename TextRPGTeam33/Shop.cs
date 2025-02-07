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

                    Console.WriteLine($"- {itemList[i].Name,-8} | {stat,-6} | {itemList[i].Descrip,-30} | {price}");
                }

                Console.WriteLine("\n1. 아이템 구매");
                Console.WriteLine("2. 아이템 판매");
                Console.WriteLine("0. 나가기\n");

                Console.Write("원하시는 행동을 입력해주세요.\n");
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
                    SellScreen();
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
                else { stat = $"회복량 +{itemList[i].Value}"; }

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

                if (item.Type != ItemType.Potion && item.IsPurchase)
                {
                    Console.WriteLine("이미 구매한 아이템입니다.");
                    Thread.Sleep(1000);
                }
                else if (item.Type == ItemType.Potion)
                {
                    Console.Write("\n구매할 수량을 입력해주세요: ");
                    if (int.TryParse(Console.ReadLine(), out int quantity) && quantity > 0)
                    {
                        int totalPrice = price * quantity;
                        if (player.Gold >= totalPrice)
                        {
                            player.Gold -= totalPrice;

                            List<Item> newItems = new List<Item>();
                            var newItem = new Item(item.Name, item.Type, item.Value, item.ItemRate, item.Descrip, item.Cost, quantity);
                            newItems.Add(newItem);
                            inventory.AddItem(newItems);

                            Console.WriteLine($"{quantity}개 구매를 완료했습니다.");
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
                        Console.WriteLine("잘못된 수량입니다.");
                        Thread.Sleep(1000);
                    }
                }
                else if (player.Gold >= price)
                {
                    player.Gold -= price;
                    item.IsPurchase = true;

                    List<Item> newItems = new List<Item>();
                    var newItem = new Item(item.Name, item.Type, item.Value, item.ItemRate, item.Descrip, item.Cost, item.Count);
                    newItems.Add(newItem);
                    inventory.AddItem(newItems);

                    Console.WriteLine($"{item.Name}를 {item.Count}개 구매를 완료했습니다.");
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
        private void SellScreen()
        {
            Console.Clear();
            Console.WriteLine("상점 - 아이템 판매");
            Console.WriteLine($"\n[보유 골드]\n{player.Gold} G\n");

            var inventoryItems = inventory.GetItems();

            if (inventoryItems.Count < 1)
            {
                Console.WriteLine("판매할 아이템이 없습니다.");
                Thread.Sleep(1000);
                return;
            }

            Console.WriteLine("[아이템 목록]");

            for (int i = 0; i < inventoryItems.Count; i++)
            {
                var item = inventoryItems[i];

                string Price;
                int actualPrice = (int)(inventoryItems[i].Cost * 0.85);  // item 사용
                Price = $"{actualPrice} G";

                string stat;
                if (item.Type == ItemType.Amor) { stat = $"방어력 +{item.Value}"; }
                else if (item.Type == ItemType.Weapon) { stat = $"공격력 +{item.Value}"; }
                else { stat = $"회복량 +{item.Value}"; }

                string equippedMark = item.IsEquip ? "[E] " : "";
                string countDisplay = item.Type == ItemType.Potion ? $"[보유 : {item.Count}개]" : "";

                Console.WriteLine($"- {i + 1} {equippedMark}{item.Name,-8} | {stat,-6} | {item.Descrip,-30} | {Price} {countDisplay}");
            }

            Console.WriteLine("\n0. 나가기");
            Console.Write("판매할 아이템 번호를 입력해 주세요.\n");

            string input = Console.ReadLine();
            if (input == "0") return;

            if (int.TryParse(input, out int index) && index > 0 && index <= inventoryItems.Count)
            {
                var item = inventoryItems[index - 1];

                if (item.IsEquip)
                {
                    player.UnEquipItem(item);
                }

                if (item.Type == ItemType.Potion)  // 포션 판매
                {
                    Console.Write($"\n현재 보유 중인 {item.Name}의 개수: {item.Count}개");
                    Console.Write("\n판매할 수량을 입력해주세요: ");
                    string quantityInput = Console.ReadLine();

                    if (!int.TryParse(quantityInput, out int quantity))
                    {
                        Console.WriteLine("잘못된 수량입니다.");
                        Thread.Sleep(1000);
                        return;
                    }

                    if (quantity <= 0)
                    {
                        Console.WriteLine("1개 이상 입력해주세요.");
                        Thread.Sleep(1000);
                        return;
                    }

                    if (quantity > item.Count)
                    {
                        Console.WriteLine($"{item.Name}의 개수가 부족합니다.");
                        Thread.Sleep(1000);
                        return;
                    }

                    int sellPrice = (int)(item.Cost * 0.85 * quantity);
                    player.Gold += sellPrice;

                    if (quantity == item.Count)
                    {
                        inventory.RemoveItem(item);
                    }
                    else
                    {
                        item.Count -= quantity;
                    }

                    Console.WriteLine($"{item.Name} {quantity}개가 판매되었습니다.");
                    Thread.Sleep(1000);
                    return;
                }
                else
                {
                    int sellPrice = (int)(item.Cost * 0.85);

                    player.Gold += sellPrice;
                    inventory.RemoveItem(item); // 이부분 오류 발생 가능성 있음

                    var shopItem = itemList.Find(x => x.Name == item.Name);
                    if (shopItem != null && item.Type != ItemType.Potion)
                    {
                        shopItem.IsPurchase = false;
                    }
                }

                Console.WriteLine($"{item.Name}이 판매 되었습니다.");
                Thread.Sleep(1000);
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
}   
