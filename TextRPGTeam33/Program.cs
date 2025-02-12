
using System.Runtime.InteropServices;
using System;
using System.Numerics;
using TextRPGTeam33;


partial class Program
{
    static GameSave gameSave;
    public static int adventureCount = 0;  // 탐험 횟수를 추적하는 변수
     public static int days = 0;  // 날짜를 추적하는 변수

    public class Tema
    {
        public void temas()
        {
            //ㅂ(1)
            Console.ResetColor();
            Console.WriteLine("");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("            ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\t          ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("      ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\t      ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\t\t      ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("        ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\t\t    ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("    ");
            Thread.Sleep(200);
            //(2)
            Console.WriteLine("");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("          ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\t         ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("        ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\t      ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\t\t   ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("     ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("     ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\t    ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("  ");
            Thread.Sleep(200);
            //(3)
            Console.WriteLine("");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("                ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\t        ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\t      ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\t\t ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("     ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("     ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("     ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("        ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("  ");
            Thread.Sleep(200);
            //(4)
            Console.WriteLine("");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("                ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\t       ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\t      ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\t\t");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("        ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write(" ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("   ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("        ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("  ");
            Thread.Sleep(200);
            //(5)
            Console.WriteLine("");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("            ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\t      ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\t      ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("        ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\t        ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("          ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\t    ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("  ");
            Thread.Sleep(200);
            //(6)
            Console.WriteLine("");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("          ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\t     ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("      ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\t      ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("        ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\t");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("          ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\t    ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("  ");
            Thread.Sleep(200);
            //(7)
            Console.WriteLine("");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("          ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\t    ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("        ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("      ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("      ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\t ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write(" ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("         ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("   ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("        ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("  ");
            Thread.Sleep(200);
            //(8)
            Console.WriteLine("");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("          ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\t   ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("          ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("     ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\t\t   ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("     ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("     ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("   ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("        ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("  ");
            Thread.Sleep(200);
            //(9)
            Console.WriteLine("");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("                ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\t  ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("            ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\t\t      ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("        ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\t    ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("  ");
            Thread.Sleep(200);
            //(10)
            Console.WriteLine("");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("                ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\t ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("              ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("   ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\t\t\t");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("        ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\t    ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("  ");
            Thread.Sleep(200);
            //(11)
            Console.WriteLine("");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("      ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("                    ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\t  ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("                  ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\t\t\t\t\t      ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("    ");
            Thread.Sleep(200);
            //ㅜ(12)
            Console.WriteLine("");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("                    ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\t\t");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\t\t\t\t\t\t");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("                        ");
            Thread.Sleep(200);
            //(13)
            Console.WriteLine("");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("    ");
            Console.Write("                ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\t\t");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\t\t\t\t\t\t");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("                        ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("  ");
            Thread.Sleep(200);
            //(14)
            Console.WriteLine("");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("      ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("  ");
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("          ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\t\t");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\t\t\t\t\t\t  ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("                  ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("  ");
            Thread.Sleep(200);
            //(15)
            Console.WriteLine("");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("            ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("      ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\t\t");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\t\t\t\t\t\t\t\t    ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("  ");
            Thread.Sleep(200);
            //(16)
            Console.WriteLine("");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("            ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("      ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\t\t");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("                        ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\t\t\t\t\t    ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("  ");
            Thread.Sleep(200);
            //(17)
            Console.WriteLine("");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("            ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("        ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\t\t");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("                        ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\t\t\t\t\t    ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("  ");
            Thread.Sleep(200);
            //(18)
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("  ");
            Console.Write("              ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\t\t          ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("                        ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\t\t\t\t\t      ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("    ");
            //(19)
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.ResetColor();
        }
    }
    static void Main()
    {
        Tema myClass = new Tema();

        myClass.temas();
        Thread.Sleep(750);
        Console.Write("");
        Console.Write("\t\t\t\t\t\t\t거기 졸지 말죠.Zzz...");
        Thread.Sleep(750);

        Console.Clear();
        gameSave = new GameSave();
        Character player = gameSave.DisplaySave();


        Console.Clear();
        bool isValidInput = false;
        while (!isValidInput)
        { 
            Console.Clear();
            if (player != null)
            {

                
                Console.Clear();

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


                Console.ResetColor();

                Console.Write("원하시는 행동을 입력해주세요:\n>>");
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
                Console.Clear();
                Achievement.Instance.CheckAchievements(player); //=> 업적 달성 팝업
                Achievement.Instance.DisplayAchievements();// 업적 리스트 출력
                Thread.Sleep(1000);
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
            Console.Write("▶ 7. 아이템 제작.");
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

            Console.Write("원하시는 행동을 입력해주세요:\n>>");
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

                CraftingSystem craftingSystem = new CraftingSystem(player);
                craftingSystem.DisplayCraftingMenu();

            }
            else if (choice == "8")
            {
                aaaaaaaaaaaaa(player);
            }
            else if (choice == "0")
            {
                inDungeon = false;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("잘못된 입력입니다.");
                Thread.Sleep(1000);
            }
            if (adventureCount >= 2)
            {
                Thread.Sleep(1000);
                Console.Clear();
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

                Achievement.Instance.CheckAchievements(player); //=> 업적 달성 팝업
                Achievement.Instance.DisplayAchievements();// 업적 리스트 출력
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
            break;
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
                string currentSaveFile = gameSave.GetCurrentSaveFile();
                gameSave.Save(player, currentSaveFile);
        }
    }

    static void Event(Character player)

    {
        Console.WriteLine("이벤트 발생!");
        Thread.Sleep(2000);
        OpenQuest(player);
        adventureCount++;
        string currentSaveFile = gameSave.GetCurrentSaveFile();
        gameSave.Save(player, currentSaveFile);
    }

    static void Save(Character player)

    {
        string currentSaveFile = gameSave.GetCurrentSaveFile();
        gameSave.Save(player, currentSaveFile);
        Console.Clear();
        string[] message =
        {
          "오", "늘", "도", " ", "하", "루", "가", " ", "마", "무", "리", " ", "되", "어", "간", "다",
            ".", "\n", "조", "금", "만", " ", "더", " ", "힘", "내", "자", "."
        };

        // 배열의 각 요소를 하나씩 출력하고, 100ms 대기
        foreach (string word in message)
        {
            Console.Write(word);    // 한 글자씩 출력
            Thread.Sleep(150);      // 100ms 대기
        }
        Console.WriteLine();
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
        Achievement.Instance.CheckAchievements(player); //=> 업적 달성 팝업
        Achievement.Instance.DisplayAchievements();// 업적 리스트 출력
    }

    
    static void rest(Character player)
    {
        Console.Clear();
        Console.WriteLine("#---------------------------------------------------------------------------------------#");
        Console.WriteLine("|여관주인\t\t\t\t\t\t\t\t\t\t|");
        Console.WriteLine("|지친 몸을 회복할 방을 알아 보고 계시는가요?\t\t\t\t\t\t|");
        Console.WriteLine("|가격은 1000 Gold입니다.\t\t\t\t\t\t\t\t|");
        Console.WriteLine("|\t\t\t\t\t\t\t\t\t\t\t|");
        Console.WriteLine("|\t\t\t\t\t\t\t\t\t\t\t|");
        Console.WriteLine("|\t\t\t\t\t\t\t\t\t\t\t|");
        Console.WriteLine("#---------------------------------------------------------------------------------------#");
        Thread.Sleep(2000);
        Console.Clear();
        Console.WriteLine("#---------------------------------------------------------------------------------------#");
        Console.WriteLine($"|※ TIP. 휴식을 취하시면 날짜가 늘어납니다.\t\t\t당신의 Gold : {player.Gold}\t|");
        Console.WriteLine("|\t\t\t\t\t\t\t\t\t\t\t|");
        Console.WriteLine("|\t\t\t\t\t\t\t\t\t\t\t|");
        Console.WriteLine("|\t\t\t\t\t\t\t\t\t\t\t|");
        Console.WriteLine("|휴식을 취하시겠습니까?\t\t\t\t\t\t\t\t\t|");
        Console.WriteLine("|1. 휴식을 취한다.\t\t\t\t\t\t\t\t\t|");
        Console.WriteLine("|0. 나간다.\t\t\t\t\t\t\t\t\t\t|");
        Console.WriteLine("#---------------------------------------------------------------------------------------#");
        Console.Write(">>");
        string restChioce = Console.ReadLine() ?? "0";
        if (restChioce == "1")
        {
            if (player.Gold >= 1000)
            {
                player.Gold -= 1000;
                Console.Clear();
                player.Hp = player.MaxHP;
                player.Mp = player.MaxMp;
                Console.WriteLine("#---------------------------------------------------------------------------------------#");
                Console.WriteLine(" 여관주인");
                Console.WriteLine(" 감사합니다 손님.");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine(" 휴식을 취합니다.");
                Console.WriteLine(" 체력과 마나가 모두 회복됩니다.");
                Console.WriteLine(" 하루가 지났습니다.(당신은 잠을 청하기 전 일기를 쓰셨습니다.)");
                Console.WriteLine($" 현재날짜  :{days}");
                Console.WriteLine("#---------------------------------------------------------------------------------------#");
                Thread.Sleep(2000);
                adventureCount *= 0;
                days += 1;
                string currentSaveFile = gameSave.GetCurrentSaveFile();
                gameSave.Save(player, currentSaveFile);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("#---------------------------------------------------------------------------------------#");
                Console.WriteLine(" 여관주인");
                Console.WriteLine(" 손님, 돈이 부족하신거 같습니다만...");
                Thread.Sleep(1000);
                Console.WriteLine(" 썩 나가주십쇼.");
                Console.WriteLine("#---------------------------------------------------------------------------------------#");
                Thread.Sleep(1000);
                return;
            }
           

        }
        else if (restChioce == "0")
        {
            Console.Clear();
            Console.WriteLine("휴식을 취하지 않고 돌아갑니다.");
            Thread.Sleep(1000);
            return;
        }
        else
        {
            Console.Clear();
            Console.WriteLine("잘못된 입력입니다.");
            Thread.Sleep(1000);
        }

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
        string currentSaveFile = gameSave.GetCurrentSaveFile();
        gameSave.Save(player, currentSaveFile);
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
