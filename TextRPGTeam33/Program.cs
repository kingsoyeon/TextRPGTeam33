
using System.Runtime.InteropServices;
using System;
using System.Numerics;
using TextRPGTeam33;


partial class Program
{
    static GameSave gameSave;
    public static int adventureCount = 0;  // 탐험 횟수를 추적하는 변수
     public static int days = 0;  // 날짜를 추적하는 변수

    static void Main()
    {
        gameSave = new GameSave();
        Character player = gameSave.DisplaySave();

        Console.Clear();
        bool isValidInput = false;
        while (!isValidInput)
        { 
            Console.Clear();
            if (player != null)
            {

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine();
                Console.WriteLine(" ㅁ-ㅁ-ㅁ-ㅁ-ㅁ-ㅁ-ㅁ-ㅁ-ㅁ-ㅁ-ㅁ-ㅁ-ㅁ-ㅁ");
                Console.Write("ㅁ\t");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("오늘도 하루가 시작되었다.");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\t ㅁ");
                Console.Write("ㅁ\t");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("1. 부산역을 나선다.");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\t\t ㅁ");
                Console.Write("ㅁ\t");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("0. 오늘은 쉴까?");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\t\t\t ㅁ");
                // ■와 빈 문자열을 번갈아 출력
                Console.WriteLine(" ㅁ-ㅁ-ㅁ-ㅁ-ㅁ-ㅁ-ㅁ-ㅁ-ㅁ-ㅁ-ㅁ-ㅁ-ㅁ-ㅁ");


                Console.WriteLine();
                Console.ResetColor();
                Console.Write("원하시는 행동을 입력해주세요:");
                string startChoice = Console.ReadLine() ?? "0";

                if (startChoice == "1")
                {
                    StartGame(player);
                    isValidInput = true;
                }
                else if (startChoice == "0")
                {
                    Console.Clear();
                    Console.WriteLine("당신은 잠을 자다 좀비에게 습격당해 목숨을 잃었습니다.");
                    Thread.Sleep(2000);
                    Console.Clear();
                    End(player);
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
    }

    static void StartGame(Character player)
    {
        bool inDungeon = true;
        while (inDungeon)
        {

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"→ 살아남은 날짜:{days}");
            Console.WriteLine($"→ 탐험횟수:0{adventureCount}/02");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("====================<<행동>>=====================");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("|\t\t\t\t\t\t|");
            Console.Write("|\t");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("오늘 할 일을 선택하세요.");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t\t|");
            Console.WriteLine("|\t\t\t\t\t\t|");
            Console.Write("|\t");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("▶ 1. 상태보기");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t\t\t\t|");
            Console.WriteLine("|\t\t\t\t\t\t|");
            Console.Write("|\t");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("▶ 2. 탐험");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t\t\t\t|");
            Console.WriteLine("|\t\t\t\t\t\t|");
            Console.Write("|\t");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("▶ 3. 휴식");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t\t\t\t|");
            Console.WriteLine("|\t\t\t\t\t\t|");
            Console.Write("|\t");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("▶ 4. 포션 사용");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t\t\t\t|");
            Console.WriteLine("|\t\t\t\t\t\t|");
            Console.Write("|\t");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("▶ 5. 일기를 쓴다.");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t\t\t|");
            Console.WriteLine("|\t\t\t\t\t\t|");
            Console.Write("|\t");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("▶ 6. 퀘스트 보기.");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t\t\t|");
            Console.WriteLine("|\t\t\t\t\t\t|");
            Console.Write("|\t");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("▶ 0. 나가기");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t\t\t\t|");
            Console.WriteLine("|\t\t\t\t\t\t|");
            Console.WriteLine("_________________________________________________");
            Console.ResetColor();

            Console.Write("원하시는 행동을 입력해주세요: ");
            string choice = Console.ReadLine() ?? "0";

            if (choice == "1")
            {
                player.StatusDisplay();
            }
            else if (choice == "2")
            {
                Explore(player);  // 탐험을 시작합니다
            }
            else if (choice == "3")
            {
                rest(player);
            }
            else if (choice == "4")
            {
                DrinkPotion(player);
            }
            else if (choice == "5")
            {
                Save(player);
            }
            else if (choice == "6")
            {
                Quest.Instance.DisplayQuestList(player);
            }
            else if (choice == "7")
            {
                aaaaaaaaaaaaa(player);
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
            if (adventureCount >= 2)
            {
                adventureCount = 0;  // 탐험 횟수 초기화
                days++;  // 날짜 증가
                Console.Write($"하루가 지나갔습니다! 현재 날짜:");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"{days}");
                Console.ResetColor();
                Console.WriteLine("일");
                string currentSaveFile = gameSave.GetCurrentSaveFile();
                gameSave.Save(player, currentSaveFile);
                Thread.Sleep(2000);
            }
        }
    }
    static void aaaaaaaaaaaaa(Character player)
    {
        string choice = Console.ReadLine() ?? "0";
        bool eeeDungeon = true;
        while (eeeDungeon)
        {
            if (choice == "1")
            {
                StartBattle(player);
            }
            else if (choice == "2")
            {
                insideShop(player);  // 탐험을 시작합니다
            }
            else if (choice == "3")
            {
                Event(player);
            }
            else if (choice == "0")
            {
                eeeDungeon = false;
            } 
        }
    }
static void Explore(Character player)
    {
        Random random = new Random();
        int randomChoice = random.Next(0, 5);
        // 탐험이 시작되면 탐험 횟수 증가
        Console.Clear();
        Console.WriteLine($"탐험 {adventureCount + 1}회 진행 중...");

        Thread.Sleep(1000);
        switch (randomChoice)
        {
            case 0:
                insideShop(player);  // 상점 이벤트
                break;
            case 1:
                StartBattle(player);  // 전투 이벤트
                break;
            case 2:
                Event(player);  // 다른 이벤트
                break;
            case 3:
                StartBattle(player);  // 전투 이벤트
                break;
            case 4:
                StartBattle(player);  // 전투 이벤트
                break;

            default:
                Console.WriteLine("알 수 없는 이벤트가 발생했습니다.");
                break;
        }
    }

    static void Event(Character player)

    {
        Console.WriteLine("이벤트 발생!");
        Thread.Sleep(2000);
        OpenQuest(player);
        adventureCount++;
    }

    static void Save(Character player)

    {
        string currentSaveFile = gameSave.GetCurrentSaveFile();
        gameSave.Save(player, currentSaveFile);
        Console.Clear();
        Console.WriteLine("당신은 일기를 작성하셨습니다.");
        Thread.Sleep(500);
        Console.Write(".");
        Thread.Sleep(500);
        Console.Write(".");
        Thread.Sleep(500);
        Console.WriteLine(".");
        Thread.Sleep(500);

        
        string diary = @"



    . .,,,,,,,,,,, .,, ,      
    @ #@@@@@@@@@@@@@@@@@@     
    @ #@$$$$$$$$@@@@@@@@@     
    @ #@,.......#@@@@@@@@     
    @ #@@@@@@@@@#@@@@@@@@     
    @ #@!;;;;;;;#@@@@@@@@     
    @ #@@@@@@@@@#@@@@@@@@     
    @ #@*!!!!!!!#@@@@@@@@     
    @ #@@@@@@@@@@@@@@@@@@     
    @ #@@@@@@@@@@@@@@@@@@     
    @ #@@@@@@@@@@@#@@@#@@     
    @ #@@@@@@@@@@@#======     
    @ #@@@@@@@@@@@-, ----,    
    @ #@@@@@@@@@@@-*.@@@*@    
    @ #@@@@@@@@@@@-*.@@@!@    
    @ #@@@@@@@@@@@-, -~~~-    
    @ #@@@@@@@@@@@#======    
    @ #@@@@@@@@@@@@@@@@@=     
    . ,,,,,,,,,,,,,,,,,,      ";
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(diary);
        Thread.Sleep(2000);
    }

    
    static void rest(Character player)
    {
        Console.Clear();
        Console.WriteLine("휴식을 취하시면 탐험 횟수가 늘어납니다.");
        Console.WriteLine("휴식을 취하시겠습니까?");
        Console.WriteLine("1. 휴식을 취한다.");
        Console.WriteLine("0. 나간다.");
        string restChioce = Console.ReadLine() ?? "0";
        if (restChioce == "1")
        {
            Console.Clear();
            player.Hp = player.MaxHP;
            player.Mp = player.MaxMp;
            Console.WriteLine("휴식을 취합니다.");
            Console.WriteLine("체력과 마나가 모두 회복됩니다.");
            Thread.Sleep(1000);
            adventureCount++;
        }
        else if (restChioce == "0")
        {
            Console.WriteLine("휴식을 취하지 않고 돌아갑니다.");
            Thread.Sleep(1000);
            return;
        }
        else
        {
            Console.WriteLine("잘못된 입력입니다.");
            Thread.Sleep(1000);
        }
        adventureCount++;
    }

    static void OpenStatus()
    {
        Character Character = new();
        Character.StatusDisplay();
    }
    static void Potions(Character player) {
        Potion potion = new(player, player.Inventory);
        potion.DisplayPotion();

    }
        static void StartBattle(Character player)
    {   
        Battle battle = new Battle(player, Inventory.potion);
        battle.BattleStart(); 
        if (player.Hp <= 0)
        {
            Console.Clear();
            Console.WriteLine("당신은 몬스터와 싸우다 체력이 다했습니다.");
            Thread.Sleep(2000);
            Console.Clear();
            End(player);
            Environment.Exit(0);
        }
        adventureCount++;
    }

    static void OpenQuest(Character player) {
        Quest questSystem = Quest.Instance;
        questSystem.DisplayQuests(player);

    }
    static void DrinkPotion(Character player)
    {
        Potion potion = new Potion(player, player.Inventory);
        potion.DisplayPotion();
    }

    static void insideShop(Character player)
    {
        Inventory inventory = player.Inventory;
        Shop shop = new(player, inventory);
        shop.DisplayShop();
        adventureCount++;
    }
    static void End(Character player)
    {

        Console.BackgroundColor = ConsoleColor.Red;
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("                                                                                                                        ");
        Console.Write("                                                                                                                        ");
        Console.Write("                                                                                                                        ");
        Console.Write("                                                                                                                        ");
        Console.Write("                                                                                                                        ");
        Console.Write("                                                                                                                        ");
        Console.Write("                                                                                                                        ");
        Console.Write("                                                                                                                        ");
        Console.Write("                                                                                                                        ");
        Console.Write("                                                                                                                        ");
        Console.Write("                                                                                                                        ");
        Console.Write("                                                                                                                        ");
        Console.WriteLine("                                                당신은 사망하셨습니다.                                                  ");
        Console.Write($"                                                살아남은 날짜:{days}                                                         ");
        Console.Write("                                                                                                                        ");
        Console.Write("                                                                                                                        ");
        Console.Write("                                                                                                                        ");
        Console.Write("                                                                                                                        ");
        Console.Write("                                                                                                                        ");
        Console.Write("                                                                                                                        ");
        Console.Write("                                                                                                                        ");
        Console.Write("                                                                                                                        ");
        Console.Write("                                                                                                                        ");
        Console.Write("                                                                                                                        ");
        Console.Write("                                                                                                                        "); 
        Console.Write("                                                                                                                        ");
        Console.Write("                                                                                                                        ");
        Console.Write("                                                                                                                        ");
        Console.Write("                                                                                                                        ");
        Console.WriteLine("                                                                                                                        ");
        Thread.Sleep(3000);
        Console.ResetColor();
        Console.Clear();
    }
}
