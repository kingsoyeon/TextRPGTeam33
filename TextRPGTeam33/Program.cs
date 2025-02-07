using System;
using System.Threading;
using TextRPGTeam33;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        bool isValidInput = false;
        while (!isValidInput)
        {
            Console.Clear();

            /*Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("    	            ___");
            Console.WriteLine("	   	  ▲▼▲  ▼");
            Console.Write("	        ◆");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("↘ ↙ ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("◆");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("	 ●●●");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("  ＠");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("/");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("◆");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("/");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("@ ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("▲");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("    ■■■■");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("〓〓〓");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(" ●●●●");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" ||");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("  ■");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("■■■■■■");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("■");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("   ●  ◆◆  ●"); 
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(" ||");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("  ==))");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("  ■");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("■■■■■■");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("■");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("〓/");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("●  ◆◆  ●");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(" ||");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("  ==))");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("    ■■■■");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(" /");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("     ●●●●");
            Console.ForegroundColor = ConsoleColor.Cyan;
            대포미니언*/
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
            Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
            Console.ResetColor();
            Console.Write("원하시는 행동을 입력해주세요:");
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
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
            Console.Write("■ ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("던전에서 할 수 있는 일을 선택하세요.");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("  ■");
            Console.Write("■     ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("▶ 1. 상태보기");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("                     ■");
            Console.Write("■     ");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("▶ 2. 인벤토리");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("                     ■");
            Console.Write("■     ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("▶ 3. 상점");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("                         ■");
            Console.Write("■     ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("▶ 4. 배틀");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("                         ■");
            Console.Write("■     ");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("▶ 0. 나가기");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("                       ■");
            Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
            Console.ResetColor();
            //Console.BackgroundColor = ConsoleColor.Yellow; // 배경색 변경
            Console.Write("원하시는 행동을 입력해주세요: ");
            string choice = Console.ReadLine() ?? "0";

            if (choice == "1")
            {
                player.StatusDisplay();
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
                Battle battle = new Battle(player);
                battle.BattleStart();
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

    static void OpenStatus()
    {
        Character Character = new Character(1, "Chad", "전사", 10, 5, 100, 50);
        Character.StatusDisplay();
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
