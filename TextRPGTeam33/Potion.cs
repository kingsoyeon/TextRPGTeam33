using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPGTeam33
{
    public class Potion
    {
        private List<Item> hpPotions;
        private List<Item> mpPotions;
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
            hpPotions = inventory.GetItems()
            .Where(x => x.Type == ItemType.Potion && x.Count > 0)
            .ToList();
            mpPotions = inventory.GetItems()
                .Where(x => x.Type == ItemType.MPPotion && x.Count > 0)
                .ToList();
        }
        public int DisplayPotion() // 표션정보 출력
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("TIP:회복 아이템을 사용하여 체력과 스테미나를 회복할수 있습니다.");

                RefreshPotions();

                if (hpPotions.Count == 0 && mpPotions.Count == 0) // 포션이 없을 경우
                {
                    
                    Console.WriteLine("사용 가능한 포션이 없습니다.\n");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("================================================OOO((");
                    Console.ResetColor();
                    Console.Write("보유중인 포션");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("))OOO=================================================");
                    Console.WriteLine("");
                    Console.ResetColor();
                    
                    if (hpPotions.Count > 0)
                    {
                        Console.WriteLine("[HP 포션 목록]");
                        for (int i = 0; i < hpPotions.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {hpPotions[i].Name} | HP 회복량: +{hpPotions[i].Value} | 남은 수량: {hpPotions[i].Count}개");
                        }
                    }
                    if (mpPotions.Count > 0)
                    {
                        Console.WriteLine("\n[MP 포션 목록]");
                        for (int i = 0; i < mpPotions.Count; i++)
                        {
                            Console.WriteLine($"{hpPotions.Count + i + 1}. {mpPotions[i].Name} | MP 회복량: +{mpPotions[i].Value} | 남은 수량: {mpPotions[i].Count}개");
                        }
                    }
                    Console.Write($"\n현재 체력:");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write($"{character.Hp}/");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{character.MaxHP}\n");
                    Console.ResetColor();

                    Console.Write($"현재 마나:");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write($"{character.Mp}/");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write($"{character.MaxMp}\n");
                    Console.ResetColor();
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("");
                Console.WriteLine("________________________________________________________________________________________________________________________");
                Console.WriteLine("");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("1. 포션 선택");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("0. 나가기");
                Console.ResetColor();

                Console.Write("\n원하는 행동을 입력해주세요.\n>>");
                string input = Console.ReadLine();

                if (input == "0") return 0; // 나가기
                else if (input == "1") // 1. 포션 선택
                {
                    if (hpPotions.Count > 0 || mpPotions.Count > 0)
                    {
                        Console.Clear();
                        SelectPotion(); //포션 선택
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("사용할 수 있는 포션이 없습니다!");
                        Console.ResetColor();
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
        }
        public void SelectPotion() // 포션 선택
        {
            while (true)
            {
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("================================================OOO((");
                Console.ResetColor();
                Console.Write("보유중인 포션");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("))OOO=================================================");
                Console.WriteLine("");
                Console.ResetColor();

                if (hpPotions.Count > 0)
                {                    
                    for (int i = 0; i < hpPotions.Count; i++)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("●");
                        Console.ResetColor();
                        Console.WriteLine($"{i + 1}. {hpPotions[i].Name} | HP 회복량: +{hpPotions[i].Value} | 남은 수량: {hpPotions[i].Count}개");
                    }
                }
                    if (mpPotions.Count > 0)
                {
                    Console.WriteLine("\n[MP 포션]");
                    for (int i = 0; i < mpPotions.Count; i++)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("●");
                        Console.ResetColor();
                        Console.WriteLine($"{hpPotions.Count + i + 1}. {mpPotions[i].Name} | MP 회복량: +{mpPotions[i].Value} | 남은 수량: {mpPotions[i].Count}개");
                    }
                }
                
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("");
                Console.WriteLine("________________________________________________________________________________________________________________________");
                Console.WriteLine("");
                Console.ResetColor();
                Console.WriteLine("0. 취소");

                Console.Write("\n사용할 포션을 선택해주세요.\n>>");

                if (int.TryParse(Console.ReadLine(), out int index))
                {
                    if (index > 0 && index <= hpPotions.Count)
                    {
                        UsePotion(hpPotions[index - 1], true);
                        break;
                    }
                    else if (index > hpPotions.Count && index <= hpPotions.Count + mpPotions.Count)
                    {
                        UsePotion(mpPotions[index - hpPotions.Count - 1], false);
                        break;
                    }
                    else if (index == 0)
                    {
                        return;
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

        private void UsePotion(Item potion, bool isHPPotion) // 포션 사용 코드
        {
            if (isHPPotion) // HP 포션
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

                        if (potion.Count == 0) { inventory.RemoveItem(potion); }// 포션 개수가 0이 되면 인벤토리에서 제거

                        Console.WriteLine($"{potion.Name}을(를) 사용했습니다.");
                        Console.WriteLine($"HP가 {potion.Value} 회복 되었습니다.");
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
            else //MP 포션
            {
                if (character.Mp < character.MaxMp)
                {
                    if (potion.Count > 0)
                    {
                        character.Mp += potion.Value;
                        if (character.Mp > character.MaxMp)
                        {
                            character.Mp = character.MaxMp;
                        }

                        potion.Count--;
                        if (potion.Count == 0) { inventory.RemoveItem(potion); }// 포션 개수가 0이 되면 인벤토리에서 제거

                        Console.WriteLine($"{potion.Name}을(를) 사용했습니다.");
                        Console.WriteLine($"MP가 {potion.Value} 회복되었습니다.");
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
                    Console.WriteLine("이미 마나가 최대입니다!");
                    Thread.Sleep(1000);
                }
            }
        }
    }
}
