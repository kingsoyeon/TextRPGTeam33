using System;
using System.ComponentModel;
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
    public static void CannonMinion()
    {

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("    Lv.5");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write(" 대포미니언");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(" HP 25   ");

        Console.ForegroundColor = ConsoleColor.Blue;
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
        Console.ResetColor();
    }

    public static void Voidling()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("    Lv.3");
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.Write(" 공허충");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(" HP 10   ");

        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine("             ◆◆");
        Console.Write("           ◆");
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.Write("◆");
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine("◆");
        Console.Write("         ◆");
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.Write("◆");
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.Write("◆");
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.Write("◆");
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.Write("◆");
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("    ▲");
        Console.Write("    ▲▲");
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.Write("    ◆◆");
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write(" ▲▲");
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.Write("))))))");
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine(" ▲");
        Console.Write("   ▲▼▼▲");
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.Write("↖//◆");
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write(" ▲▼▼▲");
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.Write("))))↘/");
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("▼▼");
        Console.Write("   ▼▼");
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.Write("   -");
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("    ▼▼   ▼▼   ▼▼");
        Console.WriteLine("    ▼        ▼     ▼    ▼");
        Console.ResetColor();
    }
    public static void minion()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("   Lv.2 ");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.Write(" 미니언 ");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("HP 15");
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write("    ▲");
        Console.Write("   ▲");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("             ◆◆◆");
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.Write("※");
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write("  ▼▼▼");
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.Write("↖ ");
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write("▼▼");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("           ◆");
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.Write(" ※");
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write(" ◆◆◆");
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.Write(" ↖");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.Write("           ◆◆◆");
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("    ◆");
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.Write("  ※");
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write(" ◆◆");
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.Write(" ↖↖");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("      ▲");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.Write(" ◆");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("↘ ↙");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.Write(" ◆");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write(" ▲");
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("◆◆◆");
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.Write("   ※");
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write(" ▼");
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.Write("   ↖↖");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("   ▲▲");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.Write("  ◆◆◆");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("  ▲▲");
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("◆◆◆◆");
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.Write("          ↖");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write(" @");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.Write("//");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.Write("   ◆◆◆◆");
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("   ◆◆◆");
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.Write("            ↖↖");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.Write("    ◆◆◆◆◆");
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("   ◆");
        Console.ResetColor();
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

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Program.minion();
                Console.WriteLine("");
                Console.WriteLine("");
                Program.CannonMinion();
                Console.WriteLine("");
                Console.WriteLine("");
                Program.Voidling();
                Thread.Sleep(3000);
                StartBattle(player);
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
    static void StartBattle(Character player)
    {
        Battle battle = new(player);
        battle.BattleStart();
    }

    static void OpenInventory()
    {

    }

    static void insideShop(Character player)
    {
        Shop shop = new Shop(player, null);
        shop.DisplayShop();
    }
}
