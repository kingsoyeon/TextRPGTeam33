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

        public void DisplayShop() // 상점 출력
        {
            bool isShopOpen = true;
            while (isShopOpen) // isShopOpen = false가 될시 종료
            {
                Console.Clear();
                Console.WriteLine("상점 주인");
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("필요한 물건이 있나?");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\n[보유 골드]");
                Console.WriteLine($"{player.Gold} G");
                Console.ResetColor();
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n========================================================<<상점>>========================================================");
                Console.ResetColor();
                Console.WriteLine("");

                for (int i = 0; i < itemList.Count; i++) // itemList에서 아이템 내용 출력
                {
                    string price;
                    if (itemList[i].IsPurchase)
                    {
                        price = "보유중";
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        int actualPrice = (int)(itemList[i].Cost); // 보유중이 아닐때 아이템 가격 출력
                        price = $"{actualPrice} G";
                        Console.ResetColor();
                    }

                    string stat; // 아이템 stat(값)에 방어력, 공격력, 회복력 글자 추가

                    if (itemList[i].Type == ItemType.Amor) {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("●");
                        Console.ResetColor();
                        stat = $"방어력+{itemList[i].Value}"; } // ItemType이 Amor일 경우 "방어력"

                    else if (itemList[i].Type == ItemType.Weapon) {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.Write("●");
                        Console.ResetColor();
                        stat = $"공격력 +{itemList[i].Value}"; }// ItemType이 Weapon일 경우 "공격력"
                    else if (itemList[i].Type == ItemType.Potion){
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("●");
                        Console.ResetColor();
                        stat = $"HP회복량 +{itemList[i].Value}"; } // ItemType이 Potion일 경우 "HP회복력"
                    else{
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("●");
                        Console.ResetColor();
                        stat = $"MP회복량 +{itemList[i].Value}"; }// 그외(ItemType이 Potion) 일 경우 "MP회복력"
              
                    Console.WriteLine($"- {itemList[i].Name,-8} | {stat,-6} | {itemList[i].Descrip,-30} | {price}"); // - {이름} | 값(공격력, 방어력, 회복력) | 아이템 설명 | 가격/보유여부
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("");
                Console.WriteLine("________________________________________________________________________________________________________________________");
                Console.ResetColor();
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n1. 아이템 구매");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("2. 아이템 판매");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("0. 나가기\n");
                Console.ResetColor();

                Console.Write("원하시는 행동을 입력해주세요.\n>>");
                string input = Console.ReadLine();

                if( input == "1")
                {
                    BuyScreen(); // 구매
                }
                else if( input == "2")
                {
                    SellScreen(); //판매
                }
                else if (input == "0")
                {
                    isShopOpen = false; // 나가기
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("잘못된 입력입니다.");
                    Console.ResetColor();
                    Thread.Sleep(1000);
                    Console.Clear();
                }

            }
            
        }

        private void BuyScreen() // 구매창 출력
        {
            Console.Clear();
            Console.WriteLine("상점 주인");
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("젊은이 보는눈이 있구만!");
            Console.ResetColor();

            Console.WriteLine("\n[보유 골드]");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"{player.Gold} G");
            Console.ResetColor();
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n====================================================<<아이템 목록>>=====================================================");
            Console.ResetColor();
            Console.WriteLine("");
            for (int i = 0; i < itemList.Count; i++) // itemList에서 아이템 내용 출력
            {
                string price;
                if (itemList[i].IsPurchase) // 만약 보유중 이라면...
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    price = "보유중";
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    int actualPrice = (int)(itemList[i].Cost); // 보유중이 아닐때 아이템 가격 출력
                    price = $"{actualPrice} G";
                    Console.ResetColor();
                }

                string stat;

                if (itemList[i].Type == ItemType.Amor)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("●");
                    Console.ResetColor();
                    stat = $"방어력+{itemList[i].Value}";
                } // ItemType이 Amor일 경우 "방어력"

                else if (itemList[i].Type == ItemType.Weapon)
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.Write("●");
                    Console.ResetColor();
                    stat = $"공격력 +{itemList[i].Value}";
                }// ItemType이 Weapon일 경우 "공격력"
                else if (itemList[i].Type == ItemType.Potion)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("●");
                    Console.ResetColor();
                    stat = $"HP회복량 +{itemList[i].Value}";
                } // ItemType이 Potion일 경우 "HP회복력"
                else
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("●");
                    Console.ResetColor();
                    stat = $"MP회복량 +{itemList[i].Value}";
                }// 그외(ItemType이 Potion) 일 경우 "MP회복력"

                Console.WriteLine($"- {i + 1} {itemList[i].Name,-8} | {stat,-6} | {itemList[i].Descrip,-30} | {price}"); // - index 이름 | 값(공격력, 방어력, 회복력) | 아이템 설명 | 가격/보유여부
            }
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("________________________________________________________________________________________________________________________");
            Console.ResetColor();
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\n0. 나가기");
            Console.ResetColor();
             
            Console.Write("\n구매할 아이템 번호를 입력해주세요.\n>>");

            string input = Console.ReadLine();
            if (input == "0") return;

            if (int.TryParse(input, out int index) && index > 0 && index <= itemList.Count) //input값을 정수(int)로 변환 시켜 index에 넣는다.
            {
                var item = itemList[index - 1];
                int price = item.Cost;

                if (item.Type != ItemType.Potion && item.Type != ItemType.MPPotion && item.IsPurchase) // ItemType이 Potion 과 MPPotion이 아니고, 보유중이 라면... => 포션은 여러번 구매 가능
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("이미 보유한 아이템입니다.");
                    Thread.Sleep(1000);
                    Console.ResetColor();
                }
                else if (item.Type == ItemType.Potion || item.Type == ItemType.MPPotion) // ItemType이 Potion 이라면...
                {
                    Console.Write("\n구매할 수량을 입력해주세요:\n>> ");
                    if (int.TryParse(Console.ReadLine(), out int quantity) && quantity > 0) // 입력값을 정수로 변환 시켜 quantity에 넣는다.
                    {
                        int totalPrice = price * quantity; // 가격 = 포션 가격 x 입력값
                        if (player.Gold >= totalPrice)
                        {
                            player.Gold -= totalPrice; // 플레이어가 보유한 Gold 만큼 가격 차감

                            var newItem = Item.CreateNewItem(item); // 새로운 아이템 생성
                            newItem.Count = quantity; // 수량 설정
                            inventory.AddItem(newItem); // 인벤토리에 추가

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
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("잘못된 수량입니다.");
                        Console.ResetColor();
                        Thread.Sleep(1000);
                        Console.Clear();
                    }
                }
                else if (player.Gold >= price)
                {
                    player.Gold -= price;
                    item.IsPurchase = true;

                    var newItem = Item.CreateNewItem(item); // 새로운 아이템 생성
                    inventory.AddItem(newItem); // newItem을 인벤토리에 추가

                    Console.WriteLine($"{item.Name} 구매를 완료했습니다.");
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
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("잘못된 입력입니다.");
                Console.ResetColor();
                Thread.Sleep(1000);
                Console.Clear();
            }
        }
        private void SellScreen() // 판매창 출력
        {
            Console.Clear();
            Console.WriteLine("상점 주인");
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("젊은이 무얼 팔려는 게인가.");
            Console.ResetColor();

            var inventoryItems = inventory.GetItems(); //인벤토리 아이템 정보를 inventoryItems에 입력

            if (inventoryItems.Count < 1) //인벤토리가 비어있다면...
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("판매할 아이템이 업습니다.");
                Console.ResetColor();
                Thread.Sleep(1000);
                Console.Clear();
                return;
            }
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n====================================================<<아이템 목록>>=====================================================");
            Console.ResetColor();
            Console.WriteLine("");
            for (int i = 0; i < inventoryItems.Count; i++) //인벤토리 아이템 내용 출력
            {
                var item = inventoryItems[i]; // 

                string Price;
                int actualPrice = (int)(inventoryItems[i].Cost * 0.85);  // 판매가격은 제품가격의 85%의 가격으로 판매
                Price = $"{actualPrice} G";

                string stat;

                if (itemList[i].Type == ItemType.Amor)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("●");
                    Console.ResetColor();
                    stat = $"방어력+{itemList[i].Value}";
                } // ItemType이 Amor일 경우 "방어력"

                else if (itemList[i].Type == ItemType.Weapon)
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.Write("●");
                    Console.ResetColor();
                    stat = $"공격력 +{itemList[i].Value}";
                }// ItemType이 Weapon일 경우 "공격력"
                else if (itemList[i].Type == ItemType.Potion)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("●");
                    Console.ResetColor();
                    stat = $"HP회복량 +{itemList[i].Value}";
                } // ItemType이 Potion일 경우 "HP회복력"
                else
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("●");
                    Console.ResetColor();
                    stat = $"MP회복량 +{itemList[i].Value}";
                }// 그외(ItemType이 Potion) 일 경우 "MP회복력"

                Console.ForegroundColor = ConsoleColor.Cyan;
                string equippedMark = item.IsEquip ? "[E] " : ""; // 장착중이면  [E] 출력
                Console.ResetColor();
                string countDisplay = "";

                if (item.Type == ItemType.Potion || item.Type == ItemType.MPPotion || ((item.Type == ItemType.Weapon || item.Type == ItemType.Amor) && item.Count > 1))   // 포션이거나 장비의 개수가 2개 이상일 때만 보유 개수 표시
                {
                    countDisplay = $"[보유 : {item.Count}개]"; // 여러개 보유중이면 보유 개수 출력
                }
                Console.WriteLine($"- {i + 1} {equippedMark}{item.Name,-8} | {stat,-6} | {item.Descrip,-30} | {Price} {countDisplay}"); // - index 이름 | 값(공격력, 방어력, 회복력) | 아이템 설명 | 가격/보유여부 [보유 개수]
            }
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("________________________________________________________________________________________________________________________");
            Console.ResetColor();
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\n0. 나가기\n");
            Console.ResetColor();
            Console.Write("판매할 아이템 번호를 입력해 주세요.\n>>");

            string input = Console.ReadLine();
            if (input == "0") return;

            if (int.TryParse(input, out int index) && index > 0 && index <= inventoryItems.Count) //input값을 정수(int)로 변환 시켜 index에 넣는다.
            {
                {
                    var item = inventoryItems[index - 1];

                    Console.Write($"\n현재 보유 중인 {item.Name}의 개수: {item.Count}개");
                    Console.Write("\n판매할 수량을 입력해주세요:\n>> ");

                    if (!int.TryParse(Console.ReadLine(), out int quantity)) // 입력값이 잘못됬다면... / 입력값을 정수로 변환시켜 index에 넣는다.
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("잘못된 수량입니다.");
                        Console.ResetColor();
                        Thread.Sleep(1000);
                        Console.Clear();
                        return;
                    }

                    if (quantity <= 0) //입력값이 0이하 이라면... => DisplayShop()으로 이동
                    {
                        Console.WriteLine("1개 이상 입력해주세요.");
                        Thread.Sleep(1000);
                        return;
                    }

                    if (quantity > item.Count) // 입력값이 보유 포션수 보다 만다면...
                    {
                        Console.WriteLine($"{item.Name}의 개수가 부족합니다.");
                        Thread.Sleep(1000);
                        return;
                    }

                    if (item.IsEquip)
                    {
                        player.UnEquipItem(item); // 장착중 일경우 장착 해제
                    }

                    int sellPrice = (int)(item.Cost * 0.85 * quantity); // 판매 가격은 아이템 가격의 85%.
                    player.Gold += sellPrice;

                    if (quantity == item.Count) // 입력 값 = 아이템 수 이라면...
                    {
                        inventory.RemoveItem(item);  // 이부분 오류 발생 가능성 있음 // 아이템 제거 
                    }
                    else
                    {
                        item.Count -= quantity; // 아이템 수에서 입력값 만큼 제거. ex) 보유수 10, 입력값 5 => 보유수 5
                    }

                    Console.WriteLine($"{item.Name} {quantity}개가 판매되었습니다.");
                    Thread.Sleep(1000);
                    return;
                }
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("잘못된 입력입니다.");
                Console.ResetColor();
                Thread.Sleep(1000);
                Console.Clear();
            }
        }
    }
}   
