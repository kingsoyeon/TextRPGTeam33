using System;
using System.Threading;
using TextRPGTeam33;

class Program
{
    static void Main()
    {
        Console.Clear();
        bool isValidInput = false;
        while (!isValidInput)
        {

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
            Console.Write("■ ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("스파르타 던전에 오신 것을 환영합니다.");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" ■");
            Console.Write("■          ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("1. 던전에 입장한다.");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("          ■");
            Console.Write("■              ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("0. 도망친다.");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("             ■");
            Console.Write("■     ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("원하시는 행동을 입력해주세요!");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("     ■");
            Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
            Console.ForegroundColor = ConsoleColor.White;
            string startChoice = Console.ReadLine() ?? "0";

            if (startChoice == "1")
            {
                StartGame();
                isValidInput = true; 
            }
            else if (startChoice == "0")
            {
                Console.Clear();
                Console.WriteLine("도망에 성공하셨습니다...（￣v￣）↗　");
                Thread.Sleep(1000);
                Environment.Exit(0);

                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("잘못된 입력입니다.");
                    Thread.Sleep(1000); 
                }
            

        }
    }

    static void StartGame()
    {
        Character player = new Character(1, "Chad", "전사", 10, 5, 100, 50);

        bool inDungeon = true;
        while (inDungeon)
        {
            Console.Clear();
            Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
            Console.Write("■ ");
            Console.Write("던전에서 할 수 있는 일을 선택하세요.");
            Console.WriteLine("  ■");
            Console.Write("■     ");
            Console.Write("▶ 1. 상태보기");
            Console.WriteLine("                     ■");
            Console.Write("■     ");
            Console.Write("▶ 2. 인벤토리");
            Console.WriteLine("                     ■");
            Console.Write("■     ");
            Console.Write("▶ 3. 상점");
            Console.WriteLine("                         ■");
            Console.Write("■     ");
            Console.Write("▶ 4. 배틀");
            Console.WriteLine("                         ■");
            Console.Write("■     ");
            Console.Write("▶ 0. 나가기");
            Console.WriteLine("                       ■");
            Console.Write("■     ");
            Console.Write("원하시는 행동을 입력해주세요! ");
            Console.WriteLine("    ■");
            Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
            string choice = Console.ReadLine() ?? "0";

            if (choice == "1")
            {
                player.DisplayStatus();
            }
            else if (choice == "2")
            {
                OpenInventory();
            }
            else if (choice == "3")
            {
                insideShop(player);
            }
            else if (choice == "4")
            {
                StartBattle();
            }
            else if (choice == "0")
            {
                inDungeon = false;
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다.");
                Thread.Sleep(1000); 
            }
        }
    }

    static void StartBattle()
    {
        Battle battle = new Battle();
        battle.BattleStart();
    }

    static void OpenInventory()
    {
        // 인벤토리 구현 해야함
    }

    static void insideShop(Character player)
    {
        Shop shop = new Shop(player, null);
        shop.DisplayShop();
    }

}

